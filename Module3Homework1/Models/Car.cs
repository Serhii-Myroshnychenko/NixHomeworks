namespace Module3Homework1.Models
{
    public class Car : IComparable<Car>
    {
        public Car(string name, int maxSpeed)
        {
            Name = name;
            MaxSpeed = maxSpeed;
        }

        public string Name { get; init; }
        public int MaxSpeed { get; init; }

        public int CompareTo(Car? other)
        {
            if (other is null)
            {
                throw new ArgumentNullException($"{other} is null");
            }

            return MaxSpeed.CompareTo(other.MaxSpeed);
        }
    }
}
