using Datalayer.Entities;

namespace Servicelayer.Interfaces
{
	public interface ITreatmentRepository
	{
		/// <summary>
		/// Creates a treatment
		/// </summary>
		/// <param name="treatment"></param>
		/// <returns></returns>
		Task CreateTreatment(Treatment treatment);
		/// <summary>
		/// Deletes a treatment
		/// </summary>
		/// <param name="treatmentId"></param>
		/// <returns></returns>
		Task DeleteTreatment(int treatmentId);
		/// <summary>
		/// Gets all treatments
		/// </summary>
		/// <returns></returns>
		IQueryable<Treatment> GetAllTreatments();
		/// <summary>
		/// Get treatment by treatmentId
		/// </summary>
		/// <param name="treatmentId"></param>
		/// <returns></returns>
		Task<Treatment> GetTreatmentsById(int treatmentId);
		/// <summary>
		/// Updates treatment
		/// </summary>
		/// <param name="treatment"></param>
		/// <returns></returns>
		Task UpdateTreatment(Treatment treatment);
	}
}