using Microsoft.AspNetCore.Identity;

namespace Pronia_Front_to_Backend.Models
{
	public class AppUser : IdentityUser
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public DateTime? BirhDate { get; set; }
	}
}
