using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LuizPauloPradoBlog.Repository.Interface;
using LuizPauloPradoBlog.Repository;
using LuizPauloPradoBlog.Repository.Model;
using System.Collections.Generic;
using LuizPauloPradoBlog.WebApi.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Linq;

namespace LuizPauloPradoBlog.WebApi.Tests
{
    [TestClass]
    public class CarControllerTest
    {
        private ICarRepository _repository;

        [TestInitialize]
        public void Initialize()
        {
            var carSamples = new List<Car>();
            carSamples.Add(new Car() { Name = "Fiesta", Model = "Fiesta SE", YearOfManufacture = 2015 });
            carSamples.Add(new Car() { Name = "Golf", Model = "Golf Sport", YearOfManufacture = 2015 });
            carSamples.Add(new Car() { Name = "Civic", Model = "Civic S", YearOfManufacture = 2016 });

            _repository = new CarRepository(carSamples);
        }

        [TestMethod]
        public void ShouldGetAllCars()
        {
            var controller = new CarController(_repository);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var result = controller.Get();

            IEnumerable<Car> cars;

            Assert.IsTrue(result.TryGetContentValue<IEnumerable<Car>>(out cars));
            Assert.IsNotNull(cars);
            Assert.AreEqual(3, cars.Count());
        }

        [TestMethod]
        public void ShouldGetCar()
        {
            var controller = new CarController(_repository);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            
            var result = controller.Get("Fiesta SE");

            Car car;

            Assert.IsTrue(result.TryGetContentValue<Car>(out car));
            Assert.AreEqual(car.Model, "Fiesta SE");
        }

        [TestMethod]
        public void ShouldPostCar()
        {
            var controller = new CarController(_repository);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var newCar = new Car() { Name = "IX 35", Model = "IX 35 Special", YearOfManufacture = 2016 };

            var result = controller.Post(newCar);

            Car car;

            Assert.IsTrue(result.TryGetContentValue<Car>(out car));
            Assert.IsNotNull(car);
            Assert.AreEqual(car.Name, newCar.Name);
            Assert.AreEqual(car.Model, newCar.Model);
            Assert.AreEqual(car.YearOfManufacture, newCar.YearOfManufacture);
        }
    }
}
