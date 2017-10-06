using AutoMapper;
using EquipmentStore.BLL.Dtos;
using EquipmentStore.BLL.Services;
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
		[Route("solutions/create")]
		public ActionResult Create()
		{
			var model = new OutputViewModel();

			return View(model);
		}

		[HttpPost]
		[Authorize]
		[Route("solutions/create")]
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

			var dto = _mapper.Map<OutputViewModel, OutputDto>(model);

			_outputService.Add(dto);

			TempData[TempDataMessageKey] = "Новое готовое решение было добавлено";

			return RedirectToAction("Index", "Admin");
		}

		[HttpPost]
		[Authorize]
		[Route("solutions/delete/{id}")]
		public ActionResult Delete(int id)
		{
			var dto = _outputService.GetSingleOrDefault(id);

			if (dto == null)
			{
				TempData[TempDataErrorKey] = "Готовое решение с таким id не сушествует";

				return RedirectToAction("Index", "Admin");
			}

			_outputService.Delete(id);

			TempData[TempDataMessageKey] = "Готовое решение было удалено";

			return RedirectToAction("Index", "Admin");
		}

		[HttpGet]
		[Route("solutions")]
		public ActionResult ReadAll()
		{
			var dtos = _outputService.GetAll();
			var models = _mapper.Map<IEnumerable<OutputDto>, List<OutputViewModel>>(dtos);

			return View(models);
		}

		[HttpGet]
		[Authorize]
		[Route("solutions/update/{id}")]
		public ActionResult Update(int id)
		{
			var dto = _outputService.GetSingleOrDefault(id);

			if (dto != null)
			{
				var model = _mapper.Map<OutputDto, OutputViewModel>(dto);

				return View(model);
			}

			TempData[TempDataErrorKey] = "Готовое решение с таким id не сушествует";

			return RedirectToAction("Index", "Admin");
		}

		[HttpPost]
		[Authorize]
		[Route("solutions/update/{id}")]
		public ActionResult Update(OutputViewModel model)
		{
			if (model.ImageInput == null && model.ImageData == null)
			{
				ModelState.AddModelError("ImageInput", "Укажите картинку");
			}

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			UpdateImage(model);

			var dto = _mapper.Map<OutputViewModel, OutputDto>(model);

			_outputService.Update(dto);

			TempData[TempDataMessageKey] = "Готовое решение было обновлено";

			return RedirectToAction("Index", "Admin");
		}

		private void UpdateImage(OutputViewModel model)
		{
			if (model.ImageInput == null)
			{
				return;
			}

			var id = model.ImageData?.Id ?? default(int);

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

			model.ImageData = image;
			model.ImageInput = null;
		}
	}
}