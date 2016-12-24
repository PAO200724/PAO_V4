using PAO;
using PAO.Data;
using PAO.Data.Filters;
using PAO.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using static PAO.Ext.Security.UserDataSet;

namespace PAO.Ext.Security
{
    /// <summary>
    /// 类：SecurityService
    /// 用户服务
    /// 实现了基本安全功能的服务
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("用户服务")]
    [Description("实现了基本安全功能的服务")]
    public class SecurityService : PaoObject, ISecurity
    {
        #region 插件属性
        #region 属性：DataService
        /// <summary>
        /// 属性：DataService
        /// 数据服务
        /// 实现本服务所需的数据服务
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("数据服务")]
        [Description("实现本服务所需的数据服务")]
        public Ref<DataService> DataService {
            get;
            set;
        }
        #endregion 属性：DataService
        #endregion

        #region Sql

        public const string Sql_QueryUserByID = 
            @"SELECT * 
                FROM [T_User] 
               WHERE [Enabled] = 1 AND [ID] = @ID";
        public const string Sql_QueryUserByName = 
            @"SELECT * 
                FROM [T_User] 
               WHERE [Enabled] = 1 
                 AND ([ID] = @UserName 
                        OR [Name] = @UserName 
                        OR LoginName = @UserName 
                        OR [Tel] = @UserName 
                        OR Email = @UserName)";
        
        #endregion

        public SecurityService() {
        }

        public UserInfo GetUserInfo() {
            T_UserDataTable userTable = new UserDataSet.T_UserDataTable();
            var dataService = DataService.Value;
            dataService.Fill(userTable, Sql_QueryUserByID, 0, 1, new DataField("@ID", SecurityPublic.CurrentUser.UserID));
            if (userTable.Count == 0)
                return null;
            return new UserInfo()
            {
                UserID = userTable[0].ID,
                UserName = userTable[0].Name
            };
        }

        public string Login(string userID, string password) {
            T_UserDataTable userTable = new UserDataSet.T_UserDataTable();
            var dataService = DataService.Value;
            dataService.Fill(userTable, Sql_QueryUserByName, 0, 1, new DataField("@UserName", userID));
            if (userTable.Count == 0)
                throw new Exception("登录失败");
            if (userTable[0].IsPasswordNull()) {
                if (password != null)
                    throw new Exception("登录失败");
            }
            else if (userTable[0].Password != SecurityPublic.ComputeHashString(password)) {
                throw new Exception("登录失败");
            }

            return userTable[0].ID;
        }
    }
}
