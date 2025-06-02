using System;
using System.Collections.Generic;
using System.Text;
using Expanded.DBase.Models;
using Xamarin.Forms;
using System.Reflection;

namespace BitcoinWallet.Helpers
{
    public static class Logging
    {
        /// <summary>
        /// Enum for Tags is type message
        /// </summary>
        public enum Tags
        {
            RELEASE = 0,
            DEBUG = 1,
            INFO = 2,
            WARNING = 3,
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

        //Variables
        private static SaveLoadString _instSaveLoadString;
        private static LogItem _item;

        public static bool ReleaseTag { get; set; }
        public static Tags CurrentTag { get; set; }

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
        public static void Debug(string message, Level level = Level.CONSOLE)
        {
            CurrentTag = Tags.DEBUG;

            if (level == Level.DATABASE)
            {
                _item = SetNewLogItem(message, Tags.DEBUG);
                CheckLevelLoggin(string.Empty, level);
            }
            else
                CheckLevelLoggin(SetTages(message, Tags.DEBUG), level);
        }

        /// <summary>
        /// Method for info logging
        /// </summary>
        /// <param name="message">Specifis string about status here.</param>
        /// <param name="level">Specific params 0=console, 1=txt, 2=xml, 3=hmtl and 4=databse</param>
        public static void Info(string message, Level level = Level.CONSOLE)
        {
            CurrentTag = Tags.INFO;
            CheckLevelLoggin(SetTages(message, Tags.INFO), level);
        }

        /// <summary>
        /// Method for warring logging
        /// </summary>
        /// <param name="message">Specifis string about status here.</param>
        /// <param name="level">Specific params 0=console, 1=txt, 2=xml, 3=hmtl and 4=databse</param>
        public static void Warning(string message, Level level = Level.CONSOLE)
        {
            CurrentTag = Tags.WARNING;
            CheckLevelLoggin(SetTages(message, Tags.WARNING), level);
        }

        /// <summary>
        /// Method for error logging
        /// </summary>
        /// <param name="message">Specifis string about status here.</param>
        /// <param name="level">Specific params 0=console, 1=txt, 2=xml, 3=hmtl and 4=databse</param>
        public static void Error(string message, Level level = Level.CONSOLE)
        {
            CurrentTag = Tags.ERROR;
            CheckLevelLoggin(SetTages(message, Tags.ERROR), level);
        }

        /// <summary>
        /// Method for error logging
        /// </summary>
        /// <param name="message">Specifis string about status here.</param>
        /// <param name="level">Specific params 0=console, 1=txt, 2=xml, 3=hmtl and 4=databse</param>
        public static void Error(string message, Exception exception ,object objectImprint, Level level = Level.CONSOLE)
        {
            CurrentTag = Tags.ERROR;
            CheckLevelLoggin(SetTages(message, Tags.ERROR, exception, objectImprint), level);
        }

        /// <summary>
        /// Method for general logging
        /// </summary>
        /// <param name="message">Specifis string about status here.</param>
        /// <param name="level">Specific params 0=console, 1=txt, 2=xml, 3=hmtl and 4=databse</param>
        public static void Log(string message, Tags tag = Tags.DEBUG, Level level = Level.CONSOLE)
        {
            CurrentTag = Tags.DEBUG;
            CheckLevelLoggin(SetTages(message, tag), level);
        }

        /// <summary>
        /// Method for Check level logging and writeline log message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="level"></param>
        private static void CheckLevelLoggin(string message, Level level)
        {
            if(ReleaseTag && CurrentTag >= Tags.WARNING)
            {
                MakeLog(message, level);
            }
            else if (!ReleaseTag)
            {
                MakeLog(message, level);
            }
            else
            {
                //nothing because ReleaseTag = true an CurrentTag not Error or Warring
            }

        }

        private static void MakeLog(string message, Level level)
        {
            switch (level)
            {
                case Level.FILETXT:
                    FileTXTWriteMessage(message);
                    break;
                case Level.FILEXML:
                    FileXMLWriteMessage(message);
                    break;
                case Level.FILEHTML:
                    FileHTMLWriteMessage(message);
                    break;
                case Level.DATABASE:
                    DatabaseWriteMessage();
                    break;
                case Level.CONSOLE:
                    ConsoleWriteMessage(message);
                    break;
                default: throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Set new tag for message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="tag"></param>
        /// <param name="exception"></param>
        /// <param name="memoryPrint"></param>
        /// <returns>message</returns>
        private static string SetTages(string message, Tags tag, Exception exception = null, object memoryPrint = null)
        {
            return $"{tag}: {message} {ParseException(exception)} {ParseObject(memoryPrint)}";
        }

        /// <summary>
        /// Parses object through
        /// </summary>
        /// <param name="memoryPrint"></param>
        /// <returns></returns>
        private static string ParseObject(object memoryPrint)
        {
            Type objectType = memoryPrint.GetType();
            StringBuilder sb = new StringBuilder($"{objectType.FullName} {Environment.NewLine}");
            var properties = objectType.GetRuntimeFields();
            foreach (var item in properties)
            {
                object value = item.GetValue(memoryPrint);
                if (value != null)
                {
                    sb.AppendFormat("{0} = {1} {2}", item.Name, value.ToString(), Environment.NewLine);
                }
                else
                {
                    sb.AppendFormat("{0} = {1} {2}", item.Name, "null", Environment.NewLine);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Parses Exception and stackTrace to human readeable format
        /// </summary>
        /// <param name="exception"><see cref="Exception"/></param>
        /// <returns>Parsed exception or <see cref="String.Empty"/> if exception is null</returns>
        private static object ParseException(Exception exception)
        {
            if (exception == null)
            {
                return string.Empty;
            }

            return exception.ToString();
        }

        /// <summary>
        /// Write message on console only debug mode
        /// </summary>
        /// <param name="message"></param>
        private static void ConsoleWriteMessage(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }

        /// <summary>
        /// Inner Method for new LogItem
        /// </summary>
        /// <param name="message"></param>
        /// <param name="tag"></param>
        /// <returns>New LogItem</returns>
        private static LogItem SetNewLogItem(string message, Tags tag)
        {
            if (message.Length > 100)
            {
                message = message.Substring(0, 100);
            }

            return new LogItem
            {
                Id = App.Database.PropertyLogSpec.GenerLastIndex(),
                TraceLevel = tag.ToString(),
                Message = message,
                Date = DateTime.Today.ToString(),
                Platform = Device.OS.ToString(),
                Class = Application.Current.ClassId,
                Method =  "NULL",
                Line = 0
            };
        }

        private static void DatabaseWriteMessage()
        {
            if(_item != null)
                App.Database.PropertyLogSpec.SaveItem(_item);
        }

        private static void FileTXTWriteMessage(string message)
        {
            _instSaveLoadString.SaveText($"{message}{Environment.NewLine}");
        }

        private static void FileXMLWriteMessage(string message)
        {
            throw new NotImplementedException();
        }

        private static void FileHTMLWriteMessage(string message)
        {
            throw new NotImplementedException();
        }

    }
}
