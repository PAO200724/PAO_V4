using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAO
{
    /// <summary>
    /// 编辑器特性
    /// 作者：PAO
    /// </summary>
    [System.AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public sealed class EditorTypeAttribute : Attribute
    {
        public EditorTypeAttribute(Type editorType) {
            this.EditorType = editorType;
        }

        public EditorTypeAttribute(string editorTypeName) {
            this.EditorType = ReflectionPublic.GetType(editorTypeName);
        }

        public Type EditorType {
            get; private set;
        }
        
    }
}
