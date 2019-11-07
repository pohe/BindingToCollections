using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BindingToCollections.Annotations;

namespace BindingToCollections
{
    public class Car:INotifyPropertyChanged
    {
        //public List<string> BrandNames
        //{
        //    get
        //    {
        //        return new List<string>() { "Toyota", "BMW", "Opel", "Volvo" };
        //    }
        //}


        private string _brand;

        public string Brand
        {
            get
            {
                return _brand;
            }
            set
            {
                _brand = value;
                _brandNames.Add(_brand);
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> _brandNames;//Tidligere List

        
        public ObservableCollection<string> BrandNames //Tidligere List
        {
            get { return _brandNames; }
            set { _brandNames = value; }
        }

        public Car()
        {
            _brand = "Toyota";
            //Tidligere List
            _brandNames = new ObservableCollection<string>() { "Toyota", "BMW", "Opel", "Volvo" };
            
        }

        public ObservableCollection<Car> Cars
        {
            get
            {
                return new ObservableCollection<Car>()
                {
                    new Car() { _brand = "Volvo", ImageSource = "/assets/Audi.jpg", Color = "Blue", Price = 2000.2, Seats = 5},
                    new Car() { _brand = "BMW",  ImageSource = "/assets/Fiat.jpg", Color = "Red", Price = 4000, Seats = 6},
                    new Car() { _brand = "Opel", ImageSource = "/assets/Funnycar.jpg" , Color = "Yellow", Price = 10000.5, Seats = 5},
                    new Car() { _brand = "Toyota", ImageSource = "/assets/OldCar.jpg", Color = "White", Price = 500.2, Seats = 1 }
                };
            }
        }

        public override string ToString()
        {
            return "This is a " + _brand;
        }

        public string ImageSource { get; set; }

        //public Car SelectedCar { get; set; }
        private Car _selectedCar;

        public Car SelectedCar
        {
            get { return _selectedCar; }
            set
            {
                _selectedCar = value;
                OnPropertyChanged();
            }
        }


        public int Seats { get; set; }

        public string Color { get; set; }

        public double Price { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
