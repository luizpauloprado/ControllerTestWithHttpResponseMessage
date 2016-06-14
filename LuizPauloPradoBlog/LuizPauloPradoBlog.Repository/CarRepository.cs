using LuizPauloPradoBlog.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuizPauloPradoBlog.Repository.Model;

namespace LuizPauloPradoBlog.Repository
{
    public class CarRepository : ICarRepository
    {
       private List<Car> _cars;

        public CarRepository(List<Car> cars)
        {
            _cars = cars;
        }

        public CarRepository()
        {
            _cars = new List<Car>();
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public Car Get(string model)
        {
            return _cars.FirstOrDefault(x => x.Model == model);
        }

        public IEnumerable<Car> GetAll()
        {
            return _cars;
        }
    }
}
