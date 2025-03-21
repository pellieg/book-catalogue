using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalogue.WebUI.Controllers
{
    public class Author2Controller : Controller
    {
        // GET: Author2Controller
        public ActionResult Index()
        {
            return View();
        }

        // GET: Author2Controller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Author2Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Author2Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Author2Controller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Author2Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Author2Controller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Author2Controller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
