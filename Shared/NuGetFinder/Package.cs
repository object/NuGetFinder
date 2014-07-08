using System;

namespace NuGetFinder
{
    public class Package
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Version { get; set; }
        public bool IsLatestVersion { get; set; }
        public DateTime LastUpdated { get; set; }
        public int DownloadCount { get; set; }
        public int VersionDownloadCount { get; set; }
        public long PackageSize { get; set; }
        public string Authors { get; set; }
        public string Dependencies { get; set; }
    }
}