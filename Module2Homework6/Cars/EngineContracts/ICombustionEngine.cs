using Module2Homework6.Cars.Base;

namespace Module2Homework6.Cars.EngineContracts
{
    public interface ICombustionEngine
    {
        double EngineVolume { get; init; }
        TypeOfFuel TypeOfFuel { get; init; }
        void ChangeOilFilter();
        void ChangeFuelFilter();
        void FillUpCar();
        int GetFuelLevel();
    }
}
