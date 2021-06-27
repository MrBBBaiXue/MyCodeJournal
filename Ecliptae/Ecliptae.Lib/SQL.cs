using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Ecliptae.Lib
{
    public class SQL
    {
        /// <summary>
        /// 查询类型索引
        /// </summary>
        /// <param name="t">目标表</param>
        /// <param name="fieldName">需要查询的字段名</param>
        /// <returns></returns>
        private static int QueryMySqlDbTypeIndex(TablesDesc t, string fieldName)
        {
            int index = -1;
            for (int i = 0; i < t.FieldType.Count; i++)
            {
                if (t.FieldName[i] == fieldName)
                {
                    index = i;
                }
            }
            return index;
        }
        /// <summary>
        /// 处理命令并执行插入操作
        /// </summary>
        /// <param name="t">插入目标表的实例</param>
        /// <param name="parameters">对应参数列表</param>
        /// <returns>受影响的行数</returns>
        public static int Insert(TablesDesc t, object[] parameters)
        {
            if (t is null)
            {
                throw new Exception("Please Choose Table");
            }
            if (t.FieldName.Length != parameters.Length)
            {
                throw new Exception("Please Input Parameters Correctly");
            }

            var command = $"INSERT INTO {t.TableName.ToString().ToUpper()} VALUES(";
            MySqlParameter[] paralist = new MySqlParameter[t.FieldType.Count];

            for (int i = 0; i < t.FieldType.Count; i++)
            {
                if (i == t.FieldType.Count - 1)
                {
                    command += $"?{t.FieldName[i]})";
                    var pn = new MySqlParameter()
                    {
                        ParameterName = t.FieldName[i],
                        MySqlDbType = t.FieldType[i],
                        Value = parameters[i]
                    };
                    paralist[i] = pn;
                    break;
                }
                command += $"?{t.FieldName[i]},";
                var p = new MySqlParameter()
                {
                    ParameterName = t.FieldName[i],
                    MySqlDbType = t.FieldType[i],
                    Value = parameters[i]
                };
                paralist[i] = p;
            }

            Console.WriteLine(command);

            foreach (var i in paralist)
            {
                Console.WriteLine(i.ParameterName + "///" + i.MySqlDbType + "///" + i.Value);
            }

            int val;
            try
            {
                val = SQLHelper.ExecuteNonQuery(
                        SQLHelper.Conn,
                        CommandType.Text,
                        command,
                        paralist);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                val = -1;
            }

            Console.WriteLine(val);

            return val;
        }


        /// <summary>
        /// 处理命令并执行删除操作
        /// </summary>
        /// <param name="t">删除目标行所在表的实例</param>
        /// <param name="aimField">目标字段</param>
        /// <param name="Value">目标值</param>
        /// <returns></returns>
        public static int Delete(TablesDesc t, string aimField, object Value)
        {
            if (t is null)
            {
                throw new Exception("Please Choose Table");
            }

            var command = $"DELETE FROM " +
                $"{t.TableName.ToString().ToUpper()} " +
                $"WHERE {aimField}=?{aimField} ";

            var parameter = new MySqlParameter()
            {
                ParameterName = aimField,
                MySqlDbType = t.FieldType[QueryMySqlDbTypeIndex(t, aimField)],
                Value = Value
            };

            Console.WriteLine(command);

            int val;
            try
            {
                val = SQLHelper.ExecuteNonQuery(
                        SQLHelper.Conn,
                        CommandType.Text,
                        command,
                        parameter);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                val = -1;
            }

            Console.WriteLine(val);

            return val;
        }

        /// <summary>
        /// 处理命令并执行更新操作
        /// </summary>
        /// <param name="t">更新目标所在表的实例</param>
        /// <param name="limitedField">限制条件字段名</param>
        /// <param name="limitedValue">限制条件值</param>
        /// <param name="aimField">更新目标字段名</param>
        /// <param name="newValue">更新目标的新值</param>
        /// <returns></returns>
        public static int Update(TablesDesc t,
            string limitedField,
            object limitedValue,
            string aimField,
            object newValue)
        {
            if (t is null)
            {
                throw new Exception("Please Choose Table");
            }

            var command = $"UPDATE {t.TableName.ToString().ToUpper()} " +
                $"SET {aimField}=?{aimField} " +
                $"WHERE {limitedField}=?{limitedField}";

            var pAimField = new MySqlParameter()
            {
                ParameterName = aimField,
                MySqlDbType = t.FieldType[QueryMySqlDbTypeIndex(t, aimField)],
                Value = newValue
            };
            var pLimitedField = new MySqlParameter()
            {
                ParameterName = limitedField,
                MySqlDbType = t.FieldType[QueryMySqlDbTypeIndex(t, limitedField)],
                Value = limitedValue
            };


            Console.WriteLine(command);

            int val;
            try
            {
                val = SQLHelper.ExecuteNonQuery(
                        SQLHelper.Conn,
                        CommandType.Text,
                        command,
                        new MySqlParameter[] {
                            pAimField,
                            pLimitedField
                        });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                val = -1;
            }

            Console.WriteLine(val);

            return val;
        }

        /// <summary>
        /// 单条件查询/范围查询
        /// </summary>
        /// <param name="t">需要查询表的实例</param>
        /// <param name="queryAim">查询字段</param>
        /// <param name="queryValue">限定值/目标值</param>
        /// <param name="sort">对结果排序，默认不排序，升序为asc，降序为desc</param>
        /// <param name="sortBy">根据字段排序</param>
        /// <param name="limitedOperator">查询操作符，默认是 = </param>
        /// <param name="limitedStatement">范围查询的条件</param>
        /// <returns>一个MysqlDataReader对象</returns>
        public static MySqlDataReader Retrieve(
            TablesDesc t,
            string queryAim,
            object queryValue,
            string sort = null,
            string sortBy = null,
            string limitedOperator = "=",
            string limitedStatement = null)
        {
            if (t is null)
            {
                throw new Exception("Please Choose Table");
            }

            var command = limitedStatement == null ?
                            ($"SELECT * FROM {t.TableName.ToString().ToUpper()} " +
                            $"WHERE {queryAim} {limitedOperator} ?{queryAim}" +
                            (sort == null ? string.Empty : $" ORDER BY {sortBy} {sort}"))
                            :
                            ($"SELECT * FROM {t.TableName.ToString().ToUpper()} " +
                            $"WHERE {queryAim} {limitedStatement}" +
                            (sort == null ? string.Empty : $" ORDER BY {sortBy} {sort}"));

            Console.WriteLine(command);

            try
            {
                if (limitedStatement == null)
                {
                    var parameter = new MySqlParameter()
                    {
                        ParameterName = queryAim,
                        MySqlDbType = t.FieldType[QueryMySqlDbTypeIndex(t, queryAim)],
                        Value = queryValue
                    };
                    return SQLHelper.ExecuteReader(
                        SQLHelper.Conn,
                        CommandType.Text,
                        command,
                        parameter
                        );
                }
                else
                {
                    return SQLHelper.ExecuteReader(
                        SQLHelper.Conn,
                        CommandType.Text,
                        command,
                        null
                        );
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// 表查询
        /// </summary>
        /// <param name="t">需要查询的表</param>
        /// <returns>一个MysqlDataReader对象</returns>
        public static MySqlDataReader Retrieve(TablesDesc t)
        {
            if (t is null)
            {
                throw new Exception("Please Choose Table");
            }

            var command = $"SELECT * FROM {t.TableName.ToString().ToUpper()}";

            Console.WriteLine(command);

            try
            {
                return SQLHelper.ExecuteReader(
                    SQLHelper.Conn,
                    CommandType.Text,
                    command,
                    null
                );
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// 多条件查询
        /// </summary>
        /// <param name="t">需要查询的表</param>
        /// <param name="queryAim">查询的目标字段名</param>
        /// <param name="sort">对结果排序，默认不排序，升序为asc，降序为desc</param>
        /// <param name="sortBy">根据字段排序</param>
        /// <param name="queryValue">相对应的值</param>
        /// <param name="model">查询模式，默认为and，可选or</param>
        /// <returns>一个MysqlDataReader对象</returns>
        public static MySqlDataReader Retrieve(
            TablesDesc t,
            string[] queryAim,
            object[] queryValue,
            string model = "and",
            string sort = null,
            string sortBy = null)
        {
            if (t is null)
            {
                throw new Exception("Please Choose Table");
            }
            if (queryAim.Length != queryValue.Length)
            {
                throw new Exception("Please Input QueryList Currectly");
            }
            var command = $"SELECT * FROM {t.TableName.ToString().ToUpper()} WHERE ";
            MySqlParameter[] paralist = new MySqlParameter[queryAim.Length];

            for (int i = 0; i < queryAim.Length; i++)
            {
                if (i == queryAim.Length - 1)
                {
                    command += $"{queryAim[i]} = ?{queryAim[i]}";
                    var pi = new MySqlParameter()
                    {
                        ParameterName = queryAim[i],
                        MySqlDbType = t.FieldType[QueryMySqlDbTypeIndex(t, queryAim[i])],
                        Value = queryValue[i]
                    };
                    paralist[i] = pi;
                    break;
                }
                command += $"{queryAim[i]} = ?{queryAim[i]} {model} ";
                var p = new MySqlParameter()
                {
                    ParameterName = queryAim[i],
                    MySqlDbType = t.FieldType[QueryMySqlDbTypeIndex(t, queryAim[i])],
                    Value = queryValue[i]
                };
                paralist[i] = p;
            }
            command += sort == null ? string.Empty : $" ORDER BY {sortBy} {sort}";

            Console.WriteLine(command);
            try
            {
                return SQLHelper.ExecuteReader(SQLHelper.Conn,
                                                CommandType.Text,
                                                command,
                                                paralist);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
    public enum Tables
    {
        Users,
        Items,
        Orders,
        Comments
    }
    public class TablesDesc
    {
        public readonly Tables TableName;
        public readonly List<MySqlDbType> FieldType;
        public readonly string[] FieldName;
        public TablesDesc(Tables t)
        {
            if (t == Tables.Users)
            {
                FieldName = new string[]
                {
                    "guid",
                    "name",
                    "password",
                    "balance",
                    "level"
                };
                FieldType = new List<MySqlDbType>
                {
                    MySqlDbType.VarChar,
                    MySqlDbType.VarChar,
                    MySqlDbType.VarChar,
                    MySqlDbType.Double,
                    MySqlDbType.Int32
                };
            }
            else if (t == Tables.Items)
            {
                FieldName = new string[]
                {
                    "guid",
                    "name",
                    "description",
                    "price",
                    "storage",
                    "owner"
                };
                FieldType = new List<MySqlDbType>
                {
                    MySqlDbType.VarChar,
                    MySqlDbType.VarChar,
                    MySqlDbType.Text,
                    MySqlDbType.Double,
                    MySqlDbType.Int32,
                    MySqlDbType.VarChar
                };
            }
            else if (t == Tables.Orders)
            {
                FieldName = new string[]
                {
                    "guid",
                    "owner",
                    "info"
                };
                FieldType = new List<MySqlDbType>
                {
                    MySqlDbType.VarChar,
                    MySqlDbType.VarChar,
                    MySqlDbType.Text
                };
            }
            else if (t == Tables.Comments)
            {
                FieldName = new string[]
                {
                    "guid",
                    "owner",
                    "item",
                    "content",
                    "star"
                };
                FieldType = new List<MySqlDbType>
                {
                    MySqlDbType.VarChar,
                    MySqlDbType.VarChar,
                    MySqlDbType.VarChar,
                    MySqlDbType.Text,
                    MySqlDbType.Int32
                };
            }
            else
            {
                throw new Exception("NotFoundThisTable");
            }
        }
    }

    public class SQLConfig
    {

    }
}
