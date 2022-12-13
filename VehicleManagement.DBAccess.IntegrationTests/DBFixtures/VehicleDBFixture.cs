﻿namespace VehicleManagement.DBAccess.IntegrationTests.DBFixtures
{
    public class VehicleDBFixture : SharedDatabaseFixture
    {
        protected override void InitializeData()
        {
            InsertData(nameof(VehicleManagementContext.Manufacturer), "'WMI', 'Audi'");
            InsertData(nameof(VehicleManagementContext.Manufacturer), "'W0L', 'Opel'");

            InsertData(nameof(VehicleManagementContext.Vehicles), "'SB164ABN1PE082986', 'MI-XY-666', 'black', 12345.89, 'WMI'");
            InsertData(nameof(VehicleManagementContext.Vehicles), "'SB164ABN1PE082096', 'DH-IL-12', 'green', 125.40, 'W0L'");
            InsertData(nameof(VehicleManagementContext.Vehicles), "'SB189ABN1PE034986', 'VEC-KL-234', 'red', 0.0, 'WMI'");
        }
    }
}
