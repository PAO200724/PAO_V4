using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAO
{
    /// <summary>
    /// 静态类：CollectionPublic
    /// 集合公共类
    /// 作者：PAO
    /// </summary>
    public static class CollectionPublic
    {
        #region 列表(List)

        /// <summary>
        /// 判断能否上移
        /// </summary>
        /// <param name="list">列表</param>
        /// <param name="index">索引</param>
        /// <returns>能否上移（索引>0）</returns>
        public static bool CanMoveUp(this IList list, int index) {
            return list.Count > 0 && index > 0 && index < list.Count;
        }

        /// <summary>
        /// 判断能否下移
        /// </summary>
        /// <param name="list">列表</param>
        /// <param name="index">索引</param>
        /// <returns>能否下移（索引<索引长度）</returns>
        public static bool CanMoveDown(this IList list, int index) {
            return list.Count > 0 && index < list.Count-1 && index >= 0;
        }
        /// <summary>
        /// 将某个元素上移
        /// </summary>
        /// <param name="list">列表</param>
        /// <param name="index">索引</param>
        public static void MoveUp(this IList list, int index) {
            if(CanMoveUp(list, index)) {
                var obj = list[index];
                list.RemoveAt(index);
                list.Insert(index - 1, obj);
            }
        }
        /// <summary>
        /// 将某个元素下移
        /// </summary>
        /// <param name="list">列表</param>
        /// <param name="index">索引</param>
        public static void MoveDown(this IList list, int index) {
            if (CanMoveDown(list, index)) {
                var obj = list[index];
                list.RemoveAt(index);
                list.Insert(index + 1, obj);
            }
        }
        #endregion
    }
}
