import { Resource } from "./resource";

export class Booking extends Resource{
    CourtId: string;
    BookingDateAsString: string;
    CourtAddress: string;
    ClubName: string;
}