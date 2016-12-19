using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAO.Config.EditControls
{
    /// <summary>
    /// 对象编辑模式
    /// </summary>
    public enum ObjectEditMode
    {
        Object,             // 对象直接编辑
        Property,           // 属性编辑
        ListElement,        // 列表元素编辑
        DictionaryElement,  // 字典元素编辑
    }
}
