using LuizPauloPradoBlog.Repository;
using LuizPauloPradoBlog.Repository.Interface;
using LuizPauloPradoBlog.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LuizPauloPradoBlog.WebApi.Controllers
{
    public class CarController : ApiController
    {
        private ICarRepository _repository;

        public CarController(ICarRepository repository)
        {
            _repository = repository;
        }

        public HttpResponseMessage Get()
        {
            var cars = _repository.GetAll();

            return Request.CreateResponse(cars);
        }

        public HttpResponseMessage Get(string model)
        {
            var car = _repository.Get(model);

            if (car == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            
            return Request.CreateResponse(car);
        }

        public HttpResponseMessage Post(Car car)
        {
            _repository.Add(car);

            return Request.CreateResponse(HttpStatusCode.Created, car);
        }
    }
}
