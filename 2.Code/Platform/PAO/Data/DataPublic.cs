using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PAO.Data {
    /// <summary>
    /// 静态类：DataPublic
    /// 数据公共类
    /// 作者：PAO
    /// </summary>
    public static class DataPublic {
        /// <summary>
        /// 默认数据连接
        /// </summary>
        public static DataConnection DataConnection;

        #region 数据类型
        public const string INT = "INT";
        public const string FLOAT = "FLOAT";
        public const string NUMBER = "NUMBER";
        public const string STRING = "STRING";
        public const string DATE = "DATE";
        public const string BOOL = "BOOL";
        public const string BINARY = "BINARY";
        public const string OBJECT = "OBJECT";

        /// <summary>
        /// 根据数据类型名称获取类型
        /// </summary>
        /// <param name="typeName">类型名称</param>
        /// <returns>类型</returns>
        public static DbType GetDbTypeByTypeName(string typeName) {
            switch (typeName) {
                case INT:
                    return DbType.Int64;
                case FLOAT:
                    return DbType.Double;
                case NUMBER:
                    return DbType.Decimal;
                case STRING:
                    return DbType.String;
                case DATE:
                    return DbType.Date;
                case BOOL:
                    return DbType.Boolean;
                case BINARY:
                    return DbType.Binary;
            }

            return DbType.Object;
        }

        public static string GetTypeNameByDbType(DbType type) {
            switch (type) {
                case DbType.AnsiString:
                case DbType.AnsiStringFixedLength:
                case DbType.String:
                case DbType.StringFixedLength:
                case DbType.Guid:
                case DbType.Xml:
                    return STRING;
                case DbType.Binary:
                    return BINARY;
                case DbType.Boolean:
                    return BOOL;
                case DbType.SByte:
                case DbType.Int16:
                case DbType.Int32:
                case DbType.Int64:
                case DbType.Byte:
                case DbType.UInt16:
                case DbType.UInt32:
                case DbType.UInt64:
                    return INT;
                case DbType.Decimal:
                case DbType.VarNumeric:
                case DbType.Currency:
                    return NUMBER;
                case DbType.Date:
                case DbType.DateTime:
                case DbType.DateTime2:
                case DbType.Time:
                case DbType.DateTimeOffset:
                    return DATE;
                case DbType.Double:
                case DbType.Single:
                    return FLOAT;
                default:
                    return OBJECT;
            }
        }

        /// <summary>
        /// 根据数据类型名称获取类型
        /// </summary>
        /// <param name="typeName">类型名称</param>
        /// <returns>类型</returns>
        public static Type GetTypeByTypeName(string typeName) {
            switch (typeName) {
                case INT:
                    return typeof(int);
                case FLOAT:
                    return typeof(double);
                case NUMBER:
                    return typeof(decimal);
                case STRING:
                    return typeof(string);
                case DATE:
                    return typeof(DateTime);
                case BOOL:
                    return typeof(bool);
                case BINARY:
                    return typeof(byte[]);
            }

            return typeof(object);
        }

        public static string GetTypeNameByType(Type type) {
            if (type.IsIntegerType()) {
                return INT;
            }
            else if (type == typeof(float) || type == typeof(double)) {
                return FLOAT;
            }
            else if (type == typeof(decimal)) {
                return NUMBER;
            }
            else if (type == typeof(DateTime)) {
                return DATE;
            }
            else if (type == typeof(bool)) {
                return BOOL;
            }
            else if (type == typeof(byte[])) {
                return BINARY;
            }
            else if (type == typeof(string)) {
                return STRING;
            }
            else {
                return OBJECT;
            }
        }
        #endregion
    }
}
