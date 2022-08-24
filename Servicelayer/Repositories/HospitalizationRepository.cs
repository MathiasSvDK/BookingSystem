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
	public class HospitalizationRepository : IHospitalizationRepository
	{
		private readonly BookingContext _bookingContext;
		private readonly hospitalContext _hospitalContext;
		public HospitalizationRepository(BookingContext bookingContext, hospitalContext hospitalContext)
		{
			_bookingContext = bookingContext;
			_hospitalContext = hospitalContext;
		}

		public IQueryable<Hospitalization> GetHospitalizationsByHospitalId(int hospitalId)
		{
			return _bookingContext.Hospitalization.AsNoTracking().Where(p => p.HospitalId == hospitalId);
		}

		public async Task<Hospitalization> GetHospitalizationByHospitalizationId(int hospitalizationId)
		{
			return await _bookingContext.Hospitalization.AsNoTracking().Where(b => b.HospitalizationID == hospitalizationId).FirstOrDefaultAsync();
		}

		public IQueryable<Hospitalization> GetAllHospitalizations()
		{
			return _bookingContext.Hospitalization.AsNoTracking();
		}

		public async Task CreateHospitalization(Hospitalization booking)
		{
			_bookingContext.Hospitalization.Add(booking);
			await _bookingContext.SaveChangesAsync();
		}

		public async Task UpdateHospitalization(Hospitalization booking)
		{
			_bookingContext.Hospitalization.Update(booking);
			await _bookingContext.SaveChangesAsync();
		}


		public async Task DeleteHospitalization(int hospitalizationId)
		{
			Hospitalization hospitalization = await GetHospitalizationByHospitalizationId(hospitalizationId);
			_bookingContext.Hospitalization.Remove(hospitalization);
			await _bookingContext.SaveChangesAsync();
		}

		public IQueryable<Hospital> GetAllHospitals()
		{
			return _hospitalContext.Hospitals.AsNoTracking();
		}
	}
}
