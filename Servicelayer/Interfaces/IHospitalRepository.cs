using Datalayer.Entities;

namespace Servicelayer.Interfaces
{
	public interface IHospitalRepository
	{
		Task<Employee> GetEmployeeById(int employeeId);
		IQueryable<Employee> GetAllEmployees();
		Task<Patient> GetPatientById(int patientId);
		IQueryable<Patient> GetAllPatients();
	}
}