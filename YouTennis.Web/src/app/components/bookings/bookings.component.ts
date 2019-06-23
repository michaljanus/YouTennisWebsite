import { Component, OnInit } from '@angular/core';
import { BookingService } from 'src/app/services/booking.service';
import { Observable } from 'rxjs';
import { Booking } from 'src/app/models/booking';

@Component({
  selector: 'app-bookings',
  templateUrl: './bookings.component.html',
  styleUrls: ['./bookings.component.scss']
})
export class BookingsComponent implements OnInit {
  public bookings: Observable<Booking[]>;
  constructor(private bookingService: BookingService) { }

  ngOnInit() {
    this.getAllBookings();
  }

  private getAllBookings() {
    this.bookings = this.bookingService.getBookings();
  }

  private cancelBooking(booking) {
    this.bookingService.delete(booking.id).subscribe(() => {
      this.ngOnInit();
    });
  }

}
