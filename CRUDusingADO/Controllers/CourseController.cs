using CRUDusingADO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDusingADO.Controllers
{
    public class CourseController : Controller
    {

        CourseDAL cd;
        IConfiguration configuration;
        
        // GET: CourseController

        public CourseController(IConfiguration configuration)
        {
            this.configuration = configuration;
            cd = new CourseDAL(this.configuration);
        }
        public ActionResult Index()
        {
            return View(cd.GetCourse());
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            var course = cd.GetCourseById(id);
            return View(course);
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            try
            {
                int result = cd.AddCourse(course);
                if (result >= 1)
                {
                    return RedirectToAction("index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            var cousre = cd.GetCourseById(id);
            return View(cousre);
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course course)
        {
            try
            {
                int result = cd.UpdateCourse(course);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Delete/5
        public ActionResult Delete(int id)
        {
            var course = cd.GetCourseById(id);
            return View(course);
        }

        // POST: CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = cd.DeleteCourse(id);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
