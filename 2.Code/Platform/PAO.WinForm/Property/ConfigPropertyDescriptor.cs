using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using PAO.WinForm.Editors;

namespace PAO.WinForm.Config
{
    /// <summary>
    /// 配置用的属性描述器
    /// 作者：PAO
    /// </summary>
    public class ConfigPropertyDescriptor : PropertyDescriptor
    {
        private PropertyDescriptor OrigionPropertyDescriptor;

        public override Type ComponentType {
            get {
                return OrigionPropertyDescriptor.ComponentType;
            }
        }

        public override bool IsReadOnly {
            get {
                return OrigionPropertyDescriptor.IsReadOnly;
            }
        }

        public override Type PropertyType {
            get {
                return OrigionPropertyDescriptor.PropertyType;
            }
        }

        public override bool CanResetValue(object component) {
            return OrigionPropertyDescriptor.CanResetValue(component);
        }

        public override object GetValue(object component) {
            return OrigionPropertyDescriptor.GetValue(component);
        }

        public override void ResetValue(object component) {
            OrigionPropertyDescriptor.ResetValue(component);
        }

        public override void SetValue(object component, object value) {
            OrigionPropertyDescriptor.SetValue(component, value);
        }

        public override bool ShouldSerializeValue(object component) {
            return OrigionPropertyDescriptor.ShouldSerializeValue(component);
        }

        string _DisplayName = null;
        public override string DisplayName {
            get {
                if (_DisplayName != null)
                    return _DisplayName;

                return OrigionPropertyDescriptor.DisplayName;
            }
        }

        string _Description = null;
        public override string Description {
            get {
                if (_Description != null)
                    return _Description;

                return OrigionPropertyDescriptor.Description;
            }
        }

        public BaseEditor Editor { get; set; }

        public ConfigPropertyDescriptor(PropertyDescriptor origionPropertyDescriptor) : base(origionPropertyDescriptor) {
            OrigionPropertyDescriptor = origionPropertyDescriptor;
            var propertyConfigInfo = WinFormPublic.GetPropertyConfigInfo(OrigionPropertyDescriptor.ComponentType, OrigionPropertyDescriptor.Name);
            if (propertyConfigInfo != null) {
                _DisplayName = propertyConfigInfo.DisplayName;
                _Description = propertyConfigInfo.Description;
                Editor = propertyConfigInfo.Editor;
            }
        }

        public ConfigPropertyDescriptor(PropertyDescriptor origionPropertyDescriptor, PropertyConfigInfo propertyConfigInfo) : base(origionPropertyDescriptor) {
            OrigionPropertyDescriptor = origionPropertyDescriptor;
            if (propertyConfigInfo != null) {
                _DisplayName = propertyConfigInfo.DisplayName;
                _Description = propertyConfigInfo.Description;
                Editor = propertyConfigInfo.Editor;
            }
        }
    }
}
