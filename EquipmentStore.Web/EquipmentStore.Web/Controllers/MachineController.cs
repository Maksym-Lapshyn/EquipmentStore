using AutoMapper;
using EquipmentStore.BLL.Dtos;
using EquipmentStore.BLL.Services;
using EquipmentStore.Web.Models;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace EquipmentStore.Web.Controllers
{
	public class MachineController : Controller
	{
		private const string TempDataMessageKey = "Message";

		private readonly IService<MachineDto> _machineService;
		private readonly IImageService<MachineImageDto> _imageService;
		private readonly IMapper _mapper;

		public MachineController(IService<MachineDto> machineService,
			IImageService<MachineImageDto> imageService,
			IMapper mapper)
		{
			_machineService = machineService;
			_imageService = imageService;
			_mapper = mapper;
		}

		[HttpGet]
		[Route("products/create")]
		public ActionResult Create()
		{
			var model = new MachineViewModel();

			return View(model);
		}

		[HttpPost]
		[Route("products/create")]
		public ActionResult Create(MachineViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			model.ImageData = ConvertFileBaseToImageViewModel(model.ImageInput);
			model.ImageInput = null;

			var dto = _mapper.Map<MachineViewModel, MachineDto>(model);

			_machineService.Add(dto);

			TempData[TempDataMessageKey] = "Новое оборудование было добавлено";

			return RedirectToAction("Index", "Admin");
		}

		[HttpPost]
		[Route("products/delete/{id}")]
		public ActionResult Delete(int id)
		{
			_machineService.Delete(id);

			TempData[TempDataMessageKey] = "Оборудование было добавлено";

			return RedirectToAction("Index", "Admin");
		}

		[HttpGet]
		[Route("products")]
		public ActionResult ReadAll()
		{
			var models = _machineService.GetAll();
			var dtos = _mapper.Map<IEnumerable<MachineDto>, List<MachineViewModel>>(models);

			return View(dtos);
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

			TempData[TempDataMessageKey] = "Оборудование с таким id не сушествует";

			return RedirectToAction("Index", "Admin");
		}

		[HttpGet]
		[Route("products/update/{id}")]
		public ActionResult Update(int id)
		{
			var dto = _machineService.GetSingleOrDefault(id);

			if (dto != null)
			{
				var model = _mapper.Map<MachineDto, MachineViewModel>(dto);

				return View(model);
			}

			TempData[TempDataMessageKey] = "Оборудование с таким id не сушествует";

			return RedirectToAction("Index", "Admin");
		}

		[HttpPost]
		[Route("products/update/{id}")]
		public ActionResult Update(MachineViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			model.ImageData = ConvertFileBaseToImageViewModel(model.ImageInput);
			model.ImageInput = null;

			var dto = _mapper.Map<MachineViewModel, MachineDto>(model);

			_machineService.Update(dto);

			TempData[TempDataMessageKey] = "Оборудование было обновлено";

			return View();
		}

		public ActionResult AddImage(HttpPostedFileBase image)
		{
			if (image == null)
			{
				TempData[TempDataMessageKey] = "Ошибка при загрузке фотографии";

				return RedirectToAction("Index", "Admin");
			}

			var model = ConvertFileBaseToImageViewModel(image);

			var dto = _mapper.Map<ImageViewModel, MachineImageDto>(model);

			_imageService.Add(dto);

			TempData[TempDataMessageKey] = "Новая фотография была добавлена";

			return RedirectToAction("Index", "Admin");
		}

		private ImageViewModel ConvertFileBaseToImageViewModel(HttpPostedFileBase image)
		{

			var model = new ImageViewModel
			{
				Id = default(int),
				Name = image.FileName,
				MimeType = image.ContentType
			};

			using (var br = new BinaryReader(image.InputStream))
			{
				model.Data = br.ReadBytes(image.ContentLength);
			}

			return model;
		}
	}
}