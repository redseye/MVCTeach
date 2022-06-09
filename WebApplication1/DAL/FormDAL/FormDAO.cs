using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using WebApplication1.DAL.Models;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1.DAL.FormDAL
{

    public class FormDAO
    {

        private readonly IDbConnection _conn;
        public FormDAO(IDbConnection conn)
        {
            this._conn = conn;
        }


        public IEnumerable<DBFormModel> GetList()
        {
          return this._conn.Query<DBFormModel>("SELECT * FROM Form");
        }

        public int InsertList(DBFormModel model)
        {
           var sql = @"INSERT INTO[dbo].[FORM]
           ([FormID]
           ,[FormName]
           ,[FormVer]
           ,[StageCode]
           ,[Device]
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
           ,@Other
           ,@Status
           ,@CreateTime
           ,@Creater
           ,@UpdateTime
           ,@UpdateUser)";
                var result = this._conn.QueryFirstOrDefault<int>(sql, model);
                //return conn.Query<DBFormModel>("SELECT * FORN Form");

                return result;
        }
        public int Delete(string FormID)
        {
                var sql = @"Delete [dbo].[FORM] where FormID=@FormID";
                var parameters = new DynamicParameters();
                parameters.Add("FormID", FormID, System.Data.DbType.String);
                var result = this._conn.Execute(sql, parameters);
                return result;
        }

    }
}
