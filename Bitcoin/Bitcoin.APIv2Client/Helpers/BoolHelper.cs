﻿namespace Bitcoin.APIv2Client.Helpers
{
    public static class BoolHelper
    {
        public static bool ConvertIntToBool(this int value)
        {
            if (value == 0) return false;
            else return true;
        }
    }
}