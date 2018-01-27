using AutoMapper;
using EquipmentStore.BLL.Services;
using EquipmentStore.Core.Entities;
using EquipmentStore.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EquipmentStore.Web.Controllers
{
    public class ProductCategoryController : Controller
    {
        private const string TempDataMessageKey = "Message";
        private const string TempDataErrorKey = "Error";

        private readonly IService<ProductCategory> _productCategoryService;
        private readonly IMapper _mapper;

        public ProductCategoryController(IService<ProductCategory> productCategoryService,
            IMapper mapper)
        {
            _productCategoryService = productCategoryService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        [Route("admin/productcategories/create")]
        public ActionResult Create()
        {
            var model = new ProductCategoryViewModel();

            return View(model);
        }

        [HttpPost]
        [Authorize]
        [Route("admin/productcategories/create")]
        public ActionResult Create(ProductCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var entity = _mapper.Map<ProductCategoryViewModel, ProductCategory>(model);

            _productCategoryService.Add(entity);

            TempData[TempDataMessageKey] = "Новая категория была добавлена";

            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        [Authorize]
        [Route("admin/productcategories/delete/{id}")]
        public ActionResult Delete(int id)
        {
            var entityExists = _productCategoryService.CheckIfExists(id);

            if (!entityExists)
            {
                TempData[TempDataErrorKey] = "Категория с таким id не сушествует";

                return RedirectToAction("Index", "Admin");
            }

            _productCategoryService.Delete(id);

            TempData[TempDataMessageKey] = "Категория была удалена";

            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        [Route("admin/productcategories")]
        public ActionResult ReadAll()
        {
            var entities = _productCategoryService.GetAll();
            var models = _mapper.Map<IEnumerable<ProductCategory>, List<ProductCategoryViewModel>>(entities);

            return View(models);
        }

        [HttpGet]
        [Route("admin/productcategories/{id}")]
        public ActionResult Read(int id)
        {
            var entity = _productCategoryService.GetSingleOrDefault(id);

            if (entity != null)
            {
                var model = _mapper.Map<ProductCategory, ProductCategoryViewModel>(entity);

                return View(model);
            }

            TempData[TempDataErrorKey] = "Категория с таким id не сушествует";

            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        [Authorize]
        [Route("admin/productcategories/update/{id}")]
        public ActionResult Update(int id)
        {
            var entity = _productCategoryService.GetSingleOrDefault(id);

            if (entity != null)
            {
                var model = _mapper.Map<ProductCategory, ProductCategoryViewModel>(entity);

                return View(model);
            }

            TempData[TempDataErrorKey] = "Категория с таким id не сушествует";

            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        [Authorize]
        [Route("admin/productcategories/update")]
        public ActionResult Update(ProductCategoryViewModel model)
        {
            var entityExists = _productCategoryService.CheckIfExists(model.Id);

            if (!entityExists)
            {
                TempData[TempDataErrorKey] = "Категория с таким id не сушествует";

                return RedirectToAction("Index", "Admin");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var entity = _mapper.Map<ProductCategoryViewModel, ProductCategory>(model);

            _productCategoryService.Update(entity);

            TempData[TempDataMessageKey] = "Категория была обновлена";

            return RedirectToAction("Index", "Admin");
        }
    }
}