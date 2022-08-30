# BookingSystem

## Booking api controller
**route /api/booking/patient/{patient_Id}**
- GetBookingsByPatientId(int id)

Gets all bookings for that patient

**route /api/booking/{booking_Id}**
- GetBookingByBookingId

Gets the booking via the booking id

*route /api/booking/**
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

**/api/booking**
- CreateBooking()
Create a booking 

**route /api/booking**
- UpdateBooking()

Updates the booking

**route /api/booking**
- DeleteBooking()

Deletes the booking
