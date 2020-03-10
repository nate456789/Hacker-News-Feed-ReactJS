using System;

namespace Hacker_News_Feed.Utility
{
    public static class ExtensionMethods
    {
        public static string FindElapseTime(this DateTimeOffset pub)
        {
            var diff = DateTime.Now - pub;
            if (diff.TotalMinutes < 60)
            {
                return $"{diff.Minutes} minutes ago";
            }
            else if (diff.TotalMinutes >= 60 && diff.TotalMinutes < 120)
            {
                return $"{diff.Hours} hour ago";
            }

            return $"{diff.Hours} hours ago";
        }
    }
}