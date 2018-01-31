using AutoMapper;
using EquipmentStore.BLL.Services;
using EquipmentStore.Core.Entities;
using EquipmentStore.Core.Exceptions;
using EquipmentStore.Core.Loggers;
using EquipmentStore.Web.Models;
using System.IO;
using System.Web.Mvc;

namespace EquipmentStore.Web.Controllers
{
    public class ProductController : BaseController
    {
        private const string TempDataMessageKey = "Message";
        private const string TempDataErrorKey = "Error";

        private readonly IService<Product> _productService;
        private readonly IService<ProductSubCategory> _productSubCategoryService;
        private readonly IMapper _mapper;

        public ProductController(IService<Product> productService,
            IService<ProductSubCategory> productSubCategoryService,
            IMapper mapper,
            ILogger logger) : base(logger)
        {
            _productService = productService;
            _productSubCategoryService = productSubCategoryService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        [Route("admin/products/create")]
        public ActionResult Create(int subcategoryId)
        {
            var model = new ProductViewModel
            {
                ProductSubCategoryId = subcategoryId
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        [Route("admin/products/create")]
        public ActionResult Create(ProductViewModel model)
        {
            if (model.ImageInput == null)
            {
                ModelState.AddModelError("ImageInput", "Укажите картинку");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            UpdateImage(model);

            var entity = _mapper.Map<ProductViewModel, Product>(model);

            _productService.Add(entity);

            TempData[TempDataMessageKey] = "Новое оборудование было добавлено";

            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        [Authorize]
        [Route("admin/products/delete")]
        public ActionResult Delete(int id)
        {
            var entityExists = _productService.CheckIfExists(id);

            if (!entityExists)
            {
                TempData[TempDataErrorKey] = "Оборудование с таким id не сушествует";

                return RedirectToAction("Index", "Admin");
            }

            _productService.Delete(id);

            TempData[TempDataMessageKey] = "Оборудование было удалено";

            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        [Route("products/read")]
        public ActionResult UserRead(int id)
        {
            var entity = _productService.GetSingleOrDefault(id);

            if (entity == null)
            {
                throw new NotFoundException();
            }

            var model = _mapper.Map<Product, ProductViewModel>(entity);

            return View(model);
        }

        [HttpGet]
        [Authorize]
        [Route("admin/products/update")]
        public ActionResult Update(int id)
        {
            var entity = _productService.GetSingleOrDefault(id);

            if (entity != null)
            {
                var model = _mapper.Map<Product, ProductViewModel>(entity);

                return View(model);
            }

            TempData[TempDataErrorKey] = "Оборудование с таким id не сушествует";

            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        [Authorize]
        [Route("admin/products/update")]
        public ActionResult Update(ProductViewModel model)
        {
            var entityExists = _productService.CheckIfExists(model.Id);

            if (!entityExists)
            {
                TempData[TempDataErrorKey] = "Оборудование с таким id не сушествует";

                return RedirectToAction("Index", "Admin");
            }

            if (model.ImageInput == null && model.ProductImage == null)
            {
                ModelState.AddModelError("ImageInput", "Укажите картинку");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            UpdateImage(model);

            var entity = _mapper.Map<ProductViewModel, Product>(model);

            _productService.Update(entity);

            TempData[TempDataMessageKey] = "Оборудование было обновлено";

            return RedirectToAction("Index", "Admin");
        }

        private void UpdateImage(ProductViewModel model)
        {
            if (model.ImageInput == null)
            {
                return;
            }

            var image = new ImageViewModel
            {
                Id = model.Id,
                Name = model.ImageInput.FileName,
                MimeType = model.ImageInput.ContentType
            };

            using (var br = new BinaryReader(model.ImageInput.InputStream))
            {
                image.Data = br.ReadBytes(model.ImageInput.ContentLength);
            }

            model.ProductImage = image;
            model.ImageInput = null;
        }
    }
}