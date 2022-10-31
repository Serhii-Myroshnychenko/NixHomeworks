namespace Module2Homework2.Items.Base
{
    public abstract class Product
    {
        public Product(string name, int count, Guid id)
        {
            Id = id;
            Name = name;
            Count = count;
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Count { get; set; }
        public abstract void PrintDescription();
        public abstract override string ToString();
        public bool IsAvailable() => Count > 0;
    }
}
