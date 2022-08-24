using Datalayer.Entities;

namespace Servicelayer.Interfaces
{
	public interface IHospitalizationRepository
	{
		Task CreateHospitalization(Hospitalization booking);
		Task DeleteHospitalization(int hospitalizationId);
		IQueryable<Hospitalization> GetAllHospitalizations();
		Task<Hospitalization> GetHospitalizationByHospitalizationId(int hospitalizationId);
		IQueryable<Hospitalization> GetHospitalizationsByHospitalId(int hospitalId);
		Task UpdateHospitalization(Hospitalization booking);
		IQueryable<Hospital> GetAllHospitals();
	}
}