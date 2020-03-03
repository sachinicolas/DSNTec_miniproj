using DSNTec_miniproj.Models;
using DSNTec_miniproj.Models.DB;
using DSNTec_miniproj.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSNTec_miniproj.Controllers
{
    public class ClientController : Controller
    {
        ClientDAO cliDB = new ClientDAO();



        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListAll()
        {
            try
            {
                return Json(cliDB.ListAll(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Add(Client c)
        {
            try
            {
                return Json(cliDB.Add(c), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetByID(int id)
        {
            try
            {
                var Client = cliDB.ListAll().Find(x => x.ClientID.Equals(id));

                return Json(Client, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Message = ex.Message }, JsonRequestBehavior.AllowGet);
            } 
        }

        public JsonResult Update(Client c)
        {
            try
            {
                return Json(cliDB.Update(c), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Message = ex.Message }, JsonRequestBehavior.AllowGet);
            } 
        }

        public JsonResult Delete(int id)
        {
            try
            {
                return Json(cliDB.Delete(id), JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { Message = ex.Message }, JsonRequestBehavior.AllowGet);
            } 
        }
    }
}