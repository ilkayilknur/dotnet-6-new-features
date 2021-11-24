using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGenerators
{
    public static partial class Log
    {
        [LoggerMessage(
            EventId = 0,
            Level = LogLevel.Critical,
            Message = "Could not open socket to `{hostName}`")]
        public static partial void CouldNotOpenSocket(
            ILogger logger, string hostName);
    }

    public partial class InstanceLoggingExample
    {
        private readonly ILogger _logger;

        public InstanceLoggingExample(ILogger logger)
        {
            _logger = logger;
        }

        [LoggerMessage(
            EventId = 0,
            Level = LogLevel.Critical,
            Message = "Could not open socket to `{hostName}`")]
        public partial void CouldNotOpenSocket(string hostName);
    }
}
