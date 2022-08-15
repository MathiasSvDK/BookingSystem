using Datalayer.Entities;

namespace Servicelayer.Interfaces
{
	public interface IAvailableRepository
	{
		Task CreateAvailable(Available available);
		Task DeleteAvailable(int availableId);
		Task<ICollection<Available>> GetAllAvailables();
		Task<Available> GetAvailableById(int availableId);
		Task UpdateAvailable(Available available);
	}
}