using FalconParking.Domain.Exceptions;

namespace FalconParking.Domain.Factories
{
    public static class ParkingSlotFactory
    {
        //This whole class is an insult to my programming skills, but I'm in a rush

        public static ParkingSlot CreateParkingSlot(int aggregateId)
        {
            var parkingLotId = aggregateId;
            var parkingSlotNumber = GetParkingSlotNumber(aggregateId, parkingLotId);


            return ParkingSlot.New(
                parkingLotId
                ,parkingSlotNumber
                ,aggregateId);
        }

        private static int GetParkingLotId(int aggregateId)
        {
            //This sucks and must change

            if (aggregateId <= 40)
                return 0;
            if (aggregateId <= 70)
                return 1;
            if (aggregateId <= 90)
                return 2;

            throw new DomainException("No existe un parking slot con ese id");
        }

        private static int GetParkingSlotNumber(int aggregateId, int parkingLotId)
        {
            //This sucks and must change

            switch (parkingLotId)
            {
                case 0: return aggregateId;
                case 1: return aggregateId - 40;
                case 2: return aggregateId - 70;
                default: throw new DomainException($"Error");
            }
        }
    }
}
