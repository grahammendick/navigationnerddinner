using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;

namespace NerdDinner.Helpers
{
	public static class ControllerFactory
	{
		public static object Resolve(Type t)
		{
			return ((IUnityContainer)HttpContext.Current.Application["Container"]).Resolve(t);
		}
		public static T Resolve<T>()
		{
			return ((IUnityContainer)HttpContext.Current.Application["Container"]).Resolve<T>();
		}
	}
}
