using Datalayer.Entities;

namespace Servicelayer.Interfaces
{
	public interface IHospitalRepository
	{
		Task<Employee> GetEmployeeById(int employeeId);
		Task<ICollection<Employee>> GetAllEmployees();
		Task<Patient> GetPatientById(int patientId);
		Task<ICollection<Patient>> GetAllPatients();
	}
}