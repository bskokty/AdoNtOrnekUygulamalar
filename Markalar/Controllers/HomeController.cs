using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Markalar.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(Models.Marka.MarkalariGetir());

        }
        public ActionResult YeniMarka(FormCollection frm)
        {

            if (frm.Count > 0)
            {

                bool bld = Models.Marka.markaekle(frm[0], frm[1]);
                if (bld)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }

            }
            return View();

        }
        public ActionResult Guncelle(FormCollection frm)
        {

            int mID = Convert.ToInt32(Request.QueryString["ID"]);


            if (frm.Count == 0)
            {
                Models.Marka marka = Models.Marka.markaGetir(mID);

                return View("/Views/Home/YeniMarka.cshtml", marka);

            }


            else
            {
                bool sonuc = Models.Marka.guncelle(mID, frm[0], frm[1]);

                if (sonuc)
                {
                        return RedirectToAction("Index");
                }
                else
                {
                        return View();
                    
                }


            }


            return View();

        }



        public ActionResult Delete(FormCollection frm)
        {

            int mID = Convert.ToInt32(Request.QueryString["ID"]);

            bool sonuc = Models.Marka.sil(mID);
            if (sonuc)
            {
                return RedirectToAction("Index");
            }
             return View();

           

        }
    }
}