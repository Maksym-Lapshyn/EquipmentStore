using AutoMapper;
using EquipmentStore.BLL.Dtos;
using EquipmentStore.BLL.Services;
using EquipmentStore.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EquipmentStore.Web.Controllers
{
	public class LabourController : Controller
	{
		private const string TempDataMessageKey = "Message";

		private readonly IService<LabourDto> _labourService;
		private readonly IMapper _mapper;

		public LabourController(IService<LabourDto> labourService,
			IMapper mapper)
		{
			_labourService = labourService;
			_mapper = mapper;
		}

		[HttpGet]
		[Route("services/create")]
		public ActionResult Create()
		{
			var model = new LabourViewModel();

			return View(model);
		}

		[HttpPost]
		[Route("services/create")]
		public ActionResult Create(LabourViewModel model)
		{
			if (ModelState.IsValid)
			{
				return View(model);
			}

			var dto = _mapper.Map<LabourViewModel, LabourDto>(model);

			_labourService.Add(dto);

			TempData[TempDataMessageKey] = "Услуга была добавлена";

			return View();
		}

		[HttpPost]
		[Route("services/delete/{id}")]
		public ActionResult Delete(int id)
		{
			_labourService.Delete(id);

			TempData[TempDataMessageKey] = "Услуга была удалена";

			return View();
		}

		[HttpGet]
		[Route("services")]
		public ActionResult ReadAll()
		{
			var models = _labourService.GetAll();
			var dtos = _mapper.Map<IEnumerable<LabourDto>, List<LabourViewModel>>(models);

			return View(dtos);
		}

		[HttpGet]
		[Route("services/{id}")]
		public ActionResult Read(int id)
		{
			var dto = _labourService.GetSingleOrDefault(id);

			if (dto != null)
			{
				var model = _mapper.Map<LabourDto, LabourViewModel>(dto);

				return View(model);
			}

			TempData[TempDataMessageKey] = "Услуга с таким id не сушествует";

			return View();
		}

		[HttpGet]
		[Route("services/update/{id}")]
		public ActionResult Update(int id)
		{
			var dto = _labourService.GetSingleOrDefault(id);

			if (dto != null)
			{
				var model = _mapper.Map<LabourDto, LabourViewModel>(dto);

				return View(model);
			}

			TempData[TempDataMessageKey] = "Услуга с таким id не сушествует";

			return View();
		}

		[HttpPost]
		[Route("services/update/{id}")]
		public ActionResult Update(LabourViewModel model)
		{
			if (ModelState.IsValid)
			{
				return View(model);
			}

			var dto = _mapper.Map<LabourViewModel, LabourDto>(model);

			_labourService.Update(dto);

			TempData[TempDataMessageKey] = "Услуга была обновлена";

			return View();
		}
	}
}