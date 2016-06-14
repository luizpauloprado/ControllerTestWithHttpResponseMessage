using LuizPauloPradoBlog.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizPauloPradoBlog.Repository.Interface
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAll();
        Car Get(string model);
        void Add(Car car);
    }
}
