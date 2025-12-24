
namespace VGP133_Final_Assignment.Game
{
    public class Item
    {
        public Item(string name, string type, int quantity, int value)
        {
            _name = name;
            _type = type;
            _value = value;
            Quantity = quantity;
        }

        private string _name;
        private string _type;
        private int _quantity;
        private int _value;
        public int Price { get; set; }
        public string Name { get => _name; }
        public string Type { get => _type; }
        public int Value { get => _value; }
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value <= 0) _quantity = 0;
                else _quantity = value;
            }
        }
    }
}
