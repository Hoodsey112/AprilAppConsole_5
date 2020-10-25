namespace AprilAppConsole_5
{
    public class Product
    {
        public int id { get; set; }
        private string Name;
        private float discPrice;
        private float Price;
        private string Manufacturer;

        public string name
        {
            get { return Name; }
            set
            {
                Name = value;
            }
        }

        public float discontPrice
        {
            get { return discPrice; }
            set
            {
                discPrice = value;
            }
        }

        public float price
        {
            get { return Price; }
            set
            {
                Price = value;
            }
        }

        public string manufacturer
        {
            get { return Manufacturer; }
            set
            {
                Manufacturer = value;
            }
        }
    }
}
