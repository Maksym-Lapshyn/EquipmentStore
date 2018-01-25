using AutoMapper;
using EquipmentStore.BLL.Services;
using EquipmentStore.Core.Entities;
using EquipmentStore.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EquipmentStore.Web.Controllers
{
    public class ProductSubCategoryController : Controller
    {
        private const string TempDataMessageKey = "Message";
        private const string TempDataErrorKey = "Error";

        private readonly IService<ProductSubCategory> _productSubCategoryService;
        private readonly IService<ProductCategory> _productCategoryService;
        private readonly IMapper _mapper;

        public ProductSubCategoryController(IService<ProductSubCategory> productSubCategoryService,
            IService<ProductCategory> productCategoryService,
            IMapper mapper)
        {
            _productSubCategoryService = productSubCategoryService;
            _productCategoryService = productCategoryService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        [Route("admin/{productcategoryid}/productsubcategories/create")]
        public ActionResult Create()
        {
            var model = new ProductSubCategoryViewModel();

            return View(model);
        }

        [HttpPost]
        [Authorize]
        [Route("admin/{productcategoryid}/productsubcategories/create")]
        public ActionResult Create(ProductSubCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var entity = _mapper.Map<ProductSubCategoryViewModel, ProductSubCategory>(model);

            _productSubCategoryService.Add(entity);

            TempData[TempDataMessageKey] = "Новая подкатегория была добавлена";

            return RedirectToAction("Index", "Admin");
        }

        [HttpDelete]
        [Authorize]
        [Route("admin/{productcategoryid}/productsubcategories/create/{id}")]
        public ActionResult Delete(int id)
        {
            var entityExists = _productSubCategoryService.CheckIfExists(id);

            if (!entityExists)
            {
                TempData[TempDataErrorKey] = "Подкатегория с таким id не сушествует";

                return RedirectToAction("Index", "Admin");
            }

            _productSubCategoryService.Delete(id);

            TempData[TempDataMessageKey] = "Подкатегория была удалена";

            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        [Route("admin/{productcategoryid}/productsubcategories")]
        public ActionResult ReadAll()
        {
            var entities = _productSubCategoryService.GetAll();
            var models = _mapper.Map<IEnumerable<ProductSubCategory>, List<ProductSubCategoryViewModel>>(entities);

            return View(models);
        }

        [HttpGet]
        [Route("admin/{productcategoryid}/productsubcategories")]
        public ActionResult ReadAllByCategory(int productCategoryId)
        {
            var category = _productCategoryService.GetSingleOrDefault(productCategoryId);

            if (category == null)
            {
                return HttpNotFound("Категория с таким id не сушествует");
            }

            var entities = category.SubCategories;
            var models = _mapper.Map<IEnumerable<ProductSubCategory>, List<ProductSubCategoryViewModel>>(entities);

            return View(models);
        }

        [HttpGet]
        [Route("admin/{productcategoryid}/productsubcategories/{id}")]
        public ActionResult Read(int id)
        {
            var entity = _productSubCategoryService.GetSingleOrDefault(id);

            if (entity != null)
            {
                var model = _mapper.Map<ProductSubCategory, ProductSubCategoryViewModel>(entity);

                return View(model);
            }

            TempData[TempDataErrorKey] = "Подкатегория с таким id не сушествует";

            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        [Authorize]
        [Route("admin/{productcategoryid}/productsubcategories/update/{id}")]
        public ActionResult Update(int id)
        {
            var entity = _productSubCategoryService.GetSingleOrDefault(id);

            if (entity != null)
            {
                var model = _mapper.Map<ProductSubCategory, ProductSubCategoryViewModel>(entity);

                return View(model);
            }

            TempData[TempDataErrorKey] = "Подкатегория с таким id не сушествует";

            return RedirectToAction("Index", "Admin");
        }

        [HttpPut]
        [Authorize]
        [Route("admin/{productcategoryid}/productsubcategories/update")]
        public ActionResult Update(ProductSubCategoryViewModel model)
        {
            var entityExists = _productSubCategoryService.CheckIfExists(model.Id);

            if (!entityExists)
            {
                TempData[TempDataErrorKey] = "Подкатегория с таким id не сушествует";

                return RedirectToAction("Index", "Admin");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var entity = _mapper.Map<ProductSubCategoryViewModel, ProductSubCategory>(model);

            _productSubCategoryService.Update(entity);

            TempData[TempDataMessageKey] = "Подкатегория была обновлена";

            return RedirectToAction("Index", "Admin");
        }
    }
}