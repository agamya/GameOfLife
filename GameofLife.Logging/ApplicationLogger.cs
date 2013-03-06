

using GameOfLife.Logging;

namespace GameofLife.Logging
{
    #region Using Statements

    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using Microsoft.Practices.EnterpriseLibrary.Logging;


    #endregion

    /// <summary>
    /// This class provides a wrapper over Microsoft Logging Application 
    /// Block for doing logging in the application.
    /// </summary>
    public static class ApplicationLogger
    {
        #region Private Constants
        private const int MAX_EVENTLOG_STRING_LENGTH = 32750;
        #endregion Private Constants

        #region Private Methods

        /// <summary>
        /// This method is responsible for creating the LogEntry object setting the appropriate properties 
        /// and write the logEntry using Logger.Write() method.
        /// </summary>
        /// <param name="eventId">Id of the event. Based on which the message will be retrieved from some resource file.</param>
        /// <param name="message">Log message that needs to be logged.</param>
        /// <param name="logCategories">List of categories which will determine where the message will get logged.</param>
        /// <param name="severity">Severity of the message. (Information / Warning / Error)</param>
        /// <param name="extendedLogMessage">Extra parameters that need to be logged in.</param>
        private static void WriteLogEntry(int eventId, string message, ICollection<LogCategory> logCategories, TraceEventType severity, IDictionary<string, object> extendedLogMessage)
        {

            if (message != null)
            {
                message = string.Format(CultureInfo.InvariantCulture, "{0}{1}", GetMessageFromResource(eventId), message);

            }
            else
            {
                message = GetMessageFromResource(eventId);
            }

            var categories = logCategories.Select(category => category.ToString()).ToList();

            var logEntry = new LogEntry
                               {
                                   EventId = eventId,
                                   Categories = categories,
                                   Message = message,
                                   Priority = GetPriority(severity),
                                   Severity = severity
                                   //ExtendedProperties = extendedLogMessage
                               };
            logEntry.TimeStamp = logEntry.TimeStamp.ToLocalTime();

            Logger.Write(logEntry);

        }

        /// <summary>
        /// This method is responsible for returning the Priority
        /// associated with the severity of the log message.
        /// </summary>
        /// <param name="severity">Severity of the message. (Information / Warning / Error)</param>
        /// <returns>int: Priority of the message.</returns>
        private static int GetPriority(TraceEventType severity)
        {
            int priority = 0;
            switch (severity)
            {
                case TraceEventType.Error:
                    priority = 1;
                    break;
                case TraceEventType.Warning:
                    priority = 3;
                    break;
                case TraceEventType.Information:
                    priority = 5;
                    break;
            }
            return priority;
        }

        /// <summary>
        /// This method is used to retrieve the message
        /// associated with an eventID from the resource file.
        /// </summary>
        /// <param name="eventId">ID of the event.</param>
        /// <returns>string: Message associated with the eventId.</returns>
        private static string GetMessageFromResource(int eventId)
        {
            var resourceKey = string.Format(CultureInfo.InvariantCulture, "EVENT_{0}", eventId.ToString(CultureInfo.InvariantCulture));
            var message = Resources.ResourceManager.GetString(resourceKey);
            return message;
        }

        #endregion Private Methods

        #region Public Methods

        #region LogMessage

