using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace NuGetFinder
{
	public class App : Application
	{
		public App()
		{
            Simple.OData.Client.V3Adapter.Reference();
            MainPage = new NavigationPage(new SearchPage());
        }
	}
}
