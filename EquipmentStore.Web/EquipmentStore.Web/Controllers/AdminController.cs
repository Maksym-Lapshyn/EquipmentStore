using AutoMapper;
using EquipmentStore.BLL.Dtos;
using EquipmentStore.BLL.Services;
using EquipmentStore.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EquipmentStore.Web.Controllers
{
	public class AdminController : Controller
	{
		private readonly IService<MachineDto> _machineService;
		private readonly IService<LabourDto> _labourService;
		private readonly IMapper _mapper;

		public AdminController(IService<MachineDto> machineService,
			IService<LabourDto> labourService,
			IMapper mapper)
		{
			_machineService = machineService;
			_labourService = labourService;
			_mapper = mapper;
		}

		[HttpGet]
		[Route("admin")]
		public ActionResult Index()
		{
			var laboursDtos = _labourService.GetAll();
			var machinesDtos = _machineService.GetAll();

			var model = new CompositeViewModel
			{
				Labours = _mapper.Map<IEnumerable<LabourDto>, List<LabourViewModel>>(laboursDtos),
				Machines = _mapper.Map<IEnumerable<MachineDto>, List<MachineViewModel>>(machinesDtos)
			};

			return View(model);
		}
	}
}