﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OpenLogger.Analysis.Vehicle.Inputs.Transforms;

namespace OpenLogAnalyzer.Transforms
{
    public static class TransformEditors
    {
        private static Type _editorType = typeof(IEditInputTransforms);
        private static List<Type> _editorTypes;

        public static List<Type> EditorTypes
        {
            get
            {
                if (_editorTypes == null)
                {
                    var allTypes = Assembly.GetAssembly(typeof (TransformEditors)).GetTypes();
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

        public static IEditInputTransforms GetTransformEditor<T>(T transform) where T : class, IInputTransform
        {
            var transformType = transform.GetType();

            var editorType = _editorTypes.FirstOrDefault(e => e.GetInterfaces().Any(i => i.GenericTypeArguments.Length == 1 && i.GenericTypeArguments[0] == transformType));

            return editorType?.GetConstructors().FirstOrDefault()?.Invoke(new object[0]) as IEditInputTransforms;
        }
    }
}
