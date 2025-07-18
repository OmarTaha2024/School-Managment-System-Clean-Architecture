﻿using SchoolManagment.XUnitTest.TestModels;

namespace SchoolManagment.XUnitTest.MoqTest
{
    public interface ICarMoqService
    {
        public bool AddCar(Car car);
        public bool RemoveCar(int? id);
        public List<Car> GetAll();
    }
}
