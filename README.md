# BookingSystem
 
 <!-- Indholdsfortegnelse -->
<details open="open">
  <summary>Indholdsfortegnelse</summary>
  <ol>
    <li>
      <a href="#om-projektet">Om projektet</a>
    </li>
    <li><a href="#booking-api-controller">Api controller</a></li>
    <li><a href="#mail-sender">Automatisering</a></li>
  </ol>
</details>

 
## Om projektet
Dette er et projekt er lavet til svendeprøven udfra den case vi har fået udlevert. Projeket håndterer kun booking af undersøgelser og indlæggelser af patienter.

## Er-diagram
 ![ErDiagramForBookingSystem](https://user-images.githubusercontent.com/53754722/187873072-2f77d7da-125b-4d2c-afdd-490b9f91cc74.png)
 
## Booking api controller
**route /api/booking/patient/{patient_Id}**
- GetBookingsByPatientId(int id)

Henter en liste af bookede undersøgelser ud fra en patient.

**route /api/booking/{booking_Id}**
- GetBookingByBookingId

Henter en booking af undersøgelse ud fra booking id.

**route /api/booking/**
- GetAllBookings()

Henter en liste af alle bookede undersøgelser

**route /api/booking/available**
- GetAllAvailables()

Henter en liste af alle tider.

**route /api/booking/availablenottaken**
- GetAllAvailablesNotTaken()

Henter en liste af alle tider der ikke er taget.

**route /api/booking/treatment**
- GetAllTreatments()

Henter en liste af alle behandlinger.

**route /api/booking**
- CreateBooking()

Opretter en booking af en undersøgelse. Hvis tiden der er blevet valgt er taget oprettes der ikke en ny booking af en undersøgelse.


**route /api/booking**
- UpdateBooking()

Opdaterer booking af undersøgelsen. Hvis man har valgt en ny tid, og den er taget ændres tiden ikke.

**route /api/booking/{booking_Id}**
- DeleteBooking()

Sletter booking af undersøgelsen permanent.

## Mail sender
Mail senderen er konfigureret med SendGrid, hvor der bliver brugt deres api til at sende mails med.
Metoden ligger på BookingRepository og bliver brugt i ViewBookings.razor og EditBooking.razor
Apikey og mailadressen mailen bliver sendt fra kan man finde i appsettings.json

