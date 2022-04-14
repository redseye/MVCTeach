using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DAL.Models
{
    public class DBFormModel
    {
        public string FormID { get; set; }
        public string FormName { get; set; }
        public string FormVer { get; set; }
        public int StageCode { get; set; }
        public string Device { get; set; }
        public string Other { get; set; }
        public string Status { get; set; }
        public DateTime CreateTime { get; set; }
        public string Creater { get; set; }
        public DateTime UpdateTime { get; set; }
        public string UpdateUser { get; set; }


    }
}
