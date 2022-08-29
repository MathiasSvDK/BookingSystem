using Datalayer.Entities;

namespace Servicelayer.Interfaces
{
	public interface IHospitalizationRepository
	{
		/// <summary>
		/// Creates hospitalization of a patient
		/// </summary>
		/// <param name="booking"></param>
		/// <returns></returns>
		Task CreateHospitalization(Hospitalization booking);
		/// <summary>
		/// Deletes Hospitalization
		/// </summary>
		/// <param name="hospitalizationId"></param>
		/// <returns></returns>
		Task DeleteHospitalization(int hospitalizationId);
		/// <summary>
		/// Gets all Hospitalizations
		/// </summary>
		/// <returns></returns>
		IQueryable<Hospitalization> GetAllHospitalizations();
		/// <summary>
		/// Gets Hospitalization by HospitalizationId
		/// </summary>
		/// <param name="hospitalizationId"></param>
		/// <returns></returns>
		Task<Hospitalization> GetHospitalizationByHospitalizationId(int hospitalizationId);
		/// <summary>
		/// Gets Hospitalization by hospitalId
		/// </summary>
		/// <param name="hospitalId"></param>
		/// <returns></returns>
		IQueryable<Hospitalization> GetHospitalizationsByHospitalId(int hospitalId);
		/// <summary>
		/// Updates Hospitalization
		/// </summary>
		/// <param name="booking"></param>
		/// <returns></returns>
		Task UpdateHospitalization(Hospitalization booking);
		/// <summary>
		/// Gets all hospitals
		/// </summary>
		/// <returns></returns>
		IQueryable<Hospital> GetAllHospitals();
	}
}