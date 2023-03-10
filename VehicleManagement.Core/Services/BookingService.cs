using VehicleManagement.DataContracts.DataModels;
using VehicleManagement.DBAccess.Transcations;

namespace VehicleManagement.Core.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingTransaction _bookingTransaction;

        public BookingService(IBookingTransaction bookingTransaction)
        {
            _bookingTransaction = bookingTransaction;
        }

        public async Task<FlatBooking> AddAsync(Booking booking, CancellationToken cancellationToken)
        {
            return await _bookingTransaction.AddAsync(booking, cancellationToken);
        }

        public async Task<IEnumerable<FlatBooking>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _bookingTransaction.GetAllAsync(cancellationToken);
        }

        public async Task<UpdateableBooking> GetAsync(int id, CancellationToken cancellationToken)
        {
            return await _bookingTransaction.GetAsync(id, cancellationToken);
        }

        public async Task<FlatBooking> UpdateAsync(UpdateableBooking booking, CancellationToken cancellationToken)
        {
            return await _bookingTransaction.UpdateAsync(booking, cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await _bookingTransaction.DeleteAsync(id, cancellationToken);
        }
    }
}
