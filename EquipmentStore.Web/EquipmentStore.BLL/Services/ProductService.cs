using AutoMapper;
using EquipmentStore.BLL.Dtos;
using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.UnitOfWork;
using System.Collections.Generic;

namespace EquipmentStore.BLL.Services
{
	public class ProductService : IService<Product>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ProductService(IUnitOfWork unitOfWork,
			IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public Product GetSingleOrDefault(int id)
		{
			var product = _unitOfWork.ProductRepository.GetSingleOrDefault(id);

			return product;
		}

		public IEnumerable<Product> GetAll()
		{
			var products = _unitOfWork.ProductRepository.GetAll();

			return products;
		}

		public void Add(Product product)
		{
			_unitOfWork.ProductRepository.Add(product);
			_unitOfWork.Save();
		}

		public void Update(Product product)
		{
			var oldProduct = _unitOfWork.ProductRepository.GetSingleOrDefault(product.Id);
			oldProduct = _mapper.Map(product, oldProduct);

			_unitOfWork.ProductRepository.Update(oldProduct);
			_unitOfWork.Save();
		}

		public void Delete(int id)
		{
			_unitOfWork.ProductRepository.Delete(id);
			//_unitOfWork.ProductImageRepository.DeleteRange(i => i.Machine.Id == id);
			_unitOfWork.Save();
		}
	}
}
