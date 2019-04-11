using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_web.Models;
namespace Task_web.Controllers
{

    public class TestController : Controller
    {
        TestEntities db = new TestEntities();
        // GET: Test
        public ActionResult SetDbTest()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SetDbTest(Table table)
        {
            Table tbl = new Table();
            tbl.Name = table.Name;
            db.Table.Add(tbl);
            db.SaveChanges();
            return View();
        }
        public ActionResult ShowListDb()
        {
            var item = db.Table.ToList();
            return View(item);
        }
        public ActionResult Delete(int id)
        {
            
            var item = db.Table.FirstOrDefault(x => x.Id.Equals(id));
            if (item != null)
            {
                db.Table.Remove(item);
                db.SaveChanges();
            }
            var item2 = db.Table.ToList();
            return View("ShowListDb", item2);
        }
        public ActionResult Edit(int id)
        {
            var item = db.Table.Where(x => x.Id == id).First();
            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(Table table)
        {
            var item = db.Table.Where(x => x.Id == table.Id).First();
            item.Name = table.Name;
            db.SaveChanges();
            var item2 = db.Table.ToList();
            return View("ShowListDb", item2);
        }
    }
}