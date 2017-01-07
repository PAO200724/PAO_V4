using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PAO;

namespace PAO.Config.Editor
{
    /// <summary>
    /// 类：PredefinedEditors
    /// 预定义编辑器
    /// 预定义的编辑器类型列表
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("预定义编辑器")]
    [Description("预定义的编辑器类型列表")]
    public class PredefinedEditors : PaoObject
    {
        #region 插件属性

        #region 属性：PredefinedEditorTypes
        /// <summary>
        /// 属性：PredefinedEditorTypes
        /// 预定义编辑器
        /// 预定义编辑控制器类型列表
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("预定义编辑器")]
        [Description("预定义编辑器")]
        public Dictionary<string, Type> PredefinedEditorTypes {
            get;
            set;
        }
        #endregion 属性：PredefinedEditors        

        #endregion
        public PredefinedEditors() {
        }

        /// <summary>
        /// 获取预定义的编辑控制器
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="propertyName">属性名称</param>
        /// <returns>编辑控制器</returns>
        public BaseEditController GetPredefinedEditController(Type objectType, string propertyName) {
            if (PredefinedEditorTypes.IsNotNullOrEmpty()
                    && PredefinedEditorTypes.ContainsKey(propertyName)
                    && PredefinedEditorTypes[propertyName] != null) {

                return EditorPublic.GetOrCreateEditControllerFromStorage(objectType, PredefinedEditorTypes[propertyName]);
            }
            return null;
        }

        /// <summary>
        /// 清除所有预定义的编辑控制器
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        /// <returns>编辑控制器</returns>
        public void ClearPredefinedEditControllers() {
            if (PredefinedEditorTypes.IsNotNullOrEmpty()) {
                PredefinedEditorTypes.Clear();
            }
        }

        /// <summary>
        /// 获取预定义的编辑控制器
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        /// <returns>编辑控制器</returns>
        public void RemovePredefinedEditController(string propertyName) {
            if (PredefinedEditorTypes.IsNotNullOrEmpty()
                    && PredefinedEditorTypes.ContainsKey(propertyName)) {
                PredefinedEditorTypes.Remove(propertyName);
            }
        }

        /// <summary>
        /// 设置预定义的编辑控制器
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        /// <param name="editControllerType">编辑控制器类型</param>
        public void SetPredfinedEditController(string propertyName, Type editControllerType) {
            if (PredefinedEditorTypes == null)
                PredefinedEditorTypes = new Dictionary<string, Type>();

            if (PredefinedEditorTypes.ContainsKey(propertyName)) {
                PredefinedEditorTypes[propertyName] = editControllerType;
            }
            else {
                PredefinedEditorTypes.Add(propertyName, editControllerType);
            }
        }
    }
}
