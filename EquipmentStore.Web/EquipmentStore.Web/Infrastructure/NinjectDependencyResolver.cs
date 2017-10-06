using AutoMapper;
using EquipmentStore.BLL.Infrastructure;
using EquipmentStore.Web.Infrastructure.EmailSenders;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EquipmentStore.Web.Infrastructure
{
	public class NinjectDependencyResolver : IDependencyResolver
	{
		private readonly IKernel _kernel;

		public NinjectDependencyResolver(IKernel kernel)
		{
			_kernel = kernel;

			AddBindings();
		}

		public object GetService(Type serviceType)
		{
			return _kernel.TryGet(serviceType);
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			return _kernel.GetAll(serviceType);
		}

		private void AddBindings()
		{
			Mapper.Initialize(cfg =>
			{
				cfg.AddProfile(new WebAutoMapperProfile());
				cfg.AddProfile(new BllAutomapperProfile());
			});

			_kernel.Bind<IMapper>().ToConstant(Mapper.Instance);
			_kernel.Bind<IEmailSender>().To<UhEmailSender>();
		}
	}
}