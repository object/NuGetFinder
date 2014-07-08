using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NuGetFinder
{
    public class DetailsPage : ContentPage
    {
        public DetailsPage()
        {
            Title = "Package Details";

            NavigationPage.SetHasNavigationBar(this, true);

            var stackLayout = new StackLayout();

            if (Device.OS == TargetPlatform.WinPhone)
            {
                // WinPhone doesn't have the title showing
                stackLayout.Children.Add(new Label { Text = Title, Font = Font.SystemFontOfSize(50) });
            }

            var titleLabel = new Label() { Font = Font.SystemFontOfSize(NamedSize.Large) };
            titleLabel.SetBinding(Label.TextProperty, "Title");
            stackLayout.Children.Add(titleLabel);
            var idLayout = new StackLayout() { Orientation = StackOrientation.Horizontal };
            idLayout.Children.Add(new Label() { Text = "Package Id: " });
            var idLabel = new Label();
            idLabel.SetBinding(Label.TextProperty, "Id");
            idLayout.Children.Add(idLabel);
            stackLayout.Children.Add(idLayout);

            stackLayout.Children.Add(new Label());

            var versionLayout = new StackLayout() { Orientation = StackOrientation.Horizontal };
            versionLayout.Children.Add(new Label() { Text = "Current version: " });
            var versionLabel = new Label();
            versionLabel.SetBinding(Label.TextProperty, "CurrentVersion");
            versionLayout.Children.Add(versionLabel);
            stackLayout.Children.Add(versionLayout);
            var releaseLayout = new StackLayout() { Orientation = StackOrientation.Horizontal };
            releaseLayout.Children.Add(new Label() { Text = "Released: " });
            var releaseLabel = new Label();
            releaseLabel.SetBinding(Label.TextProperty, new Binding("CurrentVersionReleaseDate", stringFormat: "{0:yyyy-MM-dd}"));
            releaseLayout.Children.Add(releaseLabel);
            stackLayout.Children.Add(releaseLayout);

            stackLayout.Children.Add(new Label());

            stackLayout.Children.Add(new Label() { Text = "Downloads" });
            var totalDownloadLayout = new StackLayout() { Orientation = StackOrientation.Horizontal };
            totalDownloadLayout.Children.Add(new Label() { Text = "Total: " });
            var totalDownloadLabel = new Label();
            totalDownloadLabel.SetBinding(Label.TextProperty, new Binding("TotalDownloads", stringFormat: "{0}"));
            totalDownloadLayout.Children.Add(totalDownloadLabel);
            stackLayout.Children.Add(totalDownloadLayout);
            var currentDownloadLayout = new StackLayout() { Orientation = StackOrientation.Horizontal };
            currentDownloadLayout.Children.Add(new Label() { Text = "Current version: " });
            var currentDownloadLabel = new Label();
            currentDownloadLabel.SetBinding(Label.TextProperty, new Binding("CurrentVersionDownloads", stringFormat: "{0}"));
            currentDownloadLayout.Children.Add(currentDownloadLabel);
            stackLayout.Children.Add(currentDownloadLayout);

            stackLayout.Children.Add(new Label());

            stackLayout.Children.Add(new Label() { Text = "Authors:" });
            var authorsLabel = new Label();
            authorsLabel.SetBinding(Label.TextProperty, "Authors");
            stackLayout.Children.Add(authorsLabel);

            stackLayout.Children.Add(new Label());

            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
            this.Content = stackLayout;
        }
    }
}
