using System.Management.Instrumentation;

namespace OpenLogger.Core.Debugging
{
    public interface ILogger
    {
        void Info(string format, params object[] parameters);
        void Error(string format, params object[] parameters);
    }
    public static class Log
    {
        public static ILogger Instance { get; set; }

        public static void Info(string format, params object[] parameters)
        {
            if (Instance == null)
                throw new InstanceNotFoundException("Log.Instance has not been initialized!");

            Instance.Info(format, parameters);
        }

        public static void Error(string format, params object[] parameters)
        {
            if (Instance == null)
                throw new InstanceNotFoundException("Log.Instance has not been initialized!");

            Instance.Error(format, parameters);
        }
    }
}
