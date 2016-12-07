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

        #region DataCommands
        public static readonly DataCommandInfo DataCommand_QueryUserByID = new DataCommandInfo()
        {
            ID = "DataCommand_QueryUserByID",
            Sql = "SELECT * FROM [T_User] WHERE [Enabled] = 1 AND [ID] = @ID",
        };

        public static readonly DataCommandInfo DataCommand_QueryUserByName = new DataCommandInfo()
        {
            ID = "DataCommand_QueryUserByName",
            Sql = "SELECT * FROM [T_User] WHERE [Enabled] = 1 AND ([ID] = @UserName OR [Name] = @UserName OR LoginName = @UserName OR [Tel] = @UserName OR Email = @UserName)",
        };

        public static readonly DataCommandInfo DataCommand_QueryUsers = new DataCommandInfo()
        {
            ID = "DataCommand_QueryUsers",
            Sql = "SELECT * FROM [T_User]",
            DataFilter = new AndLogicFilter()
            {
                ChildFilters = new List<IDataFilter>()
                    .Append(new SqlFilter("Enabled=@Enabled", "@Enabled", "生效", System.Data.DbType.Boolean))
                    .Append(new SqlFilter("LoginName LIKE '%' + @LoginName + '%'", "@LoginName", "登录名"))
                    .Append(new SqlFilter("UserName LIKE '%' + @UserName + '%'", "@UserName", "用户名"))
                    .Append(new SqlFilter("Tel LIKE '%' + @Tel + '%'", "@Tel", "电话"))
                    .Append(new SqlFilter("Email LIKE '%' + @Email + '%'", "@Email", "电子邮箱"))
            }
        };

        #endregion

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
            dataService.Fill(userTable, DataCommand_QueryUserByName.ID, 0, 1, new DataField("@UserName", userID));
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
