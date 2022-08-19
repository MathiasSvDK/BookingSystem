using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

namespace Datalayer.Entities
{
	public partial class Patient : IdentityUser
	{
		public string Id { get; set; }
		public string? Firstname { get; set; }
		public string? Lastname { get; set; }
		public string? Address { get; set; }
		public string? Cpr { get; set; }
		public string? Mobilnr { get; set; }
		public string? Note { get; set; }
	}
}
