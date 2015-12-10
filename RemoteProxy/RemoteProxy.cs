using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteProxy
{
    class RemoteProxy
    {
        static void Main(string[] args)
        {
            ICar car = new ProxyCar(new Driver(16));
            car.DriveCar();

            car = new ProxyCar(new Driver(25));
            car.DriveCar();
        }

        interface ICar
        {
            void DriveCar();
        }

        //Real Object 
        public class Car : ICar
        {
            public void DriveCar()
            {
                Console.WriteLine("Car has been driven!");
            }
        }

        public class Driver
        {
            public int Age { get; set; }

            public Driver(int age)
            {
                this.Age = age;
            }
        }

        //Proxy Object
        public class ProxyCar : ICar
        {
            private Driver driver;
            private ICar realCar;

            public ProxyCar(Driver driver)
            {
                this.driver = driver;
                realCar = new Car();
            }

            public void DriveCar()
            {
                if (driver.Age <= 16)
                    Console.WriteLine("Sorry, the driver is too young to drive.");
                else
                    realCar.DriveCar();
            }
        }

    }
}
