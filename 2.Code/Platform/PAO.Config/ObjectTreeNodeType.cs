using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAO.Config
{
    /// <summary>
    /// 类：ObjectTreeNodeType
    /// 对象树节点类型
    /// 作者：PAO
    /// </summary>
    [Flags]
    public enum ObjectTreeNodeType
    {
        Object, // 对象
        ObjectProperty, // 属性
        ListProperty,   // 列表属性
        DictionaryProperty, // 字典属性
        ListElement,   //列表
        DictionaryElement // 字典
    }
}
