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
		private readonly IService<ProductDto> _machineService;
		private readonly IService<PumpDto> _labourService;
		private readonly IService<OutputDto> _outputService;
		private readonly IMapper _mapper;

		public AdminController(IService<ProductDto> machineService,
			IService<PumpDto> labourService,
			IService<OutputDto> outputService,
			IMapper mapper)
		{
			_machineService = machineService;
			_labourService = labourService;
			_outputService = outputService;
			_mapper = mapper;
		}

		[Authorize]
		[HttpGet]
		[Route("admin")]
		public ActionResult Index()
		{
			var laboursDtos = _labourService.GetAll();
			var machinesDtos = _machineService.GetAll();
			var outputsDtos = _outputService.GetAll();

			var model = new CompositeViewModel
			{
				Labours = _mapper.Map<IEnumerable<PumpDto>, List<PumpViewModel>>(laboursDtos),
				Machines = _mapper.Map<IEnumerable<ProductDto>, List<ProductViewModel>>(machinesDtos),
				Outputs = _mapper.Map<IEnumerable<OutputDto>, List<OutputViewModel>>(outputsDtos)
			};

			return View(model);
		}
	}
}