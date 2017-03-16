using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinWallet.Helpers
{
    public static class Logging
    {
        private enum Tags
        {
            RELEASE = 0,
            DEBUG = 1,
            INFO = 2,
            WARRING = 3,
            ERROR = 4
        }

        private static Dictionary<string, Tags> StatusTags = new Dictionary<string, Tags>
        {
            {"RELEASE",Tags.RELEASE},
            {"DEBUG",Tags.DEBUG},
            {"INFO",Tags.INFO},
            {"WARRING",Tags.WARRING},
            {"ERROR",Tags.ERROR}
        };

        /// <summary>
        /// Construction
        /// </summary>
        static Logging()
        {
        }


        public static void Debug(string message)
        {
            ConsoleWriteMessage(SetTages(message, "DEBUG"));

            //WriteMessage(message, LogType.typeDebug, tag);
            //Log.Debug(tag, message);
        }

        public static void Info(string message, string tag = "")
        {
            ConsoleWriteMessage(SetTages(message, "INFO"));
        }

        public static void Warring(string message, string tag = "")
        {
            ConsoleWriteMessage(SetTages(message, "WARRING"));
        }

        public static void Error(string message, string tag = "")
        {
            ConsoleWriteMessage(SetTages(message, "ERROR"));
        }

        /// <summary>
        /// Set new tag for message
        /// </summary>
        /// <param name="m"></param>
        /// <param name="tag"></param>
        /// <returns>message</returns>
        private static string SetTages(string m, string tag = "")
        {
            //variables
            string newMessage = string.Empty;
            Tags valueEnumType;

            StatusTags.TryGetValue(tag, out valueEnumType);
            switch (valueEnumType)
            {
                case Tags.RELEASE: //nothing It is release version.
                    return string.Empty;
                default:
                    {
                        newMessage = string.Format("{0}: {1}.", tag, m);
                        break;
                    }
            }

            return newMessage;
        }

        /// <summary>
        /// Write message on console only debug mode
        /// </summary>
        /// <param name="m"></param>
        private static void ConsoleWriteMessage(string m)
        {
            System.Diagnostics.Debug.WriteLine(m);
        }

        private static void DatabaseWriteMessage(string m)
        {

        }

        private static void FileTXTWriteMessage(string m)
        {

        }

        private static void FileXMLWriteMessage(string m)
        {

        }

        private static void FileHTMLWriteMessage(string m)
        {

        }

    }
}
