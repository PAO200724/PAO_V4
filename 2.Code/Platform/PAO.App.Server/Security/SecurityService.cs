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
using static PAO.App.Server.UserDataSet;

namespace PAO.App.Server.Security
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
        #endregion

        public static readonly DataCommandInfo DataCommand_QueryUserByID = new DataCommandInfo()
        {
            ID = "DataCommand_QueryUserByID",
            Sql = "SELECT * FROM [T_User] WHERE {0}",
            DataFilter = new SqlFilter()
            {
                Name = "@ID",
                Sql = "ID = @ID"
            }
        };

        public static readonly DataCommandInfo DataCommand_QueryUser = new DataCommandInfo()
        {
            ID = "DataCommand_QueryUser",
            Sql = "SELECT * FROM [T_User] WHERE {0}",
            DataFilter = new SqlFilter()
            {
                Name = "@UserName",
                Sql = "[ID] = @UserName OR [Name] = @UserName OR LoginName = @UserName OR [Tel] = @UserName OR Email = @UserName",
            },
        };
        public SecurityService() {
        }

        public UserInfo GetUserInfo() {
            T_UserDataTable userTable = new Server.UserDataSet.T_UserDataTable();
            var dataService = ServerApplication.Default.DataService.Value;
            dataService.Fill(userTable, DataCommand_QueryUserByID.ID, 0, 1, new DataField("@ID", SecurityPublic.CurrentUser.UserID));
            if (userTable.Count == 0)
                return null;
            return new UserInfo()
            {
                UserID = userTable[0].ID,
                UserName = userTable[0].Name
            };
        }

        public string Login(string userID, string password) {
            T_UserDataTable userTable = new Server.UserDataSet.T_UserDataTable();
            var dataService = ServerApplication.Default.DataService.Value;
            dataService.Fill(userTable, DataCommand_QueryUser.ID, 0, 1, new DataField("@UserName", userID));
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
