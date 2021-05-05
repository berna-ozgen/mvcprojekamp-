using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcprojekampı.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        private static ICategoryDal EfCategoryDal()
        {
            throw new NotImplementedException();
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList()
        {

            var categoryvalues = cm.GetList();
            return View(categoryvalues);//degişkendeki degerler view e eklendi
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            //  cm.CategoryAddBL(p);
            CategoryValidator categoryValidator = new CategoryValidator();

            ValidationResult results = categoryValidator.Validate(p);
            if (results.IsValid)
            {
                cm.CategoryAddBL(p);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage); 
                }
            }
            return RedirectToAction("GetCategoryList");

        }
    }
}