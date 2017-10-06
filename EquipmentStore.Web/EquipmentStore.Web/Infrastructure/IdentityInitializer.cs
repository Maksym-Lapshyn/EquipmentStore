using EquipmentStore.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace EquipmentStore.Web.Infrastructure
{
	public class IdentityInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
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
			var adminUser = new ApplicationUser {Email = "y.novoselov17@gmail.com", UserName = "y.novoselov17@gmail.com"};
			var password = "novfilpak";
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