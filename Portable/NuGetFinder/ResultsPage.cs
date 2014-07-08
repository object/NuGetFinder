using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NuGetFinder
{
    public class ResultsPage : ContentPage
    {
        public ResultsPage(IEnumerable<Package> packages)
        {
            Title = "Search Results";

            NavigationPage.SetHasNavigationBar(this, true);

            var stackLayout = new StackLayout() { VerticalOptions = LayoutOptions.FillAndExpand };

            if (Device.OS == TargetPlatform.WinPhone)
            {
                // WinPhone doesn't have the title showing
                stackLayout.Children.Add(new Label { Text = Title, Font = Font.SystemFontOfSize(50) });
            }

            var results = packages.Select(x => new PackageViewModel(x));
            var resultList = new ListView()
            {
                ItemsSource = results,
                ItemTemplate = new DataTemplate(() =>
                {
                    var itemList = new Label()
                    {
                        Font = Font.SystemFontOfSize(NamedSize.Medium),
                    };
                    itemList.SetBinding(Label.TextProperty, "ShortSummary");

                    return new ViewCell()
                    {
                        View = new StackLayout()
                        {
                            Padding = new Thickness(5, 5),
                            Orientation = StackOrientation.Vertical,
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            Children =
                            {
                                itemList,
                            },
                        },
                    };
                }),
            };
            resultList.ItemSelected += (sender, e) =>
            {
                var package = (PackageViewModel)e.SelectedItem;
                var detailsPage = new DetailsPage();
                detailsPage.BindingContext = package;
                Navigation.PushAsync(detailsPage);
            };
            stackLayout.Children.Add(resultList);

            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
            this.Content = stackLayout;
        }
    }
}
