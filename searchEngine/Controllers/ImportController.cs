using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;

namespace searchEngine.Controllers
{
    public class ImportController : Controller
    {

        /// <summary>
        /// 判斷副檔名取得WorkBook實例，取得檔案內容
        /// </summary>
        /// <returns></returns>
        private IWorkbook GetWorkbook(string extension, IFormFile file)
        { 
            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            Stream stream = new MemoryStream(ms.ToArray());
            switch (extension)
            {
                case ".xls":
                    return new HSSFWorkbook(stream);
                case ".xlsx":
                case ".xlsm":
                    return new XSSFWorkbook(stream);
                default:
                    return null;
            }
        }


        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {
            try
            {
                //檢查是否有選擇檔案
                if (file != null)
                {
                    //檢查檔案是否有內容
                    if (file.Length > 0)
                    {
                        //取得副檔名
                        string extension = Path.GetExtension(file.FileName);

                        IWorkbook wb = GetWorkbook(extension, file);

                        if (wb == null)
                        {
                            ViewData["Message"] = "請上傳.xls or .xlsx or .xlsm 的檔案";
                            return Redirect("~/");
                        }
                        //取得第一個工作表
                        ISheet sheet = wb.GetSheetAt(0);
                        //取得標題列
                        IRow header = sheet.GetRow(0);

                        //走訪所有資料列(排除標題列)
                        for (int row = 1; row <= sheet.LastRowNum; row++)
                        {
                            //驗證不是空白列
                            if (sheet.GetRow(row) != null)
                            {
                                //走訪所有資料欄
                                for (int column = 0; column < header.LastCellNum; column++)
                                {
                                    var data = sheet.GetRow(row).GetCell(column).ToString();

                                    //do something
                                }
                            }
                        }
                        ViewData["Message"] = "上傳成功";
                    }
                    else
                    {
                        ViewData["Message"] = "上傳失敗，檔案內沒任何資料";
                    }
                }
                else
                {
                    ViewData["Message"] = "請選擇檔案";
                }
            }
            catch (Exception ex)
            {
                ViewData["Message"] = $"上傳失敗，詳細原因:{ex.Message}";
            }
            return Redirect("~/");
        }
    }
}
