using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PAO
{
    /// <summary>
    /// 名称Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
    public class NameAttribute : DisplayNameAttribute
    {
        public NameAttribute() {

        }

        public NameAttribute(string displayName) : base(displayName) {

        }
    }
}
