using Datalayer;
using Datalayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Servicelayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicelayer.Repositories
{
	public class HospitalRepository : IHospitalRepository
	{
		private readonly hospitalContext _hospitalContext;
		private readonly UserManager<IdentityUser> _userManager;
		public HospitalRepository(hospitalContext hospitalCotext, UserManager<IdentityUser> userManager)
		{
			_hospitalContext = hospitalCotext;
			_userManager = userManager;
		}

		public async Task<Patient> GetPatientById(int patientId)
		{
			return null; //await _hospitalContext.Patients.FirstOrDefaultAsync(p => p.Id == patientId);
		}

		public async Task<Employee> GetEmployeeById(int employeeId)
		{
			return await _hospitalContext.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);
		}

		public IQueryable<Patient> GetAllPatients()
		{
			return (IQueryable<Patient>)_userManager.GetUsersInRoleAsync("3");
		}

		public IQueryable<Employee> GetAllEmployees()
		{
			return _hospitalContext.Employees;
		}


	}
}
