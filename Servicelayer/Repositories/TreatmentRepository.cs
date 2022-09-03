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
	public class TreatmentRepository : ITreatmentRepository
	{
		private readonly BookingContext _bookingContext;
		public TreatmentRepository(BookingContext bookingContext)
		{
			_bookingContext = bookingContext;
		}

		public IQueryable<Treatment> GetAllTreatments()
		{
			return _bookingContext.Treatments.AsNoTracking().OrderBy(t => t.TreatmentName);
		}

		public async Task<Treatment> GetTreatmentsById(int treatmentId)
		{
			return await _bookingContext.Treatments.Where(t => t.TreatmentId == treatmentId).FirstOrDefaultAsync();
		}

		public async Task CreateTreatment(Treatment treatment)
		{
			_bookingContext.Treatments.Add(treatment);
			await _bookingContext.SaveChangesAsync();
		}

		public async Task UpdateTreatment(Treatment treatment)
		{
			_bookingContext.Treatments.Update(treatment);
			await _bookingContext.SaveChangesAsync();
		}

		public async Task DeleteTreatment(int treatmentId)
		{
			Treatment treatment = await _bookingContext.Treatments.Where(t => t.TreatmentId == treatmentId).FirstOrDefaultAsync();
			_bookingContext.Treatments.Remove(treatment);
			await _bookingContext.SaveChangesAsync();
		}
	}
}
