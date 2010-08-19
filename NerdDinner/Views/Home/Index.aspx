<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="NerdDinner.Views.Home.Index" MasterPageFile="~/Views/Shared/Site.Master" Theme="Site" %>
<%@ Register assembly="NerdDinner" namespace="NerdDinner.Controls" tagprefix="cc2" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Find a Dinner</h2>
	<div id="mapDivLeft">
		<div id="searchBox">
			Enter your location: <input type="text" id="Location" /> or <asp:HyperLink ID="UpcomingLink" runat="server" Text="View All Upcoming Dinners" />.
			<input id="search" type="submit" value="Search" />
		</div>
		<asp:Panel ID="Map" runat="server" style="width:600px;height:400px;position:relative"/>
		<cc2:MapExtender ID="Map_MapExtender" runat="server" TargetControlID="Map" BehaviorId="MapBehavior"/>
	</div>
	<div id="mapDivRight">
		<div id="dinnerList"></div>
	</div>
	<script type="text/javascript">

		$("#search").click(function(evt) {
			var where = jQuery.trim($("#Location").val());
			if (where.length < 1)
				return false;
				
			FindDinnersGivenLocation(where)
			return false;
		});

		function FindDinnersGivenLocation(where) {
			$find('MapBehavior').findGivenLocation(where, callbackUpdateMapDinners);
		}

		function callbackUpdateMapDinners(layer, resultsArray, places, hasMore, VEErrorMessage) {
			$("#dinnerList").empty();
			var map = $find('MapBehavior');
			map.clearMap();
			var center = map.get_map().GetCenter();
			PageMethods.SearchByLocation(center.Latitude, center.Longitude, function(dinners) {
				$.each(dinners, function(i, dinner) {

					var LL = new VELatLong(dinner.Latitude, dinner.Longitude, 0, null);

					var RsvpMessage = "";

					if (dinner.RSVPCount == 1)
						RsvpMessage = "" + dinner.RSVPCount + " RSVP";
					else
						RsvpMessage = "" + dinner.RSVPCount + " RSVPs";

					// Add Pin to Map
					map.loadPin(LL, '<a href="' + dinner.DetailsLink + '">'
								+ dinner.Title + '</a>',
								"<p>" + dinner.Description + "</p>" + RsvpMessage);

					//Add a dinner to the <ul> dinnerList on the right
					$('#dinnerList').append($('<li/>')
									.attr("class", "dinnerItem")
									.append($('<a/>')
									.attr("href", dinner.DetailsLink)
									.html(dinner.Title)).append(" (" + RsvpMessage + ")"));
				});

				// Adjust zoom to display all the pins we just added.
				if (map.get_points().length > 1) {
					map.get_map().SetMapView(map.get_points());
				}

				// Display the event's pin-bubble on hover.
				$(".dinnerItem").each(function(i, dinner) {
					$(dinner).hover(
						function() { map.get_map().ShowInfoBox(map.get_shapes()[i]); },
						function() { map.get_map().HideInfoBox(map.get_shapes()[i]); }
					);
				});
			});
		}
		
	</script>
</asp:Content>

