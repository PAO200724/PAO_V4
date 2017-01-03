using PAO;
using PAO.WinForm.Editor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;

namespace PAO.Config.Editor
{
    /// <summary>
    /// 类：CommonObjectEditController
    /// 通用对象编辑控制器
    /// 通用对象编辑控制器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("通用对象编辑控制器")]
    [Description("通用对象编辑控制器")]
    public class CommonObjectEditController : BaseObjectEditController
    {
        #region 插件属性
        #endregion

        [NonSerialized]
        private ObjectEditMode EditMode;
        [NonSerialized]
        private object ComponentObject;
        [NonSerialized]
        private object ElementKey;
        [NonSerialized]
        private Type ObjectType;
        
        public CommonObjectEditController() {
        }
        public CommonObjectEditController(bool staticType) : base(staticType) {
        }
        #region StartEditXXX
        public void StartEdit(ObjectEditMode editMode, Type objectType, object componentObject, object key) {
            EditMode = editMode;
            ObjectType = objectType;
            ComponentObject = componentObject;
            ElementKey = key;
        }

        public void StartEditNull() {
            StartEdit(ObjectEditMode.Object, null, null, null);
        }

        public void StartEditObject(Type objectType) {
            StartEdit(ObjectEditMode.Object, objectType, null, null);
        }

        public void StartEditProperty(object componentObject, string propertyName) {
            StartEdit(ObjectEditMode.Property, null, componentObject, propertyName);
        }

        public void StartEditListElement(object componentObject, int index) {
            StartEdit(ObjectEditMode.ListElement, null, componentObject, index);
        }

        public void StartEditDictionaryElement(object componentObject, object key) {
            StartEdit(ObjectEditMode.DictionaryElement, null, componentObject, key);
        }

        #endregion

        protected override Control OnCreateEditControl(Type objectType) {
            var editControl = new CommonObjectEditControl();
            editControl.StartEdit(EditMode, ObjectType, ComponentObject, ElementKey);
            return editControl;
        }


        public static new bool TypeFilter(Type type) {
            return type.IsAddon();
        }
    }
}
