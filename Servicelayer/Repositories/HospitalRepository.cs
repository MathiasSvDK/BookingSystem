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

		private UserManager<ApplicationUser> _userManager;
		public HospitalRepository(hospitalContext hospitalCotext, UserManager<ApplicationUser> userManager)
		{
			_hospitalContext = hospitalCotext;
			_userManager = userManager;

			var users = _userManager.Users.ToList();

			foreach (var item in users)
			{


				if (item.Role == 3)
				{
					if (item.Id == _hospitalContext.Patients.FirstOrDefault(p => p.Uid == item.Id).Uid)
					{
						_hospitalContext.Patients.Update(new Patient
						{
							Uid = item.Id,
							Cpr = item.UserName,
							Email = item.Email,
							Mobilnr = item.Mobilnr,
							Role = item.Role,
							Firstname = item.Firstname,
							Lastname = item.Lastname
						});
					}
					else
					{
						_hospitalContext.Patients.Add(new Patient
						{
							Uid = item.Id,
							Cpr = item.UserName,
							Email = item.Email,
							Mobilnr = item.Mobilnr,
							Role = item.Role,
							Firstname = item.Firstname,
							Lastname = item.Lastname
						});
					}


				}
				else
				{

					if (item.Id == _hospitalContext.Patients.FirstOrDefault(p => p.Uid == item.Id).Uid)
					{
						_hospitalContext.Patients.Update(new Patient
						{
							Uid = item.Id,
							Cpr = item.UserName,
							Email = item.Email,
							Mobilnr = item.Mobilnr,
							Role = item.Role,
							Firstname = item.Firstname,
							Lastname = item.Lastname
						});
					}
					else
					{
						_hospitalContext.Employees.Add(new Employee
						{
							Uid = item.Id,
							Email = item.Email,
							Mobilnr = item.Mobilnr,
							Role = item.Role,
							Firstname = item.Firstname,
							Lastname = item.Lastname,
							HospitalId = item.HospitalId
						});
					}

				}
			}
			_hospitalContext.SaveChanges();

		}

		public async Task<Patient> GetPatientById(int patientId)
		{
			return await _hospitalContext.Patients.FirstOrDefaultAsync(p => p.Id == patientId);
		}

		public async Task<Employee> GetEmployeeById(int employeeId)
		{
			return await _hospitalContext.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);
		}

		public IQueryable<Patient> GetAllPatients()
		{
			return _hospitalContext.Patients;
		}

		public IQueryable<Employee> GetAllEmployees()
		{
			return _hospitalContext.Employees;
		}


	}
}
