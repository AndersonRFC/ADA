
using Domain.Entities;

namespace Infrastructure.Repositories;

public interface ICarRepository
{
    public List<Car> List();

    public Car? GetById(int id);

    public Car Create(Car newCar);

    public Car Update(Car updatedCar);

    public void Delete(int id);
}

public class CarRepository : ICarRepository
{
    private List<Car> _cars = new List<Car>();

    public List<Car> List()
    {
        return _cars;
    }

    public Car? GetById(int id)
    {
        return _cars.FirstOrDefault(x => x.Id == id);
    }

    public Car Create(Car newCar)
    {
        newCar.Id = _cars.Count + 1;
        _cars.Add(newCar);

        return newCar;
    }

    public Car Update(Car updatedCar)
    {
        var car = GetById(updatedCar.Id);

        if (car is null)
            throw new Exception("Car not found!");

        car.Brand = updatedCar.Brand;
        car.Model = updatedCar.Model;

        return car;
    }

    public void Delete(int id)
    {
        var car = GetById(id);

        if (car is null)
            throw new Exception("Car not found!");

        _cars.Remove(car);
    }
}
