using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace DatalogAnalyzer
{
    interface ILogger
    {
        void Info(string format, params object[] parameters);
        void Error(string format, params object[] parameters);
    }
    static class Log
    {
        private static ILogger _instance;

        public static ILogger Instance
        {
            get { return _instance; }
            set { _instance = value; }
        }

        public static void Info(string format, params object[] parameters)
        {
            if (_instance == null)
                throw new InstanceNotFoundException("Log.Instance has not been initialized!");

            Instance.Info(format, parameters);
        }

        public static void Error(string format, params object[] parameters)
        {
            if (_instance == null)
                throw new InstanceNotFoundException("Log.Instance has not been initialized!");

            Instance.Error(format, parameters);
        }
    }
}
