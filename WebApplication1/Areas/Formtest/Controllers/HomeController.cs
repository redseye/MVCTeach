using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebApplication1.Areas.Formtest.Models;
using WebApplication1.DAL.FormDAL;
using WebApplication1.DAL.Models;

namespace WebApplication1.Areas.Formtest.Controllers
{
    [Area(areaName:"Formtest")]
    public class HomeController : Controller
    {
        private readonly IDbConnection _conn;

        public HomeController(IDbConnection conn)
        {
            this._conn = conn;
        }

        public IActionResult Index()
        {

            FormDAO form = new FormDAO(this._conn);
            List<DBFormModel> DBmodel = form.GetList().ToList();

            List<DocListViewModel> vm = new List<DocListViewModel>();
            foreach (var model in DBmodel)
            {
                vm.Add(new DocListViewModel
                {  FormID = model.FormID,
                    DocName = model.FormName,
                    Device = model.Device,
                    Stage = model.StageCode,
                    CreateTime = model.CreateTime
                }) ;
            }
            return View(vm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DBFormModel model)
        {
            model.FormID = Guid.NewGuid().ToString();
            model.CreateTime = DateTime.Now;

            FormDAO Form = new FormDAO(this._conn);

            Form.InsertList(model);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public int Delete(string FormID)
        {

            FormDAO Form = new FormDAO(this._conn);

            Form.Delete(FormID);

            return 0;

        }


    }
}
