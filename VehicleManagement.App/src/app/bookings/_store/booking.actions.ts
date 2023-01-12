/* eslint-disable @typescript-eslint/typedef */
import { createAction, props } from '@ngrx/store';
import { Booking } from '../models/booking.model';
import { FlatBooking } from '../models/flat-booking.model';

// BOOKINGS
export const getBookings = createAction('[Bookings] Get bookings');

export type getBookingsSuccess = { bookings: FlatBooking[] };
export const getBookingsSuccess = createAction(
  '[Bookings] Get bookings - Success',
  props<getBookingsSuccess>()
);

export type addBooking = { booking: Booking };
export const addBooking = createAction(
  '[Bookings] Add booking',
  props<addBooking>()
);

export type addBookingSuccess = { booking: FlatBooking };
export const addBookingSuccess = createAction(
  '[Bookings] Add booking - Success',
  props<addBookingSuccess>()
);
