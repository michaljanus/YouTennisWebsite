import { Component, OnInit } from '@angular/core';
import { MatDatepickerInputEvent, MatMonthView } from '@angular/material';
import { SlotService } from 'src/app/services/slot.service';
import { Observable } from 'rxjs';
import { Slot } from 'src/app/models/slot';
import { ActivatedRoute } from '@angular/router';
import { BookingService } from 'src/app/services/booking.service';
import { NgbDateStruct, NgbCalendar } from '@ng-bootstrap/ng-bootstrap';
import { UserService } from 'src/app/services/user.service';


@Component({
  selector: 'app-book-court',
  templateUrl: './book-court.component.html',
  styleUrls: ['./book-court.component.scss']
})
export class BookCourtComponent implements OnInit {

  public slots: Observable<Slot[]>;
  public courtId: string;
  public selectedSlot: Slot;
  public selectedDate;

  model: NgbDateStruct;
  date: { year: number, month: number, day: number };
  today: { year: number, month: number, day: number };

  constructor(private slotService: SlotService, private route: ActivatedRoute, private bookingService: BookingService, private calendar: NgbCalendar, private userService: UserService) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.courtId = (<any>params).params.courtId;
    });
    var date = new Date();
    this.today = { day: date.getDate() + 1, month: date.getMonth() + 1, year: date.getFullYear() };
  }

  public onDateSelect(e) {

    const date = `${this.padDigits(this.model.month, 2)}-${this.padDigits(this.model.day, 2)}-${this.model.year}`;
    this.selectedDate = date;
    this.slots = this.slotService.getByCourtId(this.courtId, date);
    this.selectedSlot = null;
  }

  public myDatePickerOptions: any = {
    // Your options
  };

  public setHour(slot: Slot) {
    this.selectedSlot = slot;
  }

  public book() {
    const time = `${this.model.year}-${this.padDigits(this.model.month, 2)}-${this.padDigits(this.model.day, 2)}T${this.selectedSlot.timeAsNumber}:00:00`;
    this.bookingService.book(this.courtId, time).subscribe(x => {
      alert("You've book a court successfully");
    });
  }

  public padDigits(number, digits) {
    return Array(Math.max(digits - String(number).length + 1, 0)).join('0') + number;
  }

  public isSelected(slot: Slot) {
    if(!this.selectedSlot) return false;
    return slot.timeAsNumber === this.selectedSlot.timeAsNumber;
  }

  public isLogged(): boolean {
    return this.userService.isLoggedIn();
  }

}
