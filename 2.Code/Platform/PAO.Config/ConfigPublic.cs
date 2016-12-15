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
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;

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
        /// 获取属性字符串
        /// </summary>
        /// <param name="type">类型</param>
        public static void GetPropertyStrings(Type type) {
            var properties = TypeDescriptor.GetProperties(type);
            PropertyDescriptorCollection baseProperties = null;
            if (type.BaseType != null) {
                baseProperties = TypeDescriptor.GetProperties(type.BaseType);
            }
            var props = properties.Cast<PropertyDescriptor>().Where(p => p.IsBrowsable 
            && (baseProperties == null  || !baseProperties.Cast<PropertyDescriptor>().Any(q=>q.Name == p.Name))).Select(p => new { Name = p.Name, p.DisplayName, p.Description });
            foreach (var prop in props) {
                Console.WriteLine(String.Format(@".AddProperty(""{0}"", ""{1}"", ""{2}"")", prop.Name, prop.DisplayName, prop.Description));
            }
        }

        public static void GetPropertyStrings() {
            Type type = typeof(DevExpress.XtraGrid.Views.BandedGrid.GridBand);
            var properties = TypeDescriptor.GetProperties(type);
            PropertyDescriptorCollection baseProperties = null;
            if (type.BaseType != null) {
                baseProperties = TypeDescriptor.GetProperties(type.BaseType);
            }
            var props = properties.Cast<PropertyDescriptor>().Where(p => p.IsBrowsable
            && (baseProperties == null || !baseProperties.Cast<PropertyDescriptor>().Any(q => q.Name == p.Name))).Select(p => new { Name = p.Name, p.DisplayName, p.Description });
            foreach (var prop in props) {
                Console.WriteLine(String.Format(@".AddProperty(""{0}"", ""{1}"", ""{2}"")", prop.Name, prop.DisplayName, prop.Description));
            }
        }

        /// <summary>
        /// 注册编辑器
        /// </summary>
        public static void RegisterEditors() {
            WinFormPublic.RegisterTypeConfig(typeof(PaoObject)
                , TypeConfigInfo.Create()
                    .AddProperty("ID", new GuidEditor()));

            WinFormPublic.RegisterTypeConfig(typeof(AddonFactory<>)
                , TypeConfigInfo.Create()
                    .AddProperty("AddonID", new AddonIDEditor()));

            WinFormPublic.RegisterTypeConfig(typeof(DataConnection)
                , TypeConfigInfo.Create()
                    .AddProperty("DbFactoryName", new DbFactoryEditor())
            );

            WinFormPublic.RegisterTypeConfig(typeof(DataCommandInfo)
                , TypeConfigInfo.Create(typeof(DataCommandInfoEditControl))
                    .AddProperty("Sql", new MemoExEditor())
            );

            WinFormPublic.RegisterTypeConfig(typeof(IDataFilter)
                , TypeConfigInfo.Create(typeof(DataFilterEditControl))
            );

            WinFormPublic.RegisterTypeConfig(typeof(BaseView)
                , TypeConfigInfo.Create()
                    .AddProperty("Appearance", "外观", "读取/设置外观风格")
                    .AddProperty("AppearancePrint", "打印外观", "读取/设置打印时的外观风格")
                    .AddProperty("BorderStyle", "边框风格", "读取/设置边框风格")
                    .AddProperty("DetailHeight", "子表高度", "读取/设置视图有子表时，用于设定子表的高度")
                    .AddProperty("HtmlImages", "Html图片集", "读取/设置在列标题或行中有Html标记时所需要的图片集")
                    .AddProperty("PaintAppearance", "绘制外观", "读取/设置当前使用的绘制视图元素时的外观风格")
                    .AddProperty("SynchronizeClones", false)
                    .AddProperty("ViewCaption", "视图标题", "读取/设置视图的标题")
                    .AddProperty("DetailTabHeaderLocation", "子表头位置", "读取/设置子表表头的位置")
                    .AddProperty("PaintStyleName", false)
            );

            WinFormPublic.RegisterTypeConfig(typeof(ColumnView)
                , TypeConfigInfo.Create()
                    .AddProperty("ActiveFilterEnabled", "自动过滤器生效", "读取/设置自动过滤器是否生效")
                    .AddProperty("FormatRules", "格式化规则", "读取/设置表格格式化的规则")
                    .AddProperty("OptionsView", "视图选项", "读取/设置表格视图显示的选项")
                    .AddProperty("OptionsLayout", "布局选项", "Provides options which control how the current View's layout is stored to/restored from a data store (a stream, xml file or system registry).")
                    .AddProperty("OptionsSelection", "OptionsSelection", "Provides access to the View's selection options.")
                    .AddProperty("OptionsBehavior", "OptionsBehavior", "Provides access to the View's behavior options.")
                    .AddProperty("OptionsFilter", "OptionsFilter", "Provides access to the View's filtering options. ")
                    .AddProperty("OptionsFind", "OptionsFind", "Provides access to settings controlling the behavior and visibility of the Find Panel and its elements.")
                    .AddProperty("ViewCaptionHeight", "ViewCaptionHeight", "Gets or sets the height of the View Caption region.")
                    .AddProperty("Images", "Images", "Gets or sets a collection of images that can be displayed within column headers and band headers.")
                    .AddProperty("AppearancePrint", "AppearancePrint", "Provides access to the properties that specify the appearances of View elements when they are printed/exported.")
                    .AddProperty("Appearance", "Appearance", "Provides access to the properties that control the appearance of the View's elements.")
                    .AddProperty("ViewCaption", "ViewCaption", "Gets or sets the View's caption.")
                    .AddProperty("OptionsPrint", "OptionsPrint", "Provides options that control how the View is printed/exported.")
                    .AddProperty("BorderStyle", "BorderStyle", "Gets or sets the border style for the current View.")
                    .AddProperty("HtmlImages", "HtmlImages", "Represents a collection of System.Drawing.Image objects and supports alpha channels in images.")
                    .AddProperty("SynchronizeClones", "SynchronizeClones", "Gets or sets a value specifying whether this View's clones have synchronized appearance and data representation settings.")
                    .AddProperty("PaintStyleName", "PaintStyleName", "Gets or sets the paint style name for the current View.")
                    .AddProperty("DetailTabHeaderLocation", "DetailTabHeaderLocation", "Gets or sets the position of detail tabs within detail sections.")
                    .AddProperty("DetailHeight", "DetailHeight", "Gets or sets the height of a View when it serves as a detail View.")
                    .AddProperty("Tag", "Tag", "Gets or sets the data associated with the current View.")
                );

            WinFormPublic.RegisterTypeConfig(typeof(GridView)
                , TypeConfigInfo.Create()
                    .AddProperty("OptionsImageLoad", "OptionsImageLoad", "")
                    .AddProperty("OptionsHint", "OptionsHint", "Provides access to the View's hint options.")
                    .AddProperty("OptionsDetail", "OptionsDetail", "Provides access to the View's master-detail options.")
                    .AddProperty("OptionsCustomization", "OptionsCustomization", "Provides access to the View's customization options.")
                    .AddProperty("OptionsNavigation", "OptionsNavigation", "Gets options regarding cell navigation.")
                    .AddProperty("OptionsMenu", "OptionsMenu", "Provides access to the View's menu options.")
                    .AddProperty("OptionsEditForm", "OptionsEditForm", "Provides access to the settings of an Edit Form.")
                    .AddProperty("DetailVerticalIndent", "DetailVerticalIndent", "Gets or sets the distance between master rows and Detail Sections, in pixels.")
                    .AddProperty("FixedLineWidth", "FixedLineWidth", "Gets or sets the width of frozen panel separators.")
                    .AddProperty("IndicatorWidth", "IndicatorWidth", "Gets or sets the width of the row indicator panel.")
                    .AddProperty("ColumnPanelRowHeight", "ColumnPanelRowHeight", "Gets or sets the column header row height.")
                    .AddProperty("RowSeparatorHeight", "RowSeparatorHeight", "Gets or sets the distance between rows.")
                    .AddProperty("FooterPanelHeight", "FooterPanelHeight", "Gets or sets the height of the  view footer.")
                    .AddProperty("HorzScrollVisibility", "HorzScrollVisibility", "Gets or sets a value specifying when the horizontal scrollbar should be displayed. ")
                    .AddProperty("VertScrollVisibility", "VertScrollVisibility", "Gets or sets a value specifying when the View's vertical scrollbar is visible.")
                    .AddProperty("RowHeight", "RowHeight", "Gets or sets the height of cells within data rows.")
                    .AddProperty("GroupRowHeight", "GroupRowHeight", "Gets or sets the height of group rows.")
                    .AddProperty("GroupFormat", "GroupFormat", "Gets or sets the text pattern for group rows.")
                    .AddProperty("ChildGridLevelName", "ChildGridLevelName", "Gets or sets the name of the child level whose grouping state is displayed by the joined group panel.")
                    .AddProperty("VertScrollTipFieldName", "VertScrollTipFieldName", "Gets or sets the field whose values are displayed within the vertical scrollbar's tooltip.")
                    .AddProperty("PreviewFieldName", "PreviewFieldName", "Gets or sets the name of the field whose values are displayed within preview sections.")
                    .AddProperty("GroupPanelText", "GroupPanelText", "Gets or sets the text displayed within the group panel.")
                    .AddProperty("NewItemRowText", "NewItemRowText", "Gets or sets the text displayed within the new item row.")
                    .AddProperty("LevelIndent", "LevelIndent", "Gets or sets the indent between group rows located at neighboring group levels, or between master and detail views.")
                    .AddProperty("PreviewIndent", "PreviewIndent", "Gets or sets the horizontal offset of preview text.")
                    .AddProperty("PreviewLineCount", "PreviewLineCount", "Gets or sets the number of text lines within preview sections.")
                    .AddProperty("DefaultRelationIndex", "DefaultRelationIndex", "Gets or sets the value indicating which detail level is processed by default.")
                    .AddProperty("ScrollStyle", "ScrollStyle", "Gets or sets a value specifying the behavior of the View's scrollbars.")
                    .AddProperty("FocusRectStyle", "FocusRectStyle", "Gets or sets a value specifying how the focus rectangle is painted.")
                    .AddProperty("HorzScrollStep", "HorzScrollStep", "Gets or sets the offset by which the View is scrolled horizontally when clicking scrollbar buttons.")
                    .AddProperty("OptionsClipboard", false)
                );
            WinFormPublic.RegisterTypeConfig(typeof(GridColumn)
                , TypeConfigInfo.Create()
                    .AddProperty("SummaryItem", "SummaryItem", "Provides access to the column's footer summary settings.")
                    .AddProperty("Summary", "Summary", "Allows you to add multiple total summaries for a column. These summaries are displayed within the View Footer.")
                    .AddProperty("ShowButtonMode", "ShowButtonMode", "Gets or sets a value specifying which column cells display editor buttons.")
                    .AddProperty("OptionsColumn", "OptionsColumn", "Provides access to the column's options.")
                    .AddProperty("OptionsFilter", "OptionsFilter", "Provides access to the filter options for the current column.")
                    .AddProperty("OptionsEditForm", "OptionsEditForm", "Provides access to the settings of the editor that corresponds to the current column within an Edit Form.")
                    .AddProperty("ToolTip", "ToolTip", "Gets or sets a custom tooltip for the column.")
                    .AddProperty("Caption", "Caption", "Gets or sets the column's display caption.")
                    .AddProperty("CustomizationCaption", "CustomizationCaption", "Gets or sets the column's caption when its header is displayed within the Customization Form.")
                    .AddProperty("ImageAlignment", "ImageAlignment", "Gets or sets the column header image alignment.")
                    .AddProperty("ImageIndex", "ImageIndex", "Gets or sets the index of the image displayed within the column header.")
                    .AddProperty("Image", "Image", "Gets or sets an image displayed within the Column Header.")
                    .AddProperty("FieldName", "FieldName", "Gets or sets the column's unique field name. For bound columns, this property refers to a field in the underlying data source.")
                    .AddProperty("FieldNameSortGroup", "FieldNameSortGroup", "Gets or sets another field by which data is sorted/grouped/filtered when sorting/grouping/filtering is applied to the current column.")
                    .AddProperty("Fixed", "Fixed", "Gets or sets a value specifying whether the column takes part in horizontal View scrolling or is anchored to a View edge.")
                    .AddProperty("ColumnEdit", "ColumnEdit", "Gets or sets the repository item specifying the editor used to edit a column's cell values.")
                    .AddProperty("VisibleIndex", "VisibleIndex", "Gets or sets the column's visible state and position within the View.")
                    .AddProperty("Tag", "Tag", "Gets or sets the data associated with the column.")
                    .AddProperty("Visible", "Visible", "Gets or sets whether the column is visible.")
                    .AddProperty("GroupIndex", "GroupIndex", "Gets or sets the value specifying whether the column takes part in grouping and at which level.")
                    .AddProperty("SortMode", "SortMode", "Gets or sets how the column's data is sorted when sorting/grouping is applied to it.")
                    .AddProperty("FilterMode", "FilterMode", "Gets or sets how column values are filtered via the auto filter row and filter dropdown.")
                    .AddProperty("GroupInterval", "GroupInterval", "Gets or sets how data rows are grouped when grouping by the current column is applied. Not supported in Server Mode.")
                    .AddProperty("SortOrder", "SortOrder", "Gets or sets the column's sort order.")
                    .AddProperty("Width", "Width", "Gets or sets column width.")
                    .AddProperty("AppearanceCell", "AppearanceCell", "Gets the appearance settings used to paint the column's data cells.")
                    .AddProperty("AppearanceHeader", "AppearanceHeader", "Gets the appearance settings used to paint the column header.")
                    .AddProperty("DisplayFormat", "DisplayFormat", "Provides access to the object specifying the formatting applied to column values.")
                    .AddProperty("GroupFormat", "GroupFormat", "Provides access to the formatting settings for the column's values which are displayed within group rows.")
                    .AddProperty("MinWidth", "MinWidth", "Gets or sets the column's minimum allowed width.")
                    .AddProperty("MaxWidth", "MaxWidth", "Gets or sets the column's maximum width.")
                    .AddProperty("ShowUnboundExpressionMenu", "ShowUnboundExpressionMenu", "Gets or sets whether an end-user can open an Expression Editor for the current unbound column, using a context menu.")
                    .AddProperty("UnboundType", "UnboundType", "Gets or sets the data type and binding mode of the column.")
                    .AddProperty("UnboundExpression", "UnboundExpression", "Gets or sets an expression used to evaluate values for the current unbound column.")                                                                                            
                );
            WinFormPublic.RegisterTypeConfig(typeof(GridBand)
                , TypeConfigInfo.Create()
                    .AddProperty("AppearanceHeader", "AppearanceHeader", "Gets the appearance settings used to paint the band header.")
                    .AddProperty("ImageAlignment", "ImageAlignment", "Gets or sets the band header image alignment.")
                    .AddProperty("ImageIndex", "ImageIndex", "Gets or sets the index of the image displayed within the band header.")
                    .AddProperty("Image", "Image", "Gets or sets an image displayed within a Band Header.")
                    .AddProperty("Tag", "Tag", "Gets or sets the data associated with the current band.")
                    .AddProperty("Fixed", "Fixed", "Gets or sets the band's behavior when the View is scrolled horizontally.")
                    .AddProperty("Width", "Width", "Gets or sets band width.")
                    .AddProperty("AutoFillDown", "AutoFillDown", "Gets or sets a value specifying whether a band header should be automatically stretched to fill the empty space below it.")
                    .AddProperty("MinWidth", "MinWidth", "Gets or sets the band's minimum allowed width.")
                    .AddProperty("RowCount", "RowCount", "Gets or sets the band header height in rows.")
                    .AddProperty("Visible", "Visible", "Gets or sets whether the band is visible.")
                    .AddProperty("Caption", "Caption", "Gets or sets the band's caption.")
                    .AddProperty("CustomizationCaption", "CustomizationCaption", "Gets or sets the band's caption when its header is displayed within the Customization Form.")
                    .AddProperty("ToolTip", "ToolTip", "Gets or sets a custom tooltip for the band.")
                    .AddProperty("OptionsBand", "OptionsBand", "Provides access to the band's options.")
                );
            WinFormPublic.RegisterTypeConfig(typeof(DevExpress.XtraVerticalGrid.VGridControlBase)
                , TypeConfigInfo.Create()
                    .AddProperty("FilterCriteria", "FilterCriteria", "")
                    .AddProperty("FilterString", "FilterString", "")
                    .AddProperty("Appearance", "Appearance", "Provides access to the properties that control the appearance of the vertical grid's elements.")
                    .AddProperty("BandsInterval", "BandsInterval", "Gets or sets the distance between bands.")
                    .AddProperty("RowHeaderWidth", "RowHeaderWidth", "Gets or sets the width of row headers. ")
                    .AddProperty("RowHeaderWidthChangeStep", "RowHeaderWidthChangeStep", "Gets or sets a value by which the VGridControlBase.RowHeaderWidth property changes when using CTRL + LEFT or CTRL + RIGHT key combinations.")
                    .AddProperty("RecordWidth", "RecordWidth", "Gets or sets the record's width, in either absolute or relative values, according to the currently applied layout. ")
                    .AddProperty("LookAndFeel", "LookAndFeel", "Provides access to the settings that control the vertical grid's look and feel.")
                    .AddProperty("BorderStyle", "BorderStyle", "Gets or sets the border style for the vertical grid.")
                    .AddProperty("ShowButtonMode", "ShowButtonMode", "Gets or sets the manner in which editor buttons are displayed within a vertical grid.")
                    .AddProperty("ScrollVisibility", "ScrollVisibility", "Gets or sets a value that specifies the availability of scroll elements.")
                    .AddProperty("ScrollsStyle", "ScrollsStyle", "Gets the style which is applied to the scroll bars.")
                    .AddProperty("TreeButtonStyle", "TreeButtonStyle", "Gets or sets the style which is used to display category row tree buttons.")
                    .AddProperty("ImageList", "ImageList", "Gets or sets the source of row header images.")
                    .AddProperty("OptionsFind", "OptionsFind", "Provides access to settings controlling the behavior and visibility of the Find Panel and its elements.")
                    .AddProperty("OptionsView", "OptionsView", "Provides access to the vertical grid's display options.")
                    .AddProperty("OptionsBehavior", "OptionsBehavior", "Provides access to the vertical grid's behavior options.")
                    .AddProperty("OptionsSelectionAndFocus", "OptionsSelectionAndFocus", "Provides access to the vertical grid's selection and focus options.")
                    .AddProperty("OptionsLayout", "OptionsLayout", "Provides access to options that specify how a control's layout is stored to and restored from a data store (a stream, xml file or the system registry). ")
                    .AddProperty("OptionsMenu", "OptionsMenu", "Provides access to the control's menu options. ")
                    .AddProperty("OptionsHint", "OptionsHint", "Provides access to the control's tooltip options.")
                    .AddProperty("RecordsInterval", "RecordsInterval", "Gets or sets the distance between records.")
                    .AddProperty("UseDisabledStatePainter", "UseDisabledStatePainter", "Gets or sets whether the control is painted grayed out, when it's in the disabled state.")
                    .AddProperty("FindPanelVisible", "FindPanelVisible", "")
                );
            WinFormPublic.RegisterTypeConfig(typeof(DevExpress.XtraVerticalGrid.VGridControl)
                , TypeConfigInfo.Create()
                    .AddProperty("LayoutStyle", "LayoutStyle", "Gets or sets the Vertical Grid Control's layout style. ")
                    .AddProperty("DataSource", "DataSource", "Gets or sets the vertical grid's data source. ")
                    .AddProperty("DataMember", "DataMember", "Gets or sets a data source member whose data is supplied to the vertical grid control."));
            WinFormPublic.RegisterTypeConfig(typeof(DevExpress.XtraTreeList.TreeList)
                , TypeConfigInfo.Create()
                    .AddProperty("DataSource", "DataSource", "Gets or sets the object used as the data source for the current TreeList control.")
                    .AddProperty("DataMember", "DataMember", "Gets or sets a specific list in a data source whose data is displayed by the TreeList control.")
                    .AddProperty("RootValue", "RootValue", "Gets or sets the value used to identify the records in the underlying data source that will be represented as root nodes. These records must have the RootValue in the field specified by the TreeList.ParentFieldName property.")
                    .AddProperty("StateImageList", "StateImageList", "Gets or sets the source of state images for nodes.")
                    .AddProperty("SelectImageList", "SelectImageList", "Gets or sets the source of select images for nodes.")
                    .AddProperty("ColumnsImageList", "ColumnsImageList", "Gets or sets the source of images that can be displayed within column headers.")
                    .AddProperty("ImageIndexFieldName", "ImageIndexFieldName", "Gets or sets the name of the field whose values represent select image indexes for corresponding nodes.")
                    .AddProperty("KeyFieldName", "KeyFieldName", "Gets or sets a value specifying the key field of the data source bound to the Tree List control.")
                    .AddProperty("ParentFieldName", "ParentFieldName", "Gets or sets a value representing the data source field identifying the parent record in this data source.")
                    .AddProperty("PreviewFieldName", "PreviewFieldName", "Gets or sets the name of the field whose values are displayed in preview sections.")
                    .AddProperty("OptionsView", "OptionsView", "Provides access to the Tree List's display options.")
                    .AddProperty("OptionsSelection", "OptionsSelection", "Provides access to the Tree List's selection options. ")
                    .AddProperty("OptionsBehavior", "OptionsBehavior", "Provides access to the Tree List's behavior options.")
                    .AddProperty("OptionsPrint", "OptionsPrint", "Provides access to the Tree List's options that affect how the control is printed and exported")
                    .AddProperty("OptionsMenu", "OptionsMenu", "Provides access to the Tree List's menu options.")
                    .AddProperty("OptionsLayout", "OptionsLayout", "Provides access to options that specify how a control's layout is stored to and restored from a data store (a stream, xml file or the system registry). ")
                    .AddProperty("OptionsFilter", "OptionsFilter", "Provides access to the TreeList's filtering options. ")
                    .AddProperty("OptionsFind", "OptionsFind", "Provides access to settings controlling the behavior and visibility of the current TreeList's Find Panel and its elements.")
                    .AddProperty("OptionsCustomization", "OptionsCustomization", "Provides access to a TreeList's customization options.")
                    .AddProperty("OptionsNavigation", "OptionsNavigation", "Provides access to a TreeList's focus navigation options.")
                    .AddProperty("OptionsDragAndDrop", "OptionsDragAndDrop", "Contains options that control the node drag-and-drop functionality.")
                    .AddProperty("BorderStyle", "BorderStyle", "Gets or sets the border style for the Tree List.")
                    .AddProperty("ShowButtonMode", "ShowButtonMode", "Gets or sets a value determining the manner in which the editor buttons of TreeList cells are displayed.")
                    .AddProperty("IndicatorWidth", "IndicatorWidth", "Gets or sets the node indicator's width.")
                    .AddProperty("PreviewLineCount", "PreviewLineCount", "Gets or sets the number of text lines within preview sections.")
                    .AddProperty("RowHeight", "RowHeight", "Gets or sets the height of a node in pixels.")
                    .AddProperty("ColumnPanelRowHeight", "ColumnPanelRowHeight", "Gets or sets the height of the column header panel, in pixels.")
                    .AddProperty("BandPanelRowHeight", "BandPanelRowHeight", "Gets or sets the band panel row height.")
                    .AddProperty("FooterPanelHeight", "FooterPanelHeight", "Gets or sets the height of the Summary Footer.")
                    .AddProperty("BestFitVisibleOnly", "BestFitVisibleOnly", "Gets or sets a value specifying which nodes take part in calculations when applying best fit to columns.")
                    .AddProperty("LookAndFeel", "LookAndFeel", "Provides access to settings which control the Tree List's look and feel.")
                    .AddProperty("HorzScrollVisibility", "HorzScrollVisibility", "Gets or sets a value specifying when the horizontal scrollbar should be displayed. ")
                    .AddProperty("HorzScrollStep", "HorzScrollStep", "Gets or sets the offset by which the Tree List is scrolled horizontally when the scrollbar buttons are clicked.")
                    .AddProperty("VertScrollVisibility", "VertScrollVisibility", "Gets or sets a value specifying when the Tree List's vertical scrollbar is visible.")
                    .AddProperty("Nodes", "Nodes", "Provides access to the collection of the TreeList's root nodes.")
                    .AddProperty("HtmlImages", "HtmlImages", "Represents a collection of System.Drawing.Image objects and supports alpha channels in images.")
                    .AddProperty("FormatConditions", "FormatConditions", "")
                    .AddProperty("FilterConditions", "FilterConditions", "")
                    .AddProperty("FormatRules", "FormatRules", "")
                    .AddProperty("MinWidth", "MinWidth", "Gets or sets the minimum allowed width of all the columns in a Tree List.")
                    .AddProperty("Caption", "Caption", "Gets or sets the caption displayed at the top of the TreeList control.")
                    .AddProperty("CaptionHeight", "CaptionHeight", "Gets or sets the height, in pixels, of the panel at the top of the TreeList control in which the caption is displayed.")
                    .AddProperty("EnableDynamicLoading", "EnableDynamicLoading", "")
                    .AddProperty("TreeLineStyle", "TreeLineStyle", "Specifies the style for displaying tree lines of the current TreeList control.")
                    .AddProperty("TreeLevelWidth", "TreeLevelWidth", "Gets or sets the width of the level's indent space.")
                    .AddProperty("Appearance", "Appearance", "Provides access to the properties that control the appearance of the Tree List's elements.")
                    .AddProperty("AppearancePrint", "AppearancePrint", "Provides access to the properties that specify the appearances of the Tree List's elements when the Tree List is printed and exported.")
                    .AddProperty("UseDisabledStatePainter", "UseDisabledStatePainter", "Gets or sets whether the control is painted grayed out, when it's in the disabled state.")
                    .AddProperty("FixedLineWidth", "FixedLineWidth", "")
                    .AddProperty("ActiveFilterEnabled", "ActiveFilterEnabled", "")
                    .AddProperty("OptionsClipboard", "OptionsClipboard", "Provides access to the clipboard options.")
                    );
            WinFormPublic.RegisterTypeConfig(typeof(DevExpress.XtraPivotGrid.PivotGridControl)
                , TypeConfigInfo.Create()
                    .AddProperty("IsUpdateLocked", "IsUpdateLocked", "")
                    .AddProperty("UseDisabledStatePainter", "UseDisabledStatePainter", "Gets or sets whether the control is painted grayed out, when in the disabled state.")
                    .AddProperty("DataSource", "DataSource", "Gets or sets the object used as the data source for the current control. ")
                    .AddProperty("DataMember", "DataMember", "Gets or sets the data source member which supplies data to the control.")
                    .AddProperty("OLAPConnectionString", "OLAPConnectionString", "Specifies a connection string to a cube in an MS Analysis Services database.")
                    .AddProperty("OLAPDataProvider", "OLAPDataProvider", "Gets or sets which data provider should be used to bind to an OLAP cube.")
                    .AddProperty("BorderStyle", "BorderStyle", "Gets or sets the border style for the PivotGridControl.")
                    .AddProperty("LookAndFeel", "LookAndFeel", "Provides access to the settings that control the Pivot Grid Control's look and feel.")
                    .AddProperty("Appearance", "Appearance", "Provides access to the properties that control the appearance of the Pivot Grid Control's elements.")
                    .AddProperty("AppearancePrint", "AppearancePrint", "Provides access to the properties that specify the appearances of the Pivot Grid Control's elements when the Pivot Grid Control is printed.")
                    .AddProperty("Fields", "Fields", "Provides access to a Pivot Grid Control's field collection.")
                    .AddProperty("FormatRules", "FormatRules", "")
                    .AddProperty("Prefilter", "Prefilter", "Gets the Prefilter's settings.")
                    .AddProperty("OptionsBehavior", "OptionsBehavior", "Provides access to the control's behavior options. ")
                    .AddProperty("OptionsFilterPopup", "OptionsFilterPopup", "Contains settings that specify the appearance and behavior of filter dropdown windows..")
                    .AddProperty("OptionsCustomization", "OptionsCustomization", "Provides access to the Pivot Grid Control's customization options. ")
                    .AddProperty("OptionsDataField", "OptionsDataField", "Provides access to the options which control the presentation of the data fields in the PivotGrid. ")
                    .AddProperty("OptionsData", "OptionsData", "Provides access to the Pivot Grid Control's data specific options.")
                    .AddProperty("OptionsChartDataSource", "OptionsChartDataSource", "Provides access to the options controlling the display of the PivotGrid control's data in a chart control.")
                    .AddProperty("OptionsLayout", "OptionsLayout", "Provides options that control how the Pivot Grid Control layout is stored to/restored from a storage (a stream, XML file or system registry). ")
                    .AddProperty("OptionsHint", "OptionsHint", "Provides access to the Pivot Grid Control's hint options.")
                    .AddProperty("OptionsMenu", "OptionsMenu", "Provides access to the Pivot Grid Control's menu options.")
                    .AddProperty("OptionsSelection", "OptionsSelection", "Provides access to the Pivot Grid Control's selection options.")
                    .AddProperty("OptionsPrint", "OptionsPrint", "Provides access to the Pivot Grid Control's print options. ")
                    .AddProperty("OptionsView", "OptionsView", "Provides access to the Pivot Grid Control's display options.")
                    .AddProperty("OptionsOLAP", "OptionsOLAP", "Provides access to the Pivot Grid Control's OLAP mode specific options. ")
                    .AddProperty("MenuManager", "MenuManager", "Gets or sets the menu manager which controls the look and feel of the context menus.")
                    .AddProperty("HeaderImages", "HeaderImages", "Gets or sets the source of images available for display within field headers.")
                    .AddProperty("ValueImages", "ValueImages", "Gets or sets the source of images that are available for display within field values.")
                    .AddProperty("IsAsyncInProgress", "IsAsyncInProgress", "")
                    .AddProperty("ToolTipController", "ToolTipController", "Manages tooltips for a specific control or controls.")
                    );

            WinFormPublic.RegisterTypeConfig(typeof(GridView)
                , TypeConfigInfo.Create()
            );
        }
        #endregion

    }
}
