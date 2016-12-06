﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PAO;

namespace PAO.UI.MVC
{
    /// <summary>
    /// 类：FunctionItem
    /// 功能项
    /// 功能项
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("功能项")]
    [Description("功能项")]
    public class MenuItem : UIItem, IMenuItem
    {
        #region 插件属性

        #region 属性：ChildItems
        /// <summary>
        /// 属性：ChildItems
        /// 子菜单
        /// 子菜单列表
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("子菜单")]
        [Description("子菜单列表")]
        public List<Ref<IUIItem>> ChildItems {
            get;
            set;
        }

        #endregion 属性：ChildMenuItems

        #endregion
        public MenuItem() {
        }

        public IEnumerable<IUIItem> ChildMenuItems {
            get {
                if (ChildItems == null)
                    return null;

                return ChildItems.Select(p => p.Value).ToList();
            }
        }
    }
}
