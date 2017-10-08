using EquipmentStore.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace EquipmentStore.Web.Infrastructure
{
	public class IdentityInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
	{
		protected override void Seed(ApplicationDbContext context)
		{
			var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

			var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

			// создаем две роли
			var adminRole = new IdentityRole {Name = "admin"};

			// добавляем роли в бд
			roleManager.Create(adminRole);

			// создаем пользователей
			var adminUser = new ApplicationUser {Email = "admin", UserName = "admin"};
			var password = "novoselov";
			var result = userManager.Create(adminUser, password);

			// если создание пользователя прошло успешно
			if (result.Succeeded)
			{
				// добавляем для пользователя роль
				userManager.AddToRole(adminUser.Id, adminRole.Name);
			}

			base.Seed(context);
		}
	}
}