using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SQLDBTool
{
    public class SQLDBHelper
    {
        private readonly static string STRDATABASECONNECTION = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FCIADataBase;Integrated Security=True";
        private readonly static string TABLE_NAME_USERS = "Users";
        private readonly static string TABLE_NAME_CHECK = "CheckIn";
        private readonly static string TABLE_USERS_NAME = "姓名";
        private readonly static string TABLE_USERS_ID = "身份号码";
        private readonly static string TABLE_USERS_FACEIMAGESPATH = "面部图片路径";
        private readonly static string TABLE_CHECK_ID = "身份号码";
        private readonly static string TABLE_CHECK_STATUE = "状态";
        private readonly static string TABLE_CHECK_TIME = "时间";
        private readonly static string TIME_FORMAT = "yyyy-MM-dd";



        private SqlConnection p_sqlconn = null;
        /// <summary>
        /// SQLDBHelper 构造方法
        /// </summary>
        public SQLDBHelper()
        {
            this.p_sqlconn = new SqlConnection(STRDATABASECONNECTION);
            try
            {
                p_sqlconn.Open();
                Console.WriteLine("数据库打开成功...");
            }
            catch (Exception ex)
            {
                Console.WriteLine("数据库打开失败...\n>>>> " + ex.Message);
            }
        }

        /// <summary>
        /// 查询Users中的所有信息
        /// </summary>
        /// <returns>DataSet.Tables[0]</returns>
        public DataTable queryAllUsers()
        {
            string sql = "select " + TABLE_USERS_NAME + "," + TABLE_USERS_ID + " from " + TABLE_NAME_USERS;
            DataSet dataSet = this.ExcuteSQL(sql);
            return dataSet.Tables[0];
        }
        /// <summary>
        /// 查询 已到 或 未到的 Users
        /// </summary>
        /// <param name="hasCome">true：已到  false：未到</param>
        /// <returns>DataSet.Table[0]</returns>
        public DataTable queryUsersByState(bool hasCome)
        {
            string timeNow = System.DateTime.Now.ToString(TIME_FORMAT);
            string sql = "select Users." + TABLE_USERS_NAME + ",Users." + TABLE_USERS_ID + " from " + TABLE_NAME_USERS + " full join " + TABLE_NAME_CHECK
                + " on Users." + TABLE_USERS_ID + " = CheckIn." + TABLE_CHECK_ID + " where CheckIn." + TABLE_CHECK_TIME + "='" + timeNow + "' and CheckIn." + TABLE_CHECK_STATUE + "=";
            if (hasCome == true)
            {
                sql += 1;
            }
            else
            {
                sql += 0;
            }

            DataSet dataSet = this.ExcuteSQL(sql);

            return dataSet.Tables[0];
        }

        /// <summary>
        /// 查询某用户是否已到
        /// </summary>
        /// <param name="id">身份号码</param>
        /// <returns>true：已到  false：未到</returns>
        private bool HasCome(string id)
        {

            string timeNow = System.DateTime.Now.ToString(TIME_FORMAT);
            string sql = "select * from " + TABLE_NAME_CHECK
                + " where " + TABLE_CHECK_STATUE + "=" + 1 + " and " + TABLE_CHECK_TIME + "='" + timeNow + "' and " + TABLE_CHECK_ID + "= '" + id+"'";
            SqlCommand sqlCmd = this.GetSqlCommand(sql);
            SqlDataReader sqlDataReader = this.GetSqlDataReader(sqlCmd);
            bool result = sqlDataReader.HasRows;
            sqlDataReader.Close();
            sqlCmd.Dispose();
            return result;
        }
        /// <summary>
        /// 查询是否向CheckIn表中填入新的时间列
        /// </summary>
        /// <returns>true：已经插入 false：未插入</returns>
        private bool HasInsertNewTime(string timeNow)
        {

            string sql = "select * from " + TABLE_NAME_CHECK + " where " + TABLE_CHECK_TIME + "='" + timeNow + "'";
            SqlCommand sqlCmd = this.GetSqlCommand(sql);
            SqlDataReader sqlReader = this.GetSqlDataReader(sqlCmd);
            bool result = sqlReader.HasRows;
            sqlReader.Close();
            sqlCmd.Dispose();
            return result;
        }
        /// <summary>
        /// 向 CheckIn 表中插入所有用户新时间的行
        /// </summary>
        /// <param name="timeNow">当前时间</param>
        public void UpdateCheckInTable(string timeNow)
        {
            if (this.HasInsertNewTime(timeNow) == false)
            {
                string sql = "select " + TABLE_USERS_ID + " from " + TABLE_NAME_USERS;
                SqlCommand sqlCmd = this.GetSqlCommand(sql);
                SqlDataReader sqlDatareader = this.GetSqlDataReader(sqlCmd);
                LinkedList<string> ids = new LinkedList<string>();
                while (sqlDatareader.Read())
                {
                    ids.AddLast(sqlDatareader.GetValue(0).ToString());
                }
                sqlDatareader.Close();
                sqlCmd.Dispose();
                foreach (string id in ids)
                {
                    string tmp = "insert into " + TABLE_NAME_CHECK
                        + "(" + TABLE_CHECK_ID + ", " + TABLE_CHECK_STATUE + ", " + TABLE_CHECK_TIME + ")"
                        + "values (" + "'" + id + "'," + 0 + ",'" + timeNow + "')";
                    this.ExcuteSQL(tmp);
                    Console.WriteLine(">>>>> " + tmp);
                }
            }
        }

        /// <summary>
        /// 更新用户签到状态
        /// </summary>
        /// <param name="id">用户的身份号码 id</param>
        public void UpdateUserStatue(string id)
        {
            if (this.HasCome(id) == false)
            {
                string timeNow = System.DateTime.Now.ToString(TIME_FORMAT);
                string sql = "update " + TABLE_NAME_CHECK + " set " + TABLE_CHECK_STATUE + " = 1"
                    + " where " + TABLE_CHECK_ID + " = '" + id + "' and " + TABLE_CHECK_TIME + " = '" + timeNow + "'";
                Console.WriteLine("UpdateUserStatue>>>>>>  " + sql);
                this.ExcuteSQL(sql);
            }
        }

        /// <summary>
        /// 获取用户面部图片的路径
        /// </summary>
        /// <param name="id">用户身份号码 id</param>
        /// <returns>面部图片路径</returns>

        public string SelectFaceImagesPath(string id)
        {
            string path = null;
            if (this.HasCome(id) == false)
            {
                string timeNow = System.DateTime.Now.ToString(TIME_FORMAT);
                string sql = "select " + TABLE_USERS_FACEIMAGESPATH + " from " + TABLE_NAME_USERS
                    + " where " + TABLE_USERS_ID + " = '" + id+"'";
                SqlCommand sqlCmd = this.GetSqlCommand(sql);
                SqlDataReader dataReader = this.GetSqlDataReader(sqlCmd);
                while (dataReader.Read())
                {
                    path = dataReader.GetValue(0).ToString();
                }
                dataReader.Close();
                Console.WriteLine("ImagesPath : >>>>>>>" + path);
            }
            return path;
        }

        /// <summary>
        /// 执行 SQL 语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="returnResult">是否有返回结果</param>
        /// <returns>返回结果 DataSet</returns>
        private DataSet ExcuteSQL(string sql)
        {
            SqlCommand sqlCmd = this.GetSqlCommand(sql);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCmd;
            DataSet dataSet = new DataSet();
            try
            {
                sqlDataAdapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(">>>>> " + ex.Message);
            }
            sqlDataAdapter.Dispose();
            sqlCmd.Dispose();
            return dataSet;
        }
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="influenced">是否返回受影响行数</param>
        /// <returns>受影响行数</returns>
        private int ExcuteSQL(string sql, bool influenced = false)
        {
            int influencedRows = 0;
            SqlCommand sqlCmd = this.GetSqlCommand(sql);
            if (influenced == true)
            {
                influencedRows = sqlCmd.ExecuteNonQuery();
            }
            sqlCmd.Dispose();
            return influencedRows;
        }

        /// <summary>
        /// 获取 SqlCommand 对象
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>SqlCommand 实例对象</returns>
        private SqlCommand GetSqlCommand(string sql)
        {
            SqlCommand sqlcmd = new SqlCommand(sql, this.p_sqlconn);
            return sqlcmd;
        }

        private SqlDataReader GetSqlDataReader(SqlCommand sqlcmd)
        {
            SqlDataReader sqlDataReader = sqlcmd.ExecuteReader();
            return sqlDataReader;
        }
        /// <summary>
        /// 如果数据库为打开状态，则关闭数据库连接
        /// </summary>
        public void Close()
        {
            if (this.p_sqlconn.State == ConnectionState.Open)
            {
                this.p_sqlconn.Close();
            }
        }
        /// <summary>
        /// 获取数据库连接状态
        /// </summary>
        /// <returns>返回 ConnectionState </returns>
        public ConnectionState DBStatus()
        {
            return this.p_sqlconn.State;
        }
    }
}
