using AutoMapper;
using EquipmentStore.BLL.Dtos;
using EquipmentStore.BLL.Services;
using EquipmentStore.Core.Entities;
using EquipmentStore.Web.Models;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace EquipmentStore.Web.Controllers
{
	public class OutputController : Controller
	{
		private readonly OutputService _outputService;
		private readonly IMapper _mapper;

		private const string TempDataMessageKey = "Message";
		private const string TempDataErrorKey = "Error";

		public OutputController(OutputService outputService,
			IMapper mapper)
		{
			_outputService = outputService;
			_mapper = mapper;
		}

		[HttpGet]
		[Authorize]
		[Route("admin/solutions/create")]
		public ActionResult Create()
		{
			var model = new OutputViewModel();

			return View(model);
		}

		[HttpPost]
		[Authorize]
		[Route("admin/solutions/create")]
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

			TempData[TempDataMessageKey] = "Новое готовое решение было добавлено";

			return RedirectToAction("Index", "Admin");
		}

		[HttpDelete]
		[Authorize]
		[Route("admin/solutions/delete/{id}")]
		public ActionResult Delete(int id)
		{
			var entityExists = _outputService.CheckIfExists(id);

			if (!entityExists)
			{
				TempData[TempDataErrorKey] = "Готовое решение с таким id не сушествует";

				return RedirectToAction("Index", "Admin");
			}

			_outputService.Delete(id);

			TempData[TempDataMessageKey] = "Готовое решение было удалено";

			return RedirectToAction("Index", "Admin");
		}

		[HttpGet]
		[Route("admin/solutions")]
		public ActionResult ReadAll()
		{
			var entities = _outputService.GetAll();
			var models = _mapper.Map<IEnumerable<Output>, List<OutputViewModel>>(entities);

			return View(models);
		}

        [HttpGet]
        [Route("solutions")]
        public ActionResult UserReadAll()
        {
            var entities = _outputService.GetAll();
            var models = _mapper.Map<IEnumerable<Output>, List<OutputViewModel>>(entities);

            return View(models);
        }

        [HttpGet]
		[Authorize]
		[Route("admin/solutions/{id}")]
		public ActionResult Update(int id)
		{
			var entity = _outputService.GetSingleOrDefault(id);

			if (entity != null)
			{
				var model = _mapper.Map<Output, OutputViewModel>(entity);

				return View(model);
			}

			TempData[TempDataErrorKey] = "Готовое решение с таким id не сушествует";

			return RedirectToAction("Index", "Admin");
		}

		[HttpPut]
		[Authorize]
		[Route("admin/solutions")]
		public ActionResult Update(OutputViewModel model)
		{
			if (model.ImageInput == null && model.MainImage == null)
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

			TempData[TempDataMessageKey] = "Готовое решение было обновлено";

			return RedirectToAction("Index", "Admin");
		}

		private void UpdateImage(OutputViewModel model)
		{
			if (model.ImageInput == null)
			{
				return;
			}

			var id = model.MainImage?.Id ?? default(int);

			var image = new ImageViewModel
			{
				Id = id,
				Name = model.ImageInput.FileName,
				MimeType = model.ImageInput.ContentType
			};

			using (var br = new BinaryReader(model.ImageInput.InputStream))
			{
				image.Data = br.ReadBytes(model.ImageInput.ContentLength);
			}

			model.MainImage = image;
			model.ImageInput = null;
		}
	}
}