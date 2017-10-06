using AutoMapper;
using EquipmentStore.BLL.Dtos;
using EquipmentStore.BLL.Services;
using EquipmentStore.Web.Models;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace EquipmentStore.Web.Controllers
{
	public class MachineController : Controller
	{
		private const string TempDataMessageKey = "Message";
		private const string TempDataErrorKey = "Error";

		private readonly IService<MachineDto> _machineService;
		private readonly IMapper _mapper;

		public MachineController(IService<MachineDto> machineService,
			IMapper mapper)
		{
			_machineService = machineService;
			_mapper = mapper;
		}

		[HttpGet]
		[Authorize]
		[Route("products/create")]
		public ActionResult Create()
		{
			var model = new MachineViewModel();

			return View(model);
		}

		[HttpPost]
		[Authorize]
		[Route("products/create")]
		public ActionResult Create(MachineViewModel model)
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

			var dto = _mapper.Map<MachineViewModel, MachineDto>(model);

			_machineService.Add(dto);

			TempData[TempDataMessageKey] = "Новое оборудование было добавлено";

			return RedirectToAction("Index", "Admin");
		}

		[HttpPost]
		[Authorize]
		[Route("products/delete/{id}")]
		public ActionResult Delete(int id)
		{
			var dto = _machineService.GetSingleOrDefault(id);

			if (dto == null)
			{
				TempData[TempDataErrorKey] = "Оборудование с таким id не сушествует";

				return RedirectToAction("Index", "Admin");
			}

			_machineService.Delete(id);

			TempData[TempDataMessageKey] = "Оборудование было добавлено";

			return RedirectToAction("Index", "Admin");
		}

		[HttpGet]
		[Route("products")]
		public ActionResult ReadAll()
		{
			var dtos = _machineService.GetAll();
			var models = _mapper.Map<IEnumerable<MachineDto>, List<MachineViewModel>>(dtos);

			return View(models);
		}

		[HttpGet]
		[Route("products/{id}")]
		public ActionResult Read(int id)
		{
			var dto = _machineService.GetSingleOrDefault(id);

			if (dto != null)
			{
				var model = _mapper.Map<MachineDto, MachineViewModel>(dto);

				return View(model);
			}

			TempData[TempDataErrorKey] = "Оборудование с таким id не сушествует";

			return RedirectToAction("Index", "Admin");
		}

		[HttpGet]
		[Authorize]
		[Route("products/update/{id}")]
		public ActionResult Update(int id)
		{
			var dto = _machineService.GetSingleOrDefault(id);

			if (dto != null)
			{
				var model = _mapper.Map<MachineDto, MachineViewModel>(dto);

				return View(model);
			}

			TempData[TempDataErrorKey] = "Оборудование с таким id не сушествует";

			return RedirectToAction("Index", "Admin");
		}

		[HttpPost]
		[Authorize]
		[Route("products/update/{id}")]
		public ActionResult Update(MachineViewModel model)
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
			
			var dto = _mapper.Map<MachineViewModel, MachineDto>(model);

			_machineService.Update(dto);

			TempData[TempDataMessageKey] = "Оборудование было обновлено";

			return RedirectToAction("Index", "Admin");
		}

		private void UpdateImage(MachineViewModel model)
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