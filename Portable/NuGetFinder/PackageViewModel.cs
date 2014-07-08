using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuGetFinder
{
    public class PackageViewModel
    {
        public PackageViewModel()
        {
        }

        public PackageViewModel(Package source)
        {
            Id = source.Id;
            Title = source.Title;
            TotalDownloads = source.DownloadCount;
            CurrentVersion = source.Version;
            CurrentVersionReleaseDate = source.LastUpdated;
            CurrentVersionDownloads = source.VersionDownloadCount;
            Size = source.PackageSize;
            Authors = source.Authors;
            if (source.Dependencies != null)
                Dependencies = source.Dependencies.Replace("|", "\r\n");
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public int TotalDownloads { get; set; }
        public string CurrentVersion { get; set; }
        public DateTime CurrentVersionReleaseDate { get; set; }
        public int CurrentVersionDownloads { get; set; }
        public long Size { get; set; }
        public string Authors { get; set; }
        public string Dependencies { get; set; }

        public string ShortSummary
        {
            get
            {
                return string.Format("{0} {1} ({2}/{3})",
                    Title, CurrentVersion, FormatNumber(CurrentVersionDownloads), FormatNumber(TotalDownloads));
            }
        }

        public string CurrentVersionSummary
        {
            get
            {
                return string.Format("Version {0} ({1})", CurrentVersion, CurrentVersionReleaseDate.ToString("yyyy-MM-dd"));
            }
        }

        public string TotalDownloadSummary
        {
            get
            {
                return string.Format("{0} total downloads", TotalDownloads);
            }
        }

        public string VersionDownloadSummary
        {
            get
            {
                return string.Format("{0} downloads ({1})", CurrentVersionDownloads, CurrentVersion);
            }
        }

        public string FormatNumber(int number)
        {
            if (number < 1000)
                return number.ToString();
            if (number < 10000)
                return string.Format("{0}.{1}K", number / 1000, (number % 1000) / 100);
            if (number < 1000000)
                return string.Format("{0}K", number/1000);
            return string.Format("{0}.{1}M", number / 1000000, (number % 1000000) / 100000);
        }
    }
}
