﻿using AutoMapper;
using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.UnitOfWork;
using System.Collections.Generic;

namespace EquipmentStore.BLL.Services
{
    public class OutputService : IService<Output>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public OutputService(IUnitOfWork unitOfWork,
			IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public Output GetSingleOrDefault(int id)
		{
			var output = _unitOfWork.OutputRepository.GetSingleOrDefault(id);

			return output;
		}

		public IEnumerable<Output> GetAll()
		{
			var outputs = _unitOfWork.OutputRepository.GetAll();

			return outputs;
		}

		public void Add(Output output)
		{
			_unitOfWork.OutputRepository.Add(output);
			_unitOfWork.Save();
		}

		public void Update(Output output)
		{
			var oldOutput = _unitOfWork.OutputRepository.GetSingleOrDefault(output.Id);
			oldOutput = _mapper.Map(output, oldOutput);

			_unitOfWork.OutputRepository.Update(oldOutput);
			_unitOfWork.Save();
		}

		public void Delete(int id)
		{
			_unitOfWork.OutputRepository.Delete(id);
			//_unitOfWork.OutputImageRepository.DeleteRange(i => i.Output.Id == id);
			_unitOfWork.Save();
		}
	}
}
