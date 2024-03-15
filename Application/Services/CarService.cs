
using Domain.Entities;
using Domain.Exceptions;
using Domain.Mappers;
using Domain.Requests;
using Domain.Responses;
using Domain.Validators;
using Infrastructure.Repositories;

namespace Application.Services;

public interface ICarService
{
    public List<CarResponse> List();

    public CarResponse? GetById(int id);

    public CarResponse Create(BaseCarRequest newCar);

    public CarResponse Update(UpdateCarRequest updatedCar);

    public void Delete(int id);
}

public class CarService : ICarService
{
    private readonly ICarRepository _repository;
    private readonly IValidator<BaseCarRequest> _validator;

    public CarService(ICarRepository repository, IValidator<BaseCarRequest> validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public List<CarResponse> List()
    {
        var cars =  _repository.List();
        var response = cars.Select(car => CarMapper.ToResponse(car)).ToList();
        return response;
    }

    public CarResponse? GetById(int id)
    {
        var car = _repository.GetById(id);
        return car is null ? null : CarMapper.ToResponse(car);
    }

    public CarResponse Create(BaseCarRequest request)
    {
        var errors = _validator.Validate(request);

        if (errors.Any())
            throw new BadRequestException(errors);

        var newCar = CarMapper.ToEntity(request);

        var car = _repository.Create(newCar);

        return CarMapper.ToResponse(car);
    }

    public CarResponse Update(UpdateCarRequest request)
    {
        var errors = _validator.Validate(request);

        if (errors.Any())
            throw new BadRequestException(errors);

        var existingCar = _repository.GetById(request.Id);

        if (existingCar is null)
            throw new NotFoundException("Car not found!");

        var updateCar = CarMapper.ToEntity(request);

        var car = _repository.Update(updateCar);
        return CarMapper.ToResponse(car);
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    }
}
