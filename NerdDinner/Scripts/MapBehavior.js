Type.registerNamespace("NerdDinner.Scripts");

NerdDinner.Scripts.MapBehavior = function(element) {
	NerdDinner.Scripts.MapBehavior.initializeBase(this, [element]);
	this._map = null;
	this._points = [];
	this._shapes = [];
	this._center = null;
	this._longitude;
	this._latitude;
	this._name;
	this._description;
	this._address;
}

NerdDinner.Scripts.MapBehavior.prototype = {
	initialize: function() {
		NerdDinner.Scripts.MapBehavior.callBaseMethod(this, 'initialize');
		if (this.get_address() != null) {
			this._onAddressChangeHandler = Function.createDelegate(this, this._onAddressChange);
			$addHandler(this.get_address(), 'blur', this._onAddressChangeHandler);
		}
		this._loadMap();
	},

	dispose: function() {
		NerdDinner.Scripts.MapBehavior.callBaseMethod(this, 'dispose');
		if (this.get_address() != null) {
			$removeHandler(this.get_address(), 'blur', this._onAddressChangeHandler);
		}
	},

	get_map: function() {
		return this._map;
	},

	_set_map: function(value) {
		this._map = value;
	},

	get_points: function() {
		return this._points;
	},

	_set_points: function(value) {
		this._points = value;
	},

	get_shapes: function() {
		return this._shapes;
	},

	_set_shapes: function(value) {
		this._shapes = value;
	},

	_get_center: function() {
		return this._center;
	},

	_set_center: function(value) {
		this._center = value;
	},

	get_longitude: function() {
		return this._longitude;
	},

	set_longitude: function(value) {
		this._longitude = value;
	},

	get_latitude: function() {
		return this._latitude;
	},

	set_latitude: function(value) {
		this._latitude = value;
	},

	_get_longitude_value: function() {
		return (this.get_longitude() != null && this.get_longitude().value != '') ? parseFloat(this.get_longitude().value) : 0;
	},

	_set_longitude_value: function(value) {
		if (this.get_longitude() != null)
			this.get_longitude().value = value;
	},

	_get_latitude_value: function() {
		return (this.get_latitude() != null && this.get_latitude().value != '') ? parseFloat(this.get_latitude().value) : 0;
	},

	_set_latitude_value: function(value) {
		if (this.get_latitude() != null)
			this.get_latitude().value = value;
	},

	get_name: function() {
		return this._name;
	},

	set_name: function(value) {
		this._name = value;
	},

	get_description: function() {
		return this._description;
	},

	set_description: function(value) {
		this._description = value;
	},

	get_address: function() {
		return this._address;
	},

	set_address: function(value) {
		this._address = value;
	},

	_onAddressChange: function(e) {
		this._set_latitude_value('0');
		this._set_longitude_value('0');

		var address = jQuery.trim(this.get_address().value);

		if (address.length < 1)
			return;

		this.findAddressOnMap(address);
	},

	_loadMap: function() {
		this._set_map(new VEMap(this.get_element().id));
		options = new VEMapOptions();
		options.EnableBirdseye = false;

		// Makes the control bar less obtrusize.
		this.get_map().SetDashboardSize(VEDashboardSize.Small);

		var map = this;
		if (this._get_latitude_value() != 0 && this._get_longitude_value() != 0) {
			this._set_center(new VELatLong(this._get_latitude_value(), this._get_longitude_value()));
			this.get_map().onLoadMap = function() {
				map._onMapLoaded();
			};
		}

		this.get_map().LoadMap(this._get_center(), null, null, null, null, null, null, options);
	},

	_onMapLoaded: function() {
		this.loadPin(this._get_center(), this.get_name(), this.get_description());
		this.get_map().SetZoomLevel(14);
	},

	loadPin: function(LL, name, description) {
		var shape = new VEShape(VEShapeType.Pushpin, LL);

		//Make a nice Pushpin shape with a title and description
		shape.SetTitle("<span class=\"pinTitle\"> " + escape(name) + "</span>");
		if (description !== undefined) {
			shape.SetDescription("<p class=\"pinDetails\">" +
			escape(description) + "</p>");
		}
		this.get_map().AddShape(shape);
		this.get_points().push(LL);
		this.get_shapes().push(shape);
	},

	findAddressOnMap: function(where) {
		var numberOfResults = 20;
		var setBestMapView = true;
		var showResults = true;

		var map = this;
		this.get_map().Find("", where, null, null, null,
			   numberOfResults, showResults, true, true,
			   setBestMapView, function(layer, resultsArray, places, hasMore, VEErrorMessage) {
			   	map._callbackForLocation(layer, resultsArray, places, hasMore, VEErrorMessage);
			   });
	},

	_callbackForLocation: function(layer, resultsArray, places, hasMore, VEErrorMessage) {
		this.clearMap();

		if (places == null)
			return;

		var map = this;
		//Make a pushpin for each place we find
		$.each(places, function(i, item) {
			var description = "";
			if (item.Description !== undefined) {
				description = item.Description;
			}
			var LL = new VELatLong(item.LatLong.Latitude,
							item.LatLong.Longitude);

			map.loadPin(LL, item.Name, description);
		});

		//Make sure all pushpins are visible
		if (this.get_points().length > 1) {
			this.get_map().SetMapView(this.get_points());
		}

		//If we've found exactly one place, that's our address.
		if (this.get_points().length === 1) {
			this._set_latitude_value(this.get_points()[0].Latitude);
			this._set_longitude_value(this.get_points()[0].Longitude);
		}
	},

	findGivenLocation: function(where, callback) {
		this.get_map().Find("", where, null, null, null, null, null, false, null, null, callback);
	},

	clearMap: function() {
		this.get_map().Clear();
		this._set_points([]);
		this._set_shapes([]);
	}
}
NerdDinner.Scripts.MapBehavior.registerClass('NerdDinner.Scripts.MapBehavior', Sys.UI.Behavior);
