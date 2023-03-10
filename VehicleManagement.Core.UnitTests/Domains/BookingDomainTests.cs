using System.Collections.Generic;
using System.Threading;

using FluentAssertions;

using VehicleManagement.Core.Domains;
using VehicleManagement.Core.Services;
using VehicleManagement.Core.UnitTests.TestData;
using VehicleManagement.DataContracts.DataModels;

namespace VehicleManagement.Core.UnitTests.Domains
{
    public class BookingDomainTests
    {
        private readonly Mock<IBookingService> _bookingServiceMock;
        private readonly IBookingDomain _bookingDomain;

        public BookingDomainTests()
        {
            _bookingServiceMock = new Mock<IBookingService>();
            _bookingDomain = new BookingDomain(_bookingServiceMock.Object);
        }

        [Theory]
        [MemberData(nameof(BookingTestData.GetBookingsTestData), MemberType = typeof(BookingTestData))]
        public async Task GetAllAsync_Should_Return_All(List<FlatBooking> bookings)
        {
            // ARRANGE
            _bookingServiceMock
                .Setup(bs => bs.GetAllAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(bookings);

            // ACT
            var result = await _bookingDomain.GetAllAsync(It.IsAny<CancellationToken>());

            // ASSERT
            result.Should().BeEquivalentTo(bookings);
        }

        [Fact]
        public async Task GetAllAsync_Should_Call_Service_Once()
        {
            // ACT
            await _bookingDomain.GetAllAsync(It.IsAny<CancellationToken>());

            // ASSERT
            _bookingServiceMock.Verify(bs => bs.GetAllAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        [Theory]
        [MemberData(nameof(BookingTestData.GetAddBookingTestData), MemberType = typeof(BookingTestData))]
        public async Task AddAsync_Should_Get_New(Booking booking, FlatBooking newBooking)
        {
            // ARRANGE
            _bookingServiceMock
                .Setup(bt => bt.AddAsync(booking, It.IsAny<CancellationToken>()))
                .ReturnsAsync(newBooking);

            // ACT
            var result = await _bookingDomain.AddAsync(booking, It.IsAny<CancellationToken>());

            // ASSERT
            Assert.Equal(newBooking.Start, result.Start);
            Assert.Equal(newBooking.End, result.End);
            Assert.Equal(newBooking.EmployeeNumber, result.EmployeeNumber);
            Assert.Equal(newBooking.FIN, result.FIN);

            Assert.Equal(booking.Start, result.Start);
            Assert.Equal(booking.End, result.End);
            Assert.Equal(booking.EmployeeNumber, result.EmployeeNumber);
            Assert.Equal(booking.FIN, result.FIN);
        }

        [Fact]
        public async Task AddAsync_Should_Call_Transaction_Once()
        {
            // ACT
            await _bookingDomain.AddAsync(It.IsAny<Booking>(), It.IsAny<CancellationToken>());

            // ASSERT
            _bookingServiceMock.Verify(bs => bs.AddAsync(It.IsAny<Booking>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Theory]
        [MemberData(nameof(BookingTestData.GetUpdateBookingTestData), MemberType = typeof(BookingTestData))]
        public async Task UpdateAsync_Should_Get_New(UpdateableBooking booking, FlatBooking newBooking)
        {
            // ARRANGE
            _bookingServiceMock
                .Setup(bt => bt.UpdateAsync(booking, It.IsAny<CancellationToken>()))
                .ReturnsAsync(newBooking);

            // ACT
            var result = await _bookingDomain.UpdateAsync(booking, It.IsAny<CancellationToken>());

            // ASSERT
            Assert.Equal(newBooking.Id, result.Id);
            Assert.Equal(newBooking.Start, result.Start);
            Assert.Equal(newBooking.End, result.End);
            Assert.Equal(newBooking.EmployeeNumber, result.EmployeeNumber);
            Assert.Equal(newBooking.FIN, result.FIN);

            Assert.Equal(booking.Id, result.Id);
            Assert.Equal(booking.Start, result.Start);
            Assert.Equal(booking.End, result.End);
            Assert.Equal(booking.EmployeeNumber, result.EmployeeNumber);
            Assert.Equal(booking.FIN, result.FIN);
        }

        [Fact]
        public async Task UpdateAsync_Should_Call_Transaction_Once()
        {
            // ACT
            await _bookingDomain.UpdateAsync(It.IsAny<UpdateableBooking>(), It.IsAny<CancellationToken>());

            // ASSERT
            _bookingServiceMock.Verify(bs => bs.UpdateAsync(It.IsAny<UpdateableBooking>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Theory]
        [MemberData(nameof(BookingTestData.GetBookingTestData), MemberType = typeof(BookingTestData))]
        public async Task GetAsync_Should_Get_UpdateableBooking(int id, UpdateableBooking booking)
        {
            // ARRANGE
            _bookingServiceMock
                .Setup(bt => bt.GetAsync(id, It.IsAny<CancellationToken>()))
                .ReturnsAsync(booking);

            // ACT
            var result = await _bookingDomain.GetAsync(id, It.IsAny<CancellationToken>());

            // ASSERT
            Assert.Equal(id, result.Id);

            Assert.Equal(booking.Id, result.Id);
            Assert.Equal(booking.Start, result.Start);
            Assert.Equal(booking.End, result.End);
            Assert.Equal(booking.EmployeeNumber, result.EmployeeNumber);
            Assert.Equal(booking.FIN, result.FIN);
        }

        [Fact]
        public async Task GetAsync_Should_Call_Transaction_Once()
        {
            // ACT
            await _bookingDomain.GetAsync(It.IsAny<int>(), It.IsAny<CancellationToken>());

            // ASSERT
            _bookingServiceMock.Verify(bt => bt.GetAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task DeleteAsync_Should_Call_Transaction_Once()
        {
            // ACT
            await _bookingDomain.DeleteAsync(It.IsAny<int>(), It.IsAny<CancellationToken>());

            // ASSERT
            _bookingServiceMock.Verify(bt => bt.DeleteAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Once());
        }
    }
}
