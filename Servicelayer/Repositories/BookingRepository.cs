﻿using Datalayer;
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
	public class BookingRepository : IBookingRepository
	{
		private readonly BookingContext _bookingContext;
		private readonly IAvailableRepository _availableRepo;
		public BookingRepository(BookingContext bookingContext, IAvailableRepository availableRepository)
		{
			_bookingContext = bookingContext;
			_availableRepo = availableRepository;
		}

		public IQueryable<Booking> GetBookingsByPatientId(int patientId)
		{
			return _bookingContext.Bookings.Include(t => t.Treatment).Include(a => a.Available).Where(p => p.PatientId == patientId);
		}

		public async Task<Booking> GetBookingByBookingId(int bookingId)
		{
			return await _bookingContext.Bookings.AsNoTracking().Include(t => t.Treatment).AsNoTracking().Include(a => a.Available).AsNoTracking().Where(b => b.BookingId == bookingId).FirstOrDefaultAsync();
		}

		public IQueryable<Booking> GetAllBookings()
		{
			int year = DateTime.UtcNow.Year;
			return _bookingContext.Bookings.Include(t => t.Treatment).AsNoTracking().Include(a => a.Available).AsNoTracking().Where(d => d.Available.Date.Year >= year);
		}

		public async Task CreateBooking(Booking booking)
		{
			_bookingContext.Bookings.Add(booking);
			await _bookingContext.SaveChangesAsync();
		}

		public async Task UpdateBooking(Booking booking)
		{
			_bookingContext.Bookings.Update(booking);
			await _bookingContext.SaveChangesAsync();
		}

		public async Task UpdateBookingForApi(Booking updateBooking)
		{
			Booking booking = await GetBookingByBookingId(updateBooking.BookingId);

			if (updateBooking.AvailableId != booking.AvailableId)
			{
				updateBooking.Available = await _availableRepo.GetAvailableById(updateBooking.AvailableId);

				if (updateBooking.Available.IsTaken == false)
				{
					await UpdateAvailable(booking.AvailableId, "true");
					updateBooking.Available.IsTaken = true;
					await _availableRepo.UpdateAvailable(updateBooking.Available);
				}
				else
				{
					
					updateBooking.Available = booking.Available;
				}
			}
			_bookingContext.Bookings.Update(updateBooking);
			await _bookingContext.SaveChangesAsync();
		}

		public async Task DeleteBooking(int bookingId)
		{
			Booking booking = await GetBookingByBookingId(bookingId);
			if (booking != null)
			{
				booking.Available.IsTaken = false;
				await _availableRepo.UpdateAvailable(booking.Available);
			}
			_bookingContext.Bookings.Remove(booking);
			await _bookingContext.SaveChangesAsync();
		}

		private async Task UpdateAvailable(int id, string isTaken)
		{
			Available available = await _availableRepo.GetAvailableById(id);
			switch (isTaken)
			{
				case "true":
					available.IsTaken = false;
					await _availableRepo.UpdateAvailable(available);
					break;
				case "false":
					available.IsTaken = true;
					await _availableRepo.UpdateAvailable(available);
					break;
				default:
					break;
			}
		}
	}
}
