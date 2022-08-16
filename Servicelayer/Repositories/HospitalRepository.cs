﻿using Datalayer;
using Datalayer.Entities;
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
		public HospitalRepository(hospitalContext hospitalCotext)
		{
			_hospitalContext = hospitalCotext;
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
