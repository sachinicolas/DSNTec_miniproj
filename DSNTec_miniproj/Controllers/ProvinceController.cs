using DSNTec_miniproj.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSNTec_miniproj.Controllers
{
    public class ProvinceController : Controller
    {
        ProvinceDAO provDB = new ProvinceDAO();



        //public ActionResult Index()
        //{
        //    return View();
        //}

        public JsonResult ListAll()
        {
            try
            {
                return Json(provDB.ListAll(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new {Message = ex.Message}, JsonRequestBehavior.AllowGet);
            }
        }
    }
}