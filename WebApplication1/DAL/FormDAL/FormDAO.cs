using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using WebApplication1.DAL.Models;
using Dapper;
using System.Data.SqlClient;

namespace WebApplication1.DAL.FormDAL
{

    public class FormDAO
    {
        private readonly string _connectString = @"Server=George\\SQLEXPRESS;Database=TestDB;Trusted_Connection=True;User ID=sa;Password=zaq1xsw2;Integrated Security=False;";

        public IEnumerable<DBFormModel> GetList()
        {
            using (var conn = new SqlConnection(_connectString))
            {
                return conn.Query<DBFormModel>("SELECT * FROM Form");
            }
        }
        public int InsertList(DBFormModel model)
        {
            using (var conn = new SqlConnection(_connectString))
            {
                var sql = @"INSERT INTO [dbo].[FORM]
                   ([FormID]
                   ,[FormName]
                   ,[FormVer]
                   ,[StageCode]
                   ,[Device]
                   ,[DocName]
                   ,[Stage]
                   ,[Other]
                   ,[Status]
                   ,[CreateTime]
                   ,[Creater]
                   ,[UpdateTime]
                   ,[UpdateUser])
             VALUES
                   (@FormID
                   ,@FormName
                   ,@FormVer
                   ,@StageCode
                   ,@Device
                   ,@DocName
                   ,@Stage
                   ,@Other
                   ,@Status
                   ,@CreateTime
                   ,@Creater
                   ,@UpdateTime
                   ,@UpdateUser)";

                var result = conn.QueryFirstOrDefault<int>(sql, model);
                return result;
            }
        }




    }
}
