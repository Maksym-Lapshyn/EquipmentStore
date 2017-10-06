using AutoMapper;
using EquipmentStore.BLL.Dtos;
using EquipmentStore.BLL.Services;
using EquipmentStore.Web.Models;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace EquipmentStore.Web.Controllers
{
	public class LabourController : Controller
	{
		private const string TempDataMessageKey = "Message";
		private const string TempDataErrorKey = "Error";

		private readonly IService<LabourDto> _labourService;
		private readonly IMapper _mapper;

		public LabourController(IService<LabourDto> labourService,
			IMapper mapper)
		{
			_labourService = labourService;
			_mapper = mapper;
		}

		[HttpGet]
		[Authorize]
		[Route("services/create")]
		public ActionResult Create()
		{
			var model = new LabourViewModel();

			return View(model);
		}

		[HttpPost]
		[Authorize]
		[Route("services/create")]
		public ActionResult Create(LabourViewModel model)
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

			var dto = _mapper.Map<LabourViewModel, LabourDto>(model);

			_labourService.Add(dto);

			TempData[TempDataMessageKey] = "Новая услуга была добавлена";

			return RedirectToAction("Index", "Admin");
		}

		[HttpPost]
		[Authorize]
		[Route("services/delete/{id}")]
		public ActionResult Delete(int id)
		{
			var dto = _labourService.GetSingleOrDefault(id);

			if (dto == null)
			{
				TempData[TempDataErrorKey] = "Услуга с таким id не сушествует";

				return RedirectToAction("Index", "Admin");
			}

			_labourService.Delete(id);

			TempData[TempDataMessageKey] = "Услуга была удалена";

			return RedirectToAction("Index", "Admin");
		}

		[HttpGet]
		[Route("services")]
		public ActionResult ReadAll()
		{
			var dtos = _labourService.GetAll();
			var models = _mapper.Map<IEnumerable<LabourDto>, List<LabourViewModel>>(dtos);

			return View(models);
		}

		[HttpGet]
		[Authorize]
		[Route("services/update/{id}")]
		public ActionResult Update(int id)
		{
			var dto = _labourService.GetSingleOrDefault(id);

			if (dto != null)
			{
				var model = _mapper.Map<LabourDto, LabourViewModel>(dto);

				return View(model);
			}

			TempData[TempDataErrorKey] = "Услуга с таким id не сушествует";

			return RedirectToAction("Index", "Admin");
		}

		[HttpPost]
		[Authorize]
		[Route("services/update/{id}")]
		public ActionResult Update(LabourViewModel model)
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

			var dto = _mapper.Map<LabourViewModel, LabourDto>(model);

			_labourService.Update(dto);

			TempData[TempDataMessageKey] = "Услуга была обновлена";

			return RedirectToAction("Index", "Admin");
		}

		private void UpdateImage(LabourViewModel model)
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