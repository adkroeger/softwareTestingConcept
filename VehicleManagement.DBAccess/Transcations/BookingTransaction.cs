using VehicleManagement.DataContracts.DataModels;
using VehicleManagement.DataContracts.Exceptions;
using VehicleManagement.DBAccess.Factories;
using VehicleManagement.DBAccess.Repositories;

namespace VehicleManagement.DBAccess.Transcations
{
    public class BookingTransaction : IBookingTransaction
    {
        private readonly IBookingFactory _bookingFactory;
        private readonly IBookingRepository _bookingRepository;

        public BookingTransaction(IBookingFactory bookingFactory, IBookingRepository bookingRepository)
        {
            _bookingFactory = bookingFactory;
            _bookingRepository = bookingRepository;
        }

        public async Task<FlatBooking> AddAsync(Booking booking, CancellationToken cancellationToken)
        {
            var entity = _bookingFactory.Create(booking);

            var newBooking = await _bookingRepository.AddAsync(entity, cancellationToken);
            await _bookingRepository.SaveAsync(cancellationToken);
            await _bookingRepository.ReloadReferences(newBooking, "Vehicle");

            return _bookingFactory.Create(newBooking);
        }

        public async Task<IEnumerable<FlatBooking>> GetAllAsync(CancellationToken cancellationToken)
        {
            var bookings = await _bookingRepository.GetAllAsync(cancellationToken, asNoTracking: true, includedPaths: "Vehicle");

            return _bookingFactory.Create(bookings);
        }

        public async Task<UpdateableBooking> GetAsync(int id, CancellationToken cancellationToken)
        {
            var booking = await _bookingRepository.GetAsync(cancellationToken, b => b.Id == id, true);

            if (booking == null)
            {
                throw new EntityNotFoundException(Messages.NotFound, id);
            }

            return _bookingFactory.CreateFull(booking);
        }

        public async Task<FlatBooking> UpdateAsync(UpdateableBooking booking, CancellationToken cancellationToken)
        {
            var entity = _bookingFactory.Create(booking);

            var updatedEntity = _bookingRepository.Update(entity);
            await _bookingRepository.SaveAsync(cancellationToken);
            await _bookingRepository.ReloadReferences(updatedEntity, "Vehicle");

            return _bookingFactory.Create(updatedEntity);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            _bookingRepository.Delete(new Entities.Booking() { Id = id });
            await _bookingRepository.SaveAsync(cancellationToken);
        }
    }
}
