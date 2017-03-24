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
        /// <summary>
        /// Enum for Tags
        /// </summary>
        private enum Tags
        {
            RELEASE = 0,
            DEBUG = 1,
            INFO = 2,
            WARRING = 3,
            ERROR = 4
        }

        private enum Level
        {
            CONSOLE = 0,
            FILETXT = 1,
            FILEXML = 2,
            FILEHTML = 3,
            DATABASE = 4
        }


        /// <summary>
        /// Dictionary for StatusTags
        /// </summary>
        private static Dictionary<string, Tags> StatusTags = new Dictionary<string, Tags>
        {
            {"RELEASE",Tags.RELEASE},
            {"DEBUG",Tags.DEBUG},
            {"INFO",Tags.INFO},
            {"WARRING",Tags.WARRING},
            {"ERROR",Tags.ERROR}
        };

        //Variables
        private static SaveLoadString _instSaveLoadString;

        /// <summary>
        /// Construction
        /// </summary>
        static Logging()
        {
            _instSaveLoadString = new SaveLoadString();
        }


        public static void Debug(string message, int level = (int)Level.CONSOLE)
        {
            CheckLevelLoggin(SetTages(message, "DEBUG"), level);

            //WriteMessage(message, LogType.typeDebug, tag);
            //Log.Debug(tag, message);
        }

        public static void Info(string message, int level = (int)Level.CONSOLE)
        {
            CheckLevelLoggin(SetTages(message, "INFO"), level);
        }

        public static void Warring(string message, int level = (int)Level.CONSOLE)
        {
            CheckLevelLoggin(SetTages(message, "WARRING"), level);
        }

        public static void Error(string message, int level = (int)Level.CONSOLE)
        {
            CheckLevelLoggin(SetTages(message, "ERROR"), level);
        }

        public static void Log(string message, string tag = "DEBUG", int level = (int)Level.CONSOLE)
        {
            CheckLevelLoggin(SetTages(message, tag), level);
        }

        /// <summary>
        /// Method for Check level logging and writeline log message
        /// </summary>
        /// <param name="m"></param>
        /// <param name="level"></param>
        private static void CheckLevelLoggin(string m, int level)
        {
            switch (level)
            {
                case (int)Level.FILETXT:
                    FileTXTWriteMessage(m);
                    break;
                case (int)Level.FILEXML:
                    FileHTMLWriteMessage(m);
                    break;
                case (int)Level.FILEHTML:
                    FileHTMLWriteMessage(m);
                    break;
                case (int)Level.DATABASE:
                    DatabaseWriteMessage(m);
                    break;
                default:
                {
                    ConsoleWriteMessage(m);
                    break;
                }
            }
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
            string setMessage = m + "\n";
            _instSaveLoadString.SaveText(setMessage);
        }

        private static void FileXMLWriteMessage(string m)
        {

        }

        private static void FileHTMLWriteMessage(string m)
        {

        }

    }
}
