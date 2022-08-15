using Datalayer.Entities;

namespace Servicelayer.Interfaces
{
	public interface ITreatmentRepository
	{
		Task CreateTreatment(Treatment treatment);
		Task DeleteTreatment(int treatmentId);
		Task<ICollection<Treatment>> GetAllTreatments();
		Task<Treatment> GetTreatmentsById(int treatmentId);
		Task UpdateTreatment(Treatment treatment);
	}
}