using AutoMapper;
using EquipmentStore.BLL.Services;
using EquipmentStore.Core.Entities;
using EquipmentStore.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EquipmentStore.Web.Controllers
{
    public class PumpCategoryController : Controller
    {
        private const string TempDataMessageKey = "Message";
        private const string TempDataErrorKey = "Error";

        private readonly IService<PumpCategory> _pumpCategoryService;
        private readonly IMapper _mapper;

        public PumpCategoryController(IService<PumpCategory> pumpCategoryService,
            IMapper mapper)
        {
            _pumpCategoryService = pumpCategoryService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        [Route("admin/pumpcategories/create")]
        public ActionResult Create()
        {
            var model = new PumpCategoryViewModel();

            return View(model);
        }

        [HttpPost]
        [Authorize]
        [Route("admin/pumpcategories/create")]
        public ActionResult Create(PumpCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var entity = _mapper.Map<PumpCategoryViewModel, PumpCategory>(model);

            _pumpCategoryService.Add(entity);

            TempData[TempDataMessageKey] = "Новая категория была добавлена";

            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        [Authorize]
        [Route("admin/pumpcategories/delete")]
        public ActionResult Delete(int id)
        {
            var entityExists = _pumpCategoryService.CheckIfExists(id);

            if (!entityExists)
            {
                TempData[TempDataErrorKey] = "Категория с таким id не сушествует";

                return RedirectToAction("Index", "Admin");
            }

            _pumpCategoryService.Delete(id);

            TempData[TempDataMessageKey] = "Категория была удалена";

            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        [Authorize]
        [Route("admin/pumpcategories")]
        public ActionResult ReadAll()
        {
            var entities = _pumpCategoryService.GetAll();
            var models = _mapper.Map<IEnumerable<PumpCategory>, List<PumpCategoryViewModel>>(entities);

            return View(models);
        }

        [HttpGet]
        [Authorize]
        [Route("admin/pumpcategories/read")]
        public ActionResult Read(int id)
        {
            var entity = _pumpCategoryService.GetSingleOrDefault(id);

            if (entity != null)
            {
                var model = _mapper.Map<PumpCategory, PumpCategoryViewModel>(entity);

                return View(model);
            }

            TempData[TempDataErrorKey] = "Категория с таким id не сушествует";

            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        [Authorize]
        [Route("admin/pumpcategories/update")]
        public ActionResult Update(int id)
        {
            var entity = _pumpCategoryService.GetSingleOrDefault(id);

            if (entity != null)
            {
                var model = _mapper.Map<PumpCategory, PumpCategoryViewModel>(entity);

                return View(model);
            }

            TempData[TempDataErrorKey] = "Категория с таким id не сушествует";

            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        [Authorize]
        [Route("admin/pumpcategories/update")]
        public ActionResult Update(PumpCategoryViewModel model)
        {
            var entityExists = _pumpCategoryService.CheckIfExists(model.Id);

            if (!entityExists)
            {
                TempData[TempDataErrorKey] = "Категория с таким id не сушествует";

                return RedirectToAction("Index", "Admin");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var entity = _mapper.Map<PumpCategoryViewModel, PumpCategory>(model);

            _pumpCategoryService.Update(entity);

            TempData[TempDataMessageKey] = "Категория была обновлена";

            return RedirectToAction("Index", "Admin");
        }
    }
}