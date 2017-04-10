using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Bluetooth;
using Expanded.DBase.ViewModels;
using Expanded.DBase.Models;
using Xamarin.Forms;

namespace BitcoinWallet.Helpers
{
    public static class Logging
    {
        /// <summary>
        /// Enum for Tags is type message
        /// </summary>
        private enum Tags
        {
            RELEASE = 0,
            DEBUG = 1,
            INFO = 2,
            WARRING = 3,
            ERROR = 4
        }

        /// <summary>
        /// Enum for Level is diferent out file or console or database
        /// </summary>
        public enum Level
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
        private static LogItem _item;

        public static bool ReleaseTag { get; set; }
        public static int CurrentTag { get; set; }

        /// <summary>
        /// Construction
        /// </summary>
        static Logging()
        {
            _instSaveLoadString = new SaveLoadString();
        }

        /// <summary>
        /// Method for debug logging
        /// </summary>
        /// <param name="message">Specifis string about status here.</param>
        /// <param name="level">Specific params 0=console, 1=txt, 2=xml, 3=hmtl and 4=databse</param>
        public static void Debug(string message, int level = (int)Level.CONSOLE)
        {
            CurrentTag = (int)Tags.DEBUG;

            if (level == (int)Level.DATABASE)
            {
                _item = SetNewLogItem(message, "DEBUG");
                CheckLevelLoggin(string.Empty, level);
            }
            else
                CheckLevelLoggin(SetTages(message, "DEBUG"), level);
        }

        /// <summary>
        /// Method for info logging
        /// </summary>
        /// <param name="message">Specifis string about status here.</param>
        /// <param name="level">Specific params 0=console, 1=txt, 2=xml, 3=hmtl and 4=databse</param>
        public static void Info(string message, int level = (int)Level.CONSOLE)
        {
            CurrentTag = (int)Tags.INFO;
            CheckLevelLoggin(SetTages(message, "INFO"), level);
        }

        /// <summary>
        /// Method for warring logging
        /// </summary>
        /// <param name="message">Specifis string about status here.</param>
        /// <param name="level">Specific params 0=console, 1=txt, 2=xml, 3=hmtl and 4=databse</param>
        public static void Warring(string message, int level = (int)Level.CONSOLE)
        {
            CurrentTag = (int)Tags.WARRING;
            CheckLevelLoggin(SetTages(message, "WARRING"), level);
        }

        /// <summary>
        /// Method for error logging
        /// </summary>
        /// <param name="message">Specifis string about status here.</param>
        /// <param name="level">Specific params 0=console, 1=txt, 2=xml, 3=hmtl and 4=databse</param>
        public static void Error(string message, int level = (int)Level.CONSOLE)
        {
            CurrentTag = (int)Tags.ERROR;
            CheckLevelLoggin(SetTages(message, "ERROR"), level);
        }

        /// <summary>
        /// Method for general logging
        /// </summary>
        /// <param name="message">Specifis string about status here.</param>
        /// <param name="level">Specific params 0=console, 1=txt, 2=xml, 3=hmtl and 4=databse</param>
        public static void Log(string message, string tag = "DEBUG", int level = (int)Level.CONSOLE)
        {
            CurrentTag = (int)Tags.DEBUG;
            CheckLevelLoggin(SetTages(message, tag), level);
        }

        /// <summary>
        /// Method for Check level logging and writeline log message
        /// </summary>
        /// <param name="m"></param>
        /// <param name="level"></param>
        private static void CheckLevelLoggin(string m, int level)
        {
            if(ReleaseTag && CurrentTag > 2)
            {
                MakeLog(m, level);
            }
            else if (!ReleaseTag)
            {
                MakeLog(m, level);
            }
            else
            {
                //nothing because ReleaseTag = true an CurrentTag not Error or Warring
            }

        }


        private static void MakeLog(string m, int level)
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
                    DatabaseWriteMessage();
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
            string newMessage = string.Format("{0}: {1}.", tag, m);
            Tags valueEnumType;

            StatusTags.TryGetValue(tag, out valueEnumType);
            switch (valueEnumType)
            {
                case Tags.ERROR:
                case Tags.WARRING:
                case Tags.INFO:
                case Tags.DEBUG:
                default:
                    {
                        return newMessage;
                    }
            }
        }

        /// <summary>
        /// Write message on console only debug mode
        /// </summary>
        /// <param name="m"></param>
        private static void ConsoleWriteMessage(string m)
        {
            System.Diagnostics.Debug.WriteLine(m);
        }

        /// <summary>
        /// Inner Method for new LogItem
        /// </summary>
        /// <param name="m"></param>
        /// <param name="tag"></param>
        /// <returns>New LogItem</returns>
        private static LogItem SetNewLogItem(string m, string tag)
        {
            return new LogItem
            {
                //Id = 1,
                TraceLevel = tag,
                Message = m,
                Date = DateTime.Today.ToString(),
                Platform = Device.OS.ToString(),
                Class = Application.Current.ClassId,
                Method = "NULL",
                Line = 0
            };
        }

        private static void DatabaseWriteMessage()
        {
            if(_item != null)
                App.Database.PropertyLogSpec.SaveItem(_item);
                //App.Database.PropertyLog.SaveItem(_item);
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
