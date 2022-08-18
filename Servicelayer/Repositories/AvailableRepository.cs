using Datalayer;
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
	public class AvailableRepository : IAvailableRepository
	{
		private readonly BookingContext _bookingContext;
		public AvailableRepository(BookingContext bookingContext)
		{
			_bookingContext = bookingContext;
		}

		public IQueryable<Available> GetAllAvailables()
		{
			return _bookingContext.Availables.OrderBy(d => d.Date);
		}

		public IQueryable<Available> GetAllAvailablesNotTaken()
		{
			return _bookingContext.Availables.Where(t => t.IsTaken == false).OrderBy(d => d.Date);
		}

		public async Task<Available> GetAvailableById(int availableId)
		{
			return await _bookingContext.Availables.AsNoTracking().Where(a => a.AvailableId == availableId).AsNoTracking().FirstOrDefaultAsync();
		}

		public async Task CreateAvailable(Available available)
		{
			_bookingContext.Availables.Add(available);
			await _bookingContext.SaveChangesAsync();
		}

		public async Task UpdateAvailable(Available available)
		{
			_bookingContext.Availables.Update(available);
			await _bookingContext.SaveChangesAsync();
		}

		public async Task DeleteAvailable(int availableId)
		{
			Available available = await GetAvailableById(availableId);
			_bookingContext.Availables.Remove(available);
			await _bookingContext.SaveChangesAsync();
		}
	}
}
