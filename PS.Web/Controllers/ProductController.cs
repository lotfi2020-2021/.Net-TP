using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ps.Domain.Entities;
using PS.Service.Services_withpatterns;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PS.Web.Controllers
{
    public class ProductController : Controller
    {
        IProductService productService;
        ICategoryService categoryService;
        public ProductController(IProductService productService,ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        public ActionResult Index2()
        {
            return View(productService.GetAll()); 
        }
        // GET: ProductController
        public ActionResult Index(string filter)
        {
            if (!String.IsNullOrEmpty(filter))
                return View(productService.GetMany(p=>p.Name.Contains(filter)));
            return View(productService.GetAll());
            //return View(productService.GetAll().OrderByDescending(p=>p.Price));
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int? id)
        {
            if (id != null)
                return View(productService.GetById(id));
            return NotFound();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.mycategories = new SelectList(categoryService.GetAll(), "CategoryId", "Name");
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product p,IFormFile file)
        {
            try
            {
                //ajpout du produit dans la base
                p.ImageUrl2 = file.FileName; // maj du nom de l'image
                productService.Add(p);
                productService.Commit();

                //ajout de l'image dans le dossier
                if (file != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads",file.FileName);
                    using (System.IO.Stream stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }



                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int? id)
        {
            Product p = null;
            if (id != null)
            {
                p = productService.GetById(id);
                ViewBag.mycategories = 
                    new SelectList(categoryService.GetAll(), "CategoryId", "Name",p.Category);
                return View(p);
            }
            return NotFound();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product p)
        {
            try
            {
                //p = productService.GetById(id);
                productService.Update(p);
                productService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id!=null)
              return View(productService.GetById(id));
            return NotFound();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product p)
        {
            try
            {
                p = productService.GetById(id);
                productService.Delete(p);
                productService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
