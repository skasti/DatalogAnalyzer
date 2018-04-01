using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using OpenLogger.Analysis.Analyses;

namespace OpenLogAnalyzer.Analyses
{
    public static class AnalysisEditors
    {
        private static Type _editorType = typeof(IEditDataAnalysis);
        private static List<Type> _editorTypes;

        public static List<Type> EditorTypes
        {
            get
            {
                if (_editorTypes == null)
                {
                    var allTypes = Assembly.GetAssembly(typeof (AnalysisEditors)).GetTypes();
                    var classes = allTypes.Where(t => t.IsClass);

                    var editorClasses = classes.Where(c => c.GetInterfaces().Contains(_editorType));

                    _editorTypes = editorClasses.ToList();
                }

                return _editorTypes;
            }
        }

        public static string GetEditorName(Type editorType)
        {
            var displayName = editorType.GetCustomAttributes<DisplayNameAttribute>().FirstOrDefault();

            if (displayName != null)
            {
                return displayName.DisplayName;
            }

            return editorType.Name;
        }

        public static string GetEditorDescription(Type editorType)
        {
            var description = editorType.GetCustomAttributes<DescriptionAttribute>().FirstOrDefault();

            return description?.Description;
        }

        public static IEditDataAnalysis GetAnalysisEditor<T>(T transform) where T : class, IDataAnalysis
        {
            var transformType = transform.GetType();

            var editorType = _editorTypes.FirstOrDefault(e => e.GetInterfaces().Any(i => i.GenericTypeArguments.Length == 1 && i.GenericTypeArguments[0] == transformType));

            return editorType?.GetConstructors().FirstOrDefault()?.Invoke(new object[0]) as IEditDataAnalysis;
        }
    }
}
