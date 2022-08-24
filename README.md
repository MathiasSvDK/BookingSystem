# BookingSystem

## Booking api controller
route /api/booking
- GetBookingsByPatientId(int id)

Gets all bookings for that patient
- GetAllBookings()

Gets all bookings
- GetAllAvailables()

Gets all available times

Use route /api/booking/available

- GetAllAvailablesNotTaken()

Gets all available times that is not taken

Use route /api/booking/availablenottaken

- GetAllTreatments()
Gets all treatments 

Use route /api/booking/treatment
- CreateBooking()

Create a booking 
- UpdateBooking()

Updates the booking

- DeleteBooking()

Deletes the booking
