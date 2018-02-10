using ExpressMapper;
using EquipmentStore.BLL.Services;
using EquipmentStore.Core.Entities;
using EquipmentStore.Core.Loggers;
using EquipmentStore.Web.Models;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace EquipmentStore.Web.Controllers
{
    public class OutputController : BaseController
	{
		private readonly OutputService _outputService;
		private readonly IMappingServiceProvider _mapper;

		private const string TempDataMessageKey = "Message";
		private const string TempDataErrorKey = "Error";

		public OutputController(OutputService outputService,
            IMappingServiceProvider mapper,
            ILogger logger) : base(logger)
		{
			_outputService = outputService;
			_mapper = mapper;
		}

		[HttpGet]
		[Authorize]
		[Route("admin/outputs/create")]
		public ActionResult Create()
		{
			var model = new OutputViewModel();

			return View(model);
		}

		[HttpPost]
		[Authorize]
		[Route("admin/outputs/create")]
		public ActionResult Create(OutputViewModel model)
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

			var entity = _mapper.Map<OutputViewModel, Output>(model);

			_outputService.Add(entity);

			TempData[TempDataMessageKey] = "Новое производство было добавлено";

			return RedirectToAction("Index", "Admin");
		}

		[HttpPost]
		[Authorize]
		[Route("admin/outputs/delete")]
		public ActionResult Delete(int id)
		{
			var entityExists = _outputService.CheckIfExists(id);

			if (!entityExists)
			{
				TempData[TempDataErrorKey] = "Производство с таким id не сушествует";

				return RedirectToAction("Index", "Admin");
			}

			_outputService.Delete(id);

			TempData[TempDataMessageKey] = "Производство было удалено";

			return RedirectToAction("Index", "Admin");
		}

		[HttpGet]
        [Authorize]
        [Route("admin/outputs")]
		public ActionResult ReadAll()
		{
			var entities = _outputService.GetAll();
			var models = _mapper.Map<IEnumerable<Output>, List<OutputViewModel>>(entities);

			return View(models);
		}

        [HttpGet]
        [Route("outputs")]
        public ActionResult UserReadAll()
        {
            var entities = _outputService.GetAll();
            var models = _mapper.Map<IEnumerable<Output>, List<OutputViewModel>>(entities);

            return View(models);
        }

        [HttpGet]
		[Authorize]
		[Route("admin/outputs/update")]
		public ActionResult Update(int id)
		{
			var entity = _outputService.GetSingleOrDefault(id);

			if (entity != null)
			{
				var model = _mapper.Map<Output, OutputViewModel>(entity);

				return View(model);
			}

			TempData[TempDataErrorKey] = "Производство с таким id не сушествует";

			return RedirectToAction("Index", "Admin");
		}

		[HttpPost]
		[Authorize]
		[Route("admin/outputs/update")]
		public ActionResult Update(OutputViewModel model)
		{
            if(!_outputService.CheckIfExists(model.Id))
            {
                TempData[TempDataErrorKey] = "Производство с таким id не сушествует";

                return RedirectToAction("Index", "Admin");
            }

			if (model.ImageInput == null && model.OutputImage == null)
			{
				ModelState.AddModelError("ImageInput", "Укажите картинку");
			}

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			UpdateImage(model);

			var entity = _mapper.Map<OutputViewModel, Output>(model);

			_outputService.Update(entity);

			TempData[TempDataMessageKey] = "Производство было обновлено";

			return RedirectToAction("Index", "Admin");
		}

		private void UpdateImage(OutputViewModel model)
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

			model.OutputImage = image;
			model.ImageInput = null;
		}
	}
}