using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenLogger.Analysis.Vehicle;

namespace OpenLogAnalyzer
{
    public class VehicleRepository
    {
        private static Vehicle _vehicle = new Vehicle();
        public static Vehicle GetVehicle(Guid vehicleId)
        {
            return _vehicle;
        }
    }
}
