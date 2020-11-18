using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ALEMI.Persistence
{
	public static class DataSeedingInitializer
	{
		public static async Task UserAndRoleSeedAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			string[] roles = { "Admin", "Manager", "Staff" };
			foreach (var role in roles)
			{
				var roleExist = await roleManager.RoleExistsAsync(role);
				if (!roleExist)
				{
					IdentityResult result = await roleManager.CreateAsync(new IdentityRole(role));
				}
			}

			//Create admin user
			if (userManager.FindByEmailAsync("michael.aiyetanjnr03@gmail.com").Result == null)
			{
				IdentityUser user = new IdentityUser
				{
					UserName = "michael.aiyetanjnr03@gmail.com",
					Email = "michael.aiyetanjnr03@gmail.com"
				};
				IdentityResult identityResult = userManager.CreateAsync(user, "Password1").Result;
				if (identityResult.Succeeded)
				{
					userManager.AddToRoleAsync(user, "Admin").Wait();
				}
			}

			//Create Manager user
			if (userManager.FindByEmailAsync("michael.manager@gmail.com").Result == null)
			{
				IdentityUser user = new IdentityUser
				{
					UserName = "michael.manager@gmail.com",
					Email = "michael.manager@gmail.com"
				};
				IdentityResult identityResult = userManager.CreateAsync(user, "Password1").Result;
				if (identityResult.Succeeded)
				{
					userManager.AddToRoleAsync(user, "Manager").Wait();
				}
			}

			//Create Staff user
			if (userManager.FindByEmailAsync("michael.Staff@gmail.com").Result == null)
			{
				IdentityUser user = new IdentityUser
				{
					UserName = "michael.Staff@gmail.com",
					Email = "michael.Staff@gmail.com"
				};
				IdentityResult identityResult = userManager.CreateAsync(user, "Password1").Result;
				if (identityResult.Succeeded)
				{
					userManager.AddToRoleAsync(user, "Staff").Wait();
				}
			}

			//Create No Role  user
			if (userManager.FindByEmailAsync("John.Staff@gmail.com").Result == null)
			{
				IdentityUser user = new IdentityUser
				{
					UserName = "John.Staff@gmail.com",
					Email = "John.Staff@gmail.com"
				};
				IdentityResult identityResult = userManager.CreateAsync(user, "Password1").Result;
			//No Role ASsign to  John
			}

		}
	}
}
