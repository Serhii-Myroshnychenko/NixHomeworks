namespace Module2Homework6.Cars.EngineContracts
{
    public interface IElectroEngine
    {
        void ChargeBattery();
        void ChangeBattery();
        int GetBatteryCharge();
    }
}
