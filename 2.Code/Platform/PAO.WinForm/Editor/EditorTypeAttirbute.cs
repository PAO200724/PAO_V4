using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAO.WinForm.Editor
{
    /// <summary>
    /// 编辑器特性
    /// 作者：PAO
    /// </summary>
    [System.AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public sealed class EditorTypeAttribute : Attribute
    {
        public EditorTypeAttribute(Type editorType) {
            if (!editorType.IsDerivedFrom(typeof(BaseEditController)))
                throw new Exception("编辑器必须是BaseEditController的子类");
            this.EditorType = editorType;
        }

        public Type EditorType {
            get; private set;
        }
        
    }
}
