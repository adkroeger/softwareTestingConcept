using System;
using System.Linq.Expressions;
using System.Threading;

using FluentAssertions;

using Moq;

using VehicleManagement.DataContracts.DataModels;
using VehicleManagement.DBAccess.Entities;
using VehicleManagement.DBAccess.Factories;
using VehicleManagement.DBAccess.Repositories;
using VehicleManagement.DBAccess.Transcations;
using VehicleManagement.DBAccess.UnitTests.TestData;

namespace VehicleManagement.DBAccess.UnitTests.Transactions
{
    public class VehicleTransactionTests
    {
        private readonly Mock<IVehicleRepository> _vehicleRepository;
        private readonly Mock<IVehicleFactory> _vehicleFactory;
        private readonly IVehicleTransaction _vehicleTransaction;

        public VehicleTransactionTests()
        {
            _vehicleRepository = new Mock<IVehicleRepository>();
            _vehicleFactory = new Mock<IVehicleFactory>();
            _vehicleTransaction = new VehicleTransaction(_vehicleFactory.Object, _vehicleRepository.Object);
        }

        [Theory]
        [MemberData(nameof(VehicleTestData.GetVehiclesTestData), MemberType = typeof(VehicleTestData))]
        public async Task GetAllAsync_Should_Get_All(List<Vehicle> entities, List<FlatVehicle> models)
        {
            // ARRANGE
            _vehicleRepository
                .Setup(vr =>
                    vr.GetAllAsync(
                        It.IsAny<CancellationToken>(),
                        It.IsAny<Expression<Func<Vehicle, bool>>>(),
                        It.IsAny<bool>(),
                        It.IsAny<string[]>()
                    )
                )
                .ReturnsAsync(entities);

            _vehicleFactory
                .Setup(vf => vf.Create(entities))
                .Returns(models);

            // ACT
            var result = await _vehicleTransaction.GetAllAsync(It.IsAny<CancellationToken>());

            // ASSERT
            result.Should().BeEquivalentTo(models);
        }
    }
}