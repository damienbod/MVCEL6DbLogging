
using System.Diagnostics.Tracing;

namespace MvcEL6Test.Logger
{
    [EventSource(Name = "BasicLogger")]
    public class BasicLogger : EventSource
    {
        public static readonly BasicLogger Log = new BasicLogger();

        /// <summary>
        /// Using Keywords
        /// The example includes a Keywords parameter for the Event attribute for many of the log methods. 
        /// You can use keywords to define different groups of log methods so that when you enable an event source, you can specify which groups of log methods to enable: 
        /// only log methods whose Keywords parameter matches one of the specified groups will be able to write log messages.
        /// You must define the keywords you will use in a nested class called Keywords as shown in the example. Each keyword value is a 64 bit integer, 
        /// which is treated as a bit array enabling you to define 64 different keywords. 
        /// You can associate a log method with multiple keywords as shown in the following example where the Failure message is associated with both the Diagnostic and Perf keywords.
        /// </summary>
        public class Keywords
        {
            public const EventKeywords Page = (EventKeywords)1;
            public const EventKeywords DataBase = (EventKeywords)2;
            public const EventKeywords Diagnostic = (EventKeywords)4;
            public const EventKeywords Perf = (EventKeywords)8;

            public const EventKeywords ControllerAction = (EventKeywords)16;
            public const EventKeywords DiagnosticStartStop = (EventKeywords)32;
        }

        /// <summary>
        /// Using Opcodes and Tasks
        /// 
        /// You can use the Opcodes and Tasks parameters of the Event attribute to add additional information to the message that the event source logs. 
        /// The Opcodes and Tasks are defined using nested classes of the same name in the same way that you define Keywords. The example event source includes two tasks: Page and DBQuery. 
        /// 
        /// #!SPOKENBY(Poe)!# The logs contain just the numeric task and opcode identifiers.
        /// The developers who write the EventSource class and IT Pros who use the logs must agree on the definitions of the tasks and opcodes used in the application. 
        /// Notice how in the sample, the task constants have meaningful names such as Page and DBQuery: these tasks appear in the logs as task ids 1 and 2 respectively.
        /// 
        /// If you choose to define custom opcodes, you should assign integer values of 11 or above. 
        /// If you define a custom opcode with a value of 10 or below, messages that use these opcodes will not be delivered.    
        /// </summary>
        public class Task
        {
            public const EventTask Page = (EventTask)1;
            public const EventTask DBQuery = (EventTask)2;
            public const EventTask AmazingTask = (EventTask)3;
        }

        public class Opcodes
        {
            public const EventOpcode Page = (EventOpcode)11;
            public const EventOpcode DBQuery = (EventOpcode)12;
        }

        //  Keyword value = 17 (16 + 1)
        [Event(1, Message = "{0}", Level = EventLevel.Error, Keywords = Keywords.ControllerAction | Keywords.Page)]
        public void ErrorWithKeywordsControllerActionAndKeywordsPage(string message)
        {
            if (IsEnabled()) WriteEvent(1, message);
        }

        //  Keyword value = 16
        [Event(4, Message = "{0}", Level = EventLevel.Error, Keywords = Keywords.ControllerAction)]
        public void ErrorWithKeywordsControllerAction(string message)
        {
            if (IsEnabled()) WriteEvent(4, message);
        }

        //  Keyword value = 32
        [Event(5, Message = "{0}", Level = EventLevel.Error, Keywords = Keywords.DiagnosticStartStop)]
        public void ErrorWithKeywordsDiagnosticStartStop(string message)
        {
            if (IsEnabled()) WriteEvent(5, message);
        }

        //  Keyword value = 0
        [Event(2, Message = "{0}", Level = EventLevel.Error)]
        public void ErrorWithNoKeywordsDefined(string message)
        {
            if (IsEnabled()) WriteEvent(2, message);
        }



        [Event(7, Message = "{0}", Level = EventLevel.Warning, Task= Task.Page)]
        public void WarningWithEventTaskPage(string message)
        {
            if (IsEnabled()) WriteEvent(7, message);
        }

        [Event(8, Message = "{0}", Level = EventLevel.Warning, Task = Task.AmazingTask)]
        public void WarningWithEventTaskAmazingTask(string message)
        {
            if (IsEnabled()) WriteEvent(8, message);
        }

        [Event(9, Message = "{0}", Level = EventLevel.Warning)]
        public void WarningWithNoEventTaskDefined(string message)
        {
            if (IsEnabled()) WriteEvent(9, message);
        }

        [Event(10, Message = "{0}", Level = EventLevel.Warning,Opcode=Opcodes.Page)]
        public void WarningWithOpcodePage(string message)
        {
            if (IsEnabled()) WriteEvent(10, message);
        }

       
    }
}