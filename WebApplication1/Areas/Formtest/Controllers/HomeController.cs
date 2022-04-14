using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Areas.Formtest.Models;
using WebApplication1.DAL.FormDAL;
using WebApplication1.DAL.Models;

namespace WebApplication1.Areas.Formtest.Controllers
{
    [Area(areaName:"Formtest")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            FormDAO form = new FormDAO();
            List<DBFormModel> DBmodel = form.GetList().ToList();

            List<DocListViewModel> vm = new List<DocListViewModel>();
            foreach (var model in DBmodel)
            {
                vm.Add(new DocListViewModel
                {
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
        public IActionResult Create(DocListViewModel vm)
        {
            FormDAO form = new FormDAO();
            DBFormModel model = new DBFormModel
            {
                FormID = Guid.NewGuid().ToString(),
                FormName = vm.DocName,
                FormVer = "0",
                StageCode = vm.Stage,
                Device = vm.Device,
                Other = vm.Other,
                CreateTime = vm.CreateTime,
                Creater = ""
            };
            form.InsertList(model);

            return View();
        }

    }
}
