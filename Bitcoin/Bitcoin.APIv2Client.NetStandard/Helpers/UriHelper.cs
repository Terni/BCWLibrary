using System;

namespace Bitcoin.APIv2Client.NetStandard.Helpers
{
    public static class UriHelper
    {
        public static Uri ConverttoUri(this string value)
        {
            return new Uri(value);
        }
    }
}