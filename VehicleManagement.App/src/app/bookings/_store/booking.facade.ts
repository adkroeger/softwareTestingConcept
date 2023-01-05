import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { FlatBooking } from '../models/flat-booking.model';
import * as BookingActions from './booking.actions';
import { BookingQuery } from './booking.selectors';

@Injectable({ providedIn: 'root' })
export class BookingFacade {
  readonly bookings$: Observable<FlatBooking[]> = this.store.select(
    BookingQuery.selectBookings
  );

  readonly bookingsLoading$: Observable<boolean> = this.store.select(
    BookingQuery.selectBookingsLoading
  );

  constructor(private store: Store) {}

  getBookings(): void {
    this.store.dispatch(BookingActions.getBookings());
  }
}
