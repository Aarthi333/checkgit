using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCwithADO.Models;

namespace MVCwithADO.Controllers
{
    public class CRUDController : Controller
    {
        // GET: CRUD
        public ActionResult Index()
        {
            CRUDModel mdl = new CRUDModel();
            DataTable dt = mdl.DisplayBook();
            return View("Home",dt);
        }
        public ActionResult Insert()
        {
            CRUDModel mdl = new CRUDModel();
            DataTable dt = mdl.DisplayAuthor();
            return View("Create",dt);
        }
        public ActionResult InsertRecord(FormCollection frm, string action)
        {
            if (action == "Submit")
            {
                CRUDModel mdl = new CRUDModel();
                string title = frm["txtTitle"];
                int aid = Convert.ToInt32(frm["txtAid"]);
                double price = Convert.ToDouble(frm["txtPrice"]);
                int rowIns =  mdl.NewBookSp(title,aid,price);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit()
        {
            return View("Edit");
        }
        public ActionResult EditRecord(FormCollection frm,string action)
        {
            if (action == "Submit")
            {
                CRUDModel mdl = new CRUDModel();
                string title = frm["txtTitle"];
                double price = Convert.ToDouble(frm["txtPrice"]);
                int rowIns = mdl.EditBookSp(title, price);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        //another method without sp
        public ActionResult Update(FormCollection frm, string action)
        {
            if (action == "Submit")
            {
                CRUDModel mdl = new CRUDModel();
                string title = frm["txtTitle"];
                int aid = Convert.ToInt32(frm["txtAid"]);
                double price = Convert.ToDouble(frm["txtPrice"]);
                int bookid = Convert.ToInt32(frm["txtBid"]);
                int updRow = mdl.UpdateBook(bookid,title,aid, price);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult UpdateBook(int BookId)
        {
            CRUDModel mdl = new CRUDModel();
            DataTable dt = mdl.BookById(BookId);
            return View("Update", dt);
        }
        //deleting without using a storedprocedure
        public ActionResult Delete(int bookid)
        {
            CRUDModel mdl = new CRUDModel();
            mdl.DeleteBook(bookid);
            return RedirectToAction("Index");
        }

        public ActionResult AuthorIndex()
        {
            CRUDModel mdl = new CRUDModel();
            DataTable dt = mdl.DisplayAuthor();
            return View("HomeAuthor", dt);
        }

        public ActionResult InsertAuthor()
        {
            return View("CreateAuthor");
        }
        public ActionResult InsertAuthorRecord(FormCollection frm, string action)
        {
            if (action == "Submit")
            {
                CRUDModel mdl = new CRUDModel();
                string aname = frm["txtAuthor"];
                int rowIns = mdl.NewAuthorSp(aname);
                return RedirectToAction("AuthorIndex");
            }
            else
            {
                return RedirectToAction("AuthorIndex");
            }
        }
    }
}