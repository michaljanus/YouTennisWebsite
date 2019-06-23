import { Booking } from '../models/booking';
import { ISerializer } from './ISerializer';

export class BookingSerializer implements ISerializer {
    fromJson(json: any): Booking {
      const booking = new Booking();
      booking.id = json.id;
      booking.CourtId = json.courtId;
      booking.BookingDateAsString = json.bookingDateAsString;
      booking.CourtAddress = json.courtAddress;
      booking.ClubName = json.clubName;

      return booking;
    }

    toJson(booking: Booking): any {
      return {
        id: booking.id,
        CourtId: booking.CourtId,
        BookingDateAsString: booking.BookingDateAsString,
        CourtAddress: booking.CourtAddress,
        ClubName: booking.ClubName
      };
    }
  }
