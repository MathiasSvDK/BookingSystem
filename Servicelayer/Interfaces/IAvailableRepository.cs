using Datalayer.Entities;

namespace Servicelayer.Interfaces
{
	public interface IAvailableRepository
	{
		/// <summary>
		/// Create an available time for doctor/nurse
		/// </summary>
		/// <param name="available"></param>
		/// <returns></returns>
		Task CreateAvailable(Available available);
		/// <summary>
		/// Deletes the available time for doctor/nurse
		/// </summary>
		/// <param name="availableId"></param>
		/// <returns></returns>
		Task DeleteAvailable(int availableId);
		/// <summary>
		/// Get all times
		/// </summary>
		/// <returns></returns>
		IQueryable<Available> GetAllAvailables();
		/// <summary>
		/// Get all available time that is not taken
		/// </summary>
		/// <returns></returns>
		IQueryable<Available> GetAllAvailablesNotTaken();
		/// <summary>
		/// Gets available by availableId
		/// </summary>
		/// <param name="availableId"></param>
		/// <returns></returns>
		Task<Available> GetAvailableById(int availableId);
		/// <summary>
		/// Updates an available time
		/// </summary>
		/// <param name="available"></param>
		/// <returns></returns>
		Task UpdateAvailable(Available available);
	}
}