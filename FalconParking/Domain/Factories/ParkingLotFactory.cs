using FalconParking.Domain.Exceptions;

namespace FalconParking.Domain.Factories
{
    public static class ParkingLotFactory
    {

        //This whole class may need some refactoring

        public static ParkingLot CreateParkingLot(int id)
        {
            switch (id)
            {
                case 0: return CreateParkingLotA();
                case 1: return CreateParkingLotB();
                case 2: return CreateParkingLotC();
                default: throw new DomainException($"No existe un parqueo {id}");
            }
        }

        private static ParkingLot CreateParkingLotA()
        {
            return ParkingLot.New(
                aggregateId : 0
                ,code : "A"
                ,totalSlotsCount : 30);
        }

        private static ParkingLot CreateParkingLotB()
        {
            return ParkingLot.New(
                aggregateId: 1
                ,code: "B"
                ,totalSlotsCount: 20);
        }

        private static ParkingLot CreateParkingLotC()
        {
            return ParkingLot.New(
                aggregateId: 0
                ,code: "C"
                ,totalSlotsCount: 10);
        }
    }
}
