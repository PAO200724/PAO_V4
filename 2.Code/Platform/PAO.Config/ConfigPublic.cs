using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList.Nodes;
using PAO.Config.Controls;
using PAO.Config.Controls.EditControls;
using PAO.Config.Editors;
using PAO.Data;
using PAO.UI;
using PAO.UI.WinForm;
using PAO.UI.WinForm.Editors;
using PAO.UI.WinForm.MDI.DockViews;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static PAO.DataSetExtendProperty;
using DevExpress.XtraGrid.Views.Grid;
using PAO.UI.WinForm.Property;

namespace PAO.Config
{
    /// <summary>
    /// 静态类：ConfigPublic
    /// 配置公共类
    /// 作者：PAO
    /// </summary>
    public static class ConfigPublic
    {
        #region 插件列表
        /// <summary>
        /// 编辑时根对象
        /// </summary>
        public static object RootEditingObject;

        /// <summary>
        /// 根据插件ID查找编辑中的插件
        /// </summary>
        /// <param name="addonID">插件ID</param>
        /// <returns></returns>
        public static PaoObject GetEditiongAddonByID(string addonID) {
            if (RootEditingObject == null)
                return null;
            PaoObject addonEditing = null;
            AddonPublic.TraverseAddon((addon) =>
            {
                if (addon is PaoObject) {
                    var paoObj = addon as PaoObject;
                    if (paoObj.ID == addonID) {
                        addonEditing = paoObj;
                        return true;
                    }
                }

                return false;
            }, RootEditingObject);

            return addonEditing;
        }
        #endregion

        #region NewAddonValue
        /// <summary>
        /// 创建新的属性值
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="createElement">创建元素对象</param>
        /// <param name="propDesc">属性描述</param>
        /// <return>属性值</return>
        public static bool CreateNewAddonValue(Type objectType, bool createElement, out object newObject) {
            if (objectType.IsAddonDictionaryType() || objectType.IsAddonListType()) {
                if (createElement) {
                    var listElementType = ReflectionPublic.GetCollectionElementType(objectType);
                    if (listElementType == null) {
                        newObject = null;
                        return false;
                    }

                    return CreateNewAddonValue(listElementType, false, out newObject);
                }
                else {
                    // 创建新的对象
                    newObject = objectType.CreateInstance();
                    return true;
                }
            }
            else {
                var typeSelectControl = new TypeSelectControl();
                if (objectType.IsGenericType && objectType.IsDerivedFrom(typeof(Ref<>))) {
                    var refType = objectType.GetGenericArguments()[0];
                    typeSelectControl.Initialize(p =>
                    {
                        return (p.IsDerivedFrom(refType) || p.IsDerivedFrom(typeof(Factory<>))) && p.IsClass && !p.IsAbstract;
                    });
                    if (WinFormPublic.ShowDialog(typeSelectControl) == DialogReturn.OK) {
                        var selectedAddonType = typeSelectControl.SelectedType;
                        if (selectedAddonType != null) {
                            if (selectedAddonType.IsDerivedFrom(typeof(Ref<>))) {
                                // 创建新的工厂
                                var objectRefType = selectedAddonType.MakeGenericType(refType);
                                newObject = objectRefType.CreateInstance();
                                return true;
                            }
                            else {
                                // 创建新的对象
                                var newInstance = selectedAddonType.CreateInstance();
                                var objectRefType = typeof(ObjectRef<>).MakeGenericType(refType);
                                newObject = objectRefType.CreateInstance(newInstance);
                                return true;
                            }
                        }
                    }
                }
                else {
                    typeSelectControl.Initialize(p =>
                    {
                        return p.IsDerivedFrom(objectType) && p.IsClass && !p.IsAbstract;
                    });
                    if (WinFormPublic.ShowDialog(typeSelectControl) == DialogReturn.OK) {
                        var selectedAddonType = typeSelectControl.SelectedType;
                        if (selectedAddonType != null) {
                            // 创建新的对象
                            newObject = selectedAddonType.CreateInstance();
                            return true;
                        }
                    }
                }
            }
            newObject = null;
            return false;
        }
        #endregion

        #region 默认的Editor注册
        /// <summary>
        /// 注册编辑器
        /// </summary>
        public static void RegisterEditors() {
            WinFormPublic.RegisterTypeConfig(typeof(PaoObject)
                , new TypeConfigInfo()
                    .AddProperty("ID", new GuidEditor())
                );

            WinFormPublic.RegisterTypeConfig(typeof(AddonFactory<>)
                , new TypeConfigInfo()
                    .AddProperty("AddonID", new AddonIDEditor())
                );

            WinFormPublic.RegisterTypeConfig(typeof(DataConnection)
                , new TypeConfigInfo()
                    .AddProperty("DbFactoryName", new DbFactoryEditor())
            );

            WinFormPublic.RegisterTypeConfig(typeof(DataCommandInfo)
                , new TypeConfigInfo()
                    {
                        EditControlType = typeof(DataCommandInfoEditControl)
                    }
                    .AddProperty("Sql", new MemoExEditor())
            );

            WinFormPublic.RegisterTypeConfig(typeof(IDataFilter)
                , new TypeConfigInfo()
                    {
                        EditControlType = typeof(DataFilterEditControl)
                    }
            );

            WinFormPublic.RegisterTypeConfig(typeof(GridView)
                , new TypeConfigInfo()
                    .AddProperty("BorderStyle", "边框风格", "边框风格")
            );
        }
        #endregion

    }
}
