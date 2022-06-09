using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Areas.Formtest.Models
{
    public class DocListViewModel
    {
        public string FormID { get; set; }
        /// <summary>
        /// 文件名稱
        /// </summary>

        [Display(Name = "文件名稱")]
        public string DocName { get; set; }

        /// <summary>
        /// 站點
        /// </summary>
        [Display(Name = "站點")]
        public int Stage { get; set; }

        /// <summary>
        /// 產品
        /// </summary>
        [Display(Name = "產品")]
        public string Device { get; set; }

        public string Other { get; set; }

        /// <summary>
        /// 建單時間
        /// </summary>
        [Display(Name = "建單時間")]
        public DateTime CreateTime { get; set; }

    }
}
