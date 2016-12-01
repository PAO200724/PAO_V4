﻿using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO
{
    [System.AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, Inherited = true, AllowMultiple = false)]
    public class AddonAttribute : Attribute
    {
        /// <summary>
        /// 编辑器类型
        /// </summary>
        public Type EditorType { get; set; }
        public AddonAttribute() {

        }        
    }
}