        /// <summary>
        /// This method is used to Log any message in the Application.
        /// </summary>
        /// <param name="eventId">Id of the event. Based on which the message will be retrieved from resource file.</param>
        /// <param name="category">List of categories which will determine where the message will get logged.</param>
        /// <param name="severity">Severity of the message. (Information / Warning / Error)</param>
        public static void LogMessage(int eventId, LogCategory category, TraceEventType severity)
        {
            try
            {
                var categories = new List<LogCategory> { category };

                WriteLogEntry(eventId, null, categories, severity, null);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// This method is used to Log any message in the Application.
        /// </summary>
        /// <param name="eventId">Id of the event. Based on which the message will be retrieved from resource file.</param>
        /// <param name="category">List of categories which will determine where the message will get logged.</param>
        /// <param name="severity">Severity of the message. (Information / Warning / Error)</param>
        /// <param name="source">Source of the log message. E.g. MIIS, Web Service, etc.</param>
        public static void LogMessage(int eventId, LogCategory category, TraceEventType severity, Source source)
        {
            try
            {
                var categories = new List<LogCategory> { category };

                var extendedInformation = new Dictionary<string, object> { { "Source", Convert.ToInt32(source, CultureInfo.InvariantCulture) } };

                WriteLogEntry(eventId, String.Empty, categories, severity, extendedInformation);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// This method is used to Log any message in the Application.
        /// </summary>
        /// <param name="eventId">Id of the event. Based on which the message will be retrieved from resource file.</param>
        /// <param name="message">Some extra information / message that user will like to log.</param>
        /// <param name="category">A category which will determine where the message will get logged.</param>
        /// <param name="severity">Severity of the message. (Information / Warning / Error)</param>
        public static void LogMessage(int eventId, string message, LogCategory category, TraceEventType severity)
        {
            try
            {
                var categories = new List<LogCategory> { category };

                var extendedInformation = new Dictionary<string, object>();

                WriteLogEntry(eventId, message, categories, severity, extendedInformation);
            }
            catch
            {
            }
        }

        /// <summary>
        /// This method is used to Log any message in the Application.
        /// </summary>
        /// <param name="eventId">Id of the event. Based on which the message will be retrieved from resource file.</param>
        /// <param name="message">Some extra information / message that user will like to log.</param>
        /// <param name="category">A category which will determine where the message will get logged.</param>
        /// <param name="severity">Severity of the message. (Information / Warning / Error)</param>
        /// <param name="source">Source of the log message. E.g. MIIS, Web Service, etc.</param>
        public static void LogMessage(int eventId, string message, LogCategory category, TraceEventType severity, Source source)
        {
            try
            {
                var categories = new List<LogCategory> { category };

                var extendedInformation = new Dictionary<string, object> { { "Source", Convert.ToInt32(source, CultureInfo.InvariantCulture) } };

                WriteLogEntry(eventId, message, categories, severity, extendedInformation);
            }
            catch
            {
            }
        }

        /// <summary>
        /// This method is used to Log any message in the Application.
        /// </summary>
        /// <param name="eventId">Id of the event. Based on which the message will be retrieved from resource file.</param>
        /// <param name="requestId">ID of the request related to which log message is logged.</param>
        /// <param name="actionPerformedBy">Alias of the user who logged this message.</param>
        /// <param name="category">A category which will determine where the message will get logged.</param>
        /// <param name="severity">Severity of the message. (Information / Warning / Error)</param>
        public static void LogMessage(int eventId, Guid requestId, string actionPerformedBy, LogCategory category, TraceEventType severity)
        {
            try
            {
                var categories = new List<LogCategory> { category };

                var extendedInformation = new Dictionary<string, object> { { "RequestID", requestId }, { "ActorAlias", actionPerformedBy } };

                WriteLogEntry(eventId, null, categories, severity, extendedInformation);
            }
            catch
            {
            }
        }

        /// <summary>
        /// This method is used to Log any message in the Application.
        /// </summary>
        /// <param name="eventId">Id of the event. Based on which the message will be retrieved from resource file.</param>
        /// <param name="requestId">ID of the request related to which log message is logged.</param>
        /// <param name="message">Some extra information / message that user will like to log.</param>
        /// <param name="category">A category which will determine where the message will get logged.</param>
        /// <param name="severity">Severity of the message. (Information / Warning / Error)</param>
        /// <param name="source">Source of the log message. E.g. MIIS, Web Service, etc.</param>
        public static void LogMessage(int eventId, Guid requestId, string message, LogCategory category, TraceEventType severity, Source source)
        {
            try
            {
                var categories = new List<LogCategory>();
                categories.Add(category);

                var extendedInformation = new Dictionary<string, object>
                                              {
                                                  {"RequestID", requestId},
                                                  {"Source", Convert.ToInt32(source, CultureInfo.InvariantCulture)}
                                              };

                WriteLogEntry(eventId, message, categories, severity, extendedInformation);
            }
            catch
            {
            }
        }

        /// <summary>
        /// This method is used to Log any message in the Application.
        /// </summary>
        /// <param name="eventId">Id of the event. Based on which the message will be retrieved from resource file.</param>
        /// <param name="actionPerformedBy">Alias of the user who logged this message.</param>
        /// <param name="message">Some extra information / message that user will like to log.</param>
        /// <param name="category">A category which will determine where the message will get logged.</param>
        /// <param name="severity">Severity of the message. (Information / Warning / Error)</param>
        /// <param name="source">Source of the log message. E.g. MIIS, Web Service, etc.</param>
        public static void LogMessage(int eventId, string actionPerformedBy, string message, LogCategory category, TraceEventType severity, Source source)
        {
            try
            {
                var categories = new List<LogCategory> { category };

                var extendedInformation = new Dictionary<string, object>
                                              {
                                                  {"ActorAlias", actionPerformedBy},
                                                  {"Source", Convert.ToInt32(source, CultureInfo.InvariantCulture)}
                                              };

                WriteLogEntry(eventId, message, categories, severity, extendedInformation);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// This method is used to Log any message in the Application.
        /// </summary>
        /// <param name="eventId">Id of the event. Based on which the message will be retrieved from resource file.</param>
        /// <param name="requestId">ID of the request related to which log message is logged.</param>
        /// <param name="actionPerformedBy">Alias of the user who logged this message.</param>
        /// <param name="message">Some extra information / message that user will like to log.</param>
        /// <param name="category">A category which will determine where the message will get logged.</param>
        /// <param name="severity">Severity of the message. (Information / Warning / Error)</param>
        public static void LogMessage(int eventId, Guid requestId, string actionPerformedBy, string message, LogCategory category, TraceEventType severity)
        {
            try
            {
                var categories = new List<LogCategory> { category };

                var extendedInformation = new Dictionary<string, object> { { "RequestID", requestId }, { "ActorAlias", actionPerformedBy } };

                WriteLogEntry(eventId, message, categories, severity, extendedInformation);
            }
            catch (Exception)
            {
            }
        }


        #endregion LogMessage

        #region LogException

        /// <summary>
        /// This method is used to Log any message in the Application.
        /// </summary>
        /// <param name="eventId">Id of the event. Based on which the message will be retrieved from resource file.</param>
        /// <param name="ex">Exception object that needs to be logged in.</param>
        /// <param name="category">a category which will determine where the message will get logged.</param>
        /// <param name="severity">Severity of the message. (Information / Warning / Error)</param>
        public static void LogException(int eventId, Exception ex, LogCategory category, TraceEventType severity)
        {
            try
            {
                var categories = new List<LogCategory> { category };

                var extendedInformation = new Dictionary<string, object> { { "Exception", ex } };

                WriteLogEntry(eventId, ex.Message + " StackTrace : " + ex.StackTrace, categories, severity, null);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// This method is used to Log any message in the Application.
        /// </summary>
        /// <param name="eventId">Id of the event. Based on which the message will be retrieved from resource file.</param>
        /// <param name="ex">Exception object that needs to be logged in.</param>
        /// <param name="message">Some extra information / message that user will like to log.</param>
        /// <param name="category">A category which will determine where the message will get logged.</param>
        /// <param name="severity">Severity of the message. (Information / Warning / Error)</param>
        public static void LogException(int eventId, Exception ex, string message, LogCategory category, TraceEventType severity)
        {
            try
            {
                var categories = new List<LogCategory> { category };

                var extendedInformation = new Dictionary<string, object> { { "Exception", ex } };

                if (string.IsNullOrEmpty(message))
                {
                    message = ex.Message + " - Stack Trace : " + ex.StackTrace;
                }
                else
                {
                    message = message + " - " + ex.Message + " - Stack Trace : " + ex.StackTrace;
                    if (message.Length > MAX_EVENTLOG_STRING_LENGTH)
                        message = message.Substring(0, MAX_EVENTLOG_STRING_LENGTH);
                }

                WriteLogEntry(eventId, message, categories, severity, extendedInformation);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// This method is used to Log any message in the Application.
        /// </summary>
        /// <param name="eventId">Id of the event. Based on which the message will be retrieved from resource file.</param>
        /// <param name="ex">Exception object that needs to be logged in.</param>        
        /// <param name="message">Some extra information / message that user will like to log.</param>
        /// <param name="category">A category which will determine where the message will get logged.</param>
        /// <param name="severity">Severity of the message. (Information / Warning / Error)</param>
        /// <param name="source">Source of the log message. E.g. MIIS, Web Service, etc.</param>
        public static void LogException(int eventId, Exception ex, string message, LogCategory category, TraceEventType severity, Source source)
        {
            try
            {
                var categories = new List<LogCategory> { category };

                var extendedInformation = new Dictionary<string, object>
                                              {
                                                  {"Source", Convert.ToInt32(source, CultureInfo.InvariantCulture)},
                                                  {"Exception", ex}
                                              };

                if (string.IsNullOrEmpty(message))
                {
                    message = ex.Message;
                }
                else
                {
                    if (message.Length > MAX_EVENTLOG_STRING_LENGTH)
                        message = message.Substring(0, MAX_EVENTLOG_STRING_LENGTH);
                }

                WriteLogEntry(eventId, message, categories, severity, extendedInformation);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// This method is used to Log any message in the Application.
        /// </summary>
        /// <param name="eventId">Id of the event. Based on which the message will be retrieved from resource file.</param>
        /// <param name="ex">Exception object that needs to be logged in.</param>
        /// <param name="requestId">ID of the request related to which log message is logged.</param>
        /// <param name="actionPerformedBy">Alias of the user who logged this message.</param>
        /// <param name="category">A category which will determine where the message will get logged.</param>
        /// <param name="severity">Severity of the message. (Information / Warning / Error)</param>
        public static void LogException(int eventId, Exception ex, Guid requestId, string actionPerformedBy, LogCategory category, TraceEventType severity)
        {
            try
            {
                var categories = new List<LogCategory> { category };

                var extendedInformation = new Dictionary<string, object>
                                              {
                                                  {"RequestID", requestId},
                                                  {"ActorAlias", actionPerformedBy},
                                                  {"Exception", ex}
                                              };

                WriteLogEntry(eventId, ex.Message, categories, severity, extendedInformation);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// This method is used to Log any message in the Application.
        /// </summary>
        /// <param name="eventId">Id of the event. Based on which the message will be retrieved from resource file.</param>
        /// <param name="ex">Exception object that needs to be logged in.</param>
        /// <param name="requestId">ID of the request related to which log message is logged.</param>
        /// <param name="message">Some extra information / message that user will like to log.</param>
        /// <param name="category">A category which will determine where the message will get logged.</param>
        /// <param name="severity">Severity of the message. (Information / Warning / Error)</param>
        /// <param name="source">Source of the log message. E.g. MIIS, Web Service, etc.</param>
        public static void LogException(int eventId, Exception ex, Guid requestId, string message, LogCategory category, TraceEventType severity, Source source)
        {
            try
            {
                var categories = new List<LogCategory> { category };

                var extendedInformation = new Dictionary<string, object>
                                              {
                                                  {"RequestID", requestId},
                                                  {"Source", Convert.ToInt32(source, CultureInfo.InvariantCulture)},
                                                  {"Exception", ex}
                                              };

                if (string.IsNullOrEmpty(message))
                {
                    message = ex.Message;
                }
                else
                {
                    if (message.Length > MAX_EVENTLOG_STRING_LENGTH)
                        message = message.Substring(0, MAX_EVENTLOG_STRING_LENGTH);
                }


                WriteLogEntry(eventId, message, categories, severity, extendedInformation);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// This method is used to Log any message in the Application.
        /// </summary>
        /// <param name="eventId">Id of the event. Based on which the message will be retrieved from resource file.</param>
        /// <param name="ex">Exception object that needs to be logged in.</param>
        /// <param name="requestId">ID of the request related to which log message is logged.</param>
        /// <param name="actionPerformedBy">Alias of the user who logged this message.</param>
        /// <param name="message">Some extra information / message that user will like to log.</param>
        /// <param name="category">A category which will determine where the message will get logged.</param>
        /// <param name="severity">Severity of the message. (Information / Warning / Error)</param>
        public static void LogException(int eventId, Exception ex, Guid requestId, string actionPerformedBy, string message, LogCategory category, TraceEventType severity)
        {
            try
            {
                var categories = new List<LogCategory> { category };

                var extendedInformation = new Dictionary<string, object>
                                              {
                                                  {"RequestID", requestId},
                                                  {"ActorAlias", actionPerformedBy},
                                                  {"Exception", ex}
                                              };

                if (string.IsNullOrEmpty(message))
                {
                    message = ex.Message;
                }
                else
                {
                    if (message.Length > MAX_EVENTLOG_STRING_LENGTH)
                        message = message.Substring(0, MAX_EVENTLOG_STRING_LENGTH);
                }

                WriteLogEntry(eventId, message, categories, severity, extendedInformation);
            }
            catch (Exception)
            {
            }
        }

        #endregion LogException

        #endregion Public Methods

    }
}
