# BookingSystem

## Booking api controller
**route /api/booking/patient/{patient_Id}**
- GetBookingsByPatientId(int id)

Gets all bookings for that patient

**route /api/booking/{booking_Id}**
- GetBookingByBookingId

Gets the booking via the booking id

**route /api/booking/**
- GetAllBookings()

Gets all bookings

**route /api/booking/available**
- GetAllAvailables()

Gets all available times

**route /api/booking/availablenottaken**
- GetAllAvailablesNotTaken()

Gets all available times that is not taken

**route /api/booking/treatment**
- GetAllTreatments()
Gets all treatments 

**route /api/booking**
- CreateBooking()
Create a booking 

**route /api/booking**
- UpdateBooking()

Updates the booking

**route /api/booking/{booking_Id}**
- DeleteBooking()

Deletes the booking

## Mail sender
The SendEmailAsync can get found in BookingRepository, it uses SendGrids api to send a mail.
The apikey and mail that it sends from can be found in appsetteing.json
it is used in viewbookings and editbooking.razor

