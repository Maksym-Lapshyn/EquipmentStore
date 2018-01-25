﻿using AutoMapper;
using EquipmentStore.BLL.Services;
using EquipmentStore.Core.Entities;
using EquipmentStore.Web.Models;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace EquipmentStore.Web.Controllers
{
    public class PumpController : Controller
	{
		private const string TempDataMessageKey = "Message";
		private const string TempDataErrorKey = "Error";

		private readonly IService<Pump> _pumpService;
        private readonly IService<PumpCategory> _pumpCategoryService;
		private readonly IMapper _mapper;

        public PumpController(IService<Pump> pumpService,
            IService<PumpCategory> pumpCategoryService,
			IMapper mapper)
		{
			_pumpService = pumpService;
            _pumpCategoryService = pumpCategoryService;
			_mapper = mapper;
		}

		[HttpGet]
		[Authorize]
		[Route("admin/pumps/create")]
		public ActionResult Create()
		{
			var model = new PumpViewModel();

			return View(model);
		}

		[HttpPost]
		[Authorize]
		[Route("admin/pumps/create")]
		public ActionResult Create(PumpViewModel model)
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

			var entity = _mapper.Map<PumpViewModel, Pump>(model);

			_pumpService.Add(entity);

			TempData[TempDataMessageKey] = "Новый насос был добавлен";

			return RedirectToAction("Index", "Admin");
		}

		[HttpDelete]
		[Authorize]
		[Route("admin/pumps/delete/{id}")]
		public ActionResult Delete(int id)
		{
			var entityExists = _pumpService.CheckIfExists(id);

			if (!entityExists)
			{
				TempData[TempDataErrorKey] = "Насос с таким id не сушествует";

				return RedirectToAction("Index", "Admin");
			}

			_pumpService.Delete(id);

			TempData[TempDataMessageKey] = "Насос был удален";

			return RedirectToAction("Index", "Admin");
		}

		[HttpGet]
		[Route("admin/pumps")]
		public ActionResult ReadAll()
		{
			var entities = _pumpService.GetAll();
			var models = _mapper.Map<IEnumerable<Pump>, List<PumpViewModel>>(entities);

			return View(models);
		}

        [HttpGet]
        [Route("pumpcategories/{pumpcategoryid}/pumps")]
        public ActionResult ReadAllByCategory(int pumpCategoryId)
        {
            var pumpCategory = _pumpCategoryService.GetSingleOrDefault(pumpCategoryId);

            if (pumpCategory == null)
            {
                return HttpNotFound("Насос с таким id не существует");
            }

            var entities = pumpCategory.Pumps;
            var models = _mapper.Map<IEnumerable<Pump>, List<PumpViewModel>>(entities);

            return View(models);
        }

        [HttpGet]
		[Authorize]
		[Route("admin/pumps/update/{id}")]
		public ActionResult Update(int id)
		{
			var entity = _pumpService.GetSingleOrDefault(id);

			if (entity != null)
			{
				var model = _mapper.Map<Pump, PumpViewModel>(entity);

				return View(model);
			}

			TempData[TempDataErrorKey] = "Насос с таким id не сушествует";

			return RedirectToAction("Index", "Admin");
		}

		[HttpPost]
		[Authorize]
		[Route("admin/pumps/update")]
		public ActionResult Update(PumpViewModel model)
		{
            var entityExists = _pumpService.CheckIfExists(model.Id);

            if (!entityExists)
            {
                TempData[TempDataErrorKey] = "Насос с таким id не сушествует";

                return RedirectToAction("Index", "Admin");
            }

            if (model.ImageInput == null && model.MainImage == null)
			{
				ModelState.AddModelError("ImageInput", "Укажите картинку");
			}

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			UpdateImage(model);

			var dto = _mapper.Map<PumpViewModel, Pump>(model);

			_pumpService.Update(dto);

			TempData[TempDataMessageKey] = "Насос был обновлен";

			return RedirectToAction("Index", "Admin");
		}

		private void UpdateImage(PumpViewModel model)
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