import { Action } from '@ngrx/store';
import {
  createVehicleInitialState,
  vehicleReducer,
  VehicleState,
} from './vehicle.reducers';
import * as VehiclesActions from './vehicle.actions';
import { flatVehicles } from './vehicle.test-data';
import { TypedAction } from '@ngrx/store/src/models';

describe('VehicleReducer', () => {
  let initState: VehicleState;

  beforeEach(() => {
    initState = createVehicleInitialState();
  });

  describe('undefined action', () => {
    it('returns the initial state for undefined action', () => {
      // ARRANGE
      const action: Action = {} as Action;

      // ACT
      const state: VehicleState = vehicleReducer(undefined, action);

      // ASSERT
      expect(state).toEqual(initState);
    });
  });

  describe('getVehicles action', () => {
    it('returns the getVehicles state', () => {
      // ARRANGE
      const expectedState: VehicleState = structuredClone(initState);
      expectedState.vehiclesLoading = true;

      const action: TypedAction<'[Vehicles] Get vehicles'> =
        VehiclesActions.getVehicles();

      // ACT
      const state: VehicleState = vehicleReducer(initState, action);

      // ASSERT
      expect(state).toEqual(expectedState);
    });
  });

  describe('getVehiclesSuccess action', () => {
    it('returns', () => {
      // ARRANGE
      const expectedState: VehicleState = structuredClone(initState);
      expectedState.vehicles = flatVehicles;

      const action: VehiclesActions.getVehiclesSuccess &
        TypedAction<'[Vehicles] Get vehicles - Success'> =
        VehiclesActions.getVehiclesSuccess({
          vehicles: flatVehicles,
        });

      // ACT
      const state: VehicleState = vehicleReducer(initState, action);

      // ASSERT
      expect(state).toEqual(expectedState);
    });
  });
});
