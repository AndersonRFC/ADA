using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Requests;
using Domain.Responses;

namespace Domain.Validators;

public class CarValidator : IValidator<BaseCarRequest>
{
    public List<ErrorMessageResponse> Validate(BaseCarRequest car)
    {
        var errors = new List<ErrorMessageResponse>();

        if(string.IsNullOrEmpty(car.Brand))
        {
            errors.Add(new ErrorMessageResponse
            {
                Field = "Brand",
                Message = "Field is required!"
            });
        }
        if (string.IsNullOrEmpty(car.Brand))
        {
            errors.Add(new ErrorMessageResponse
            {
                Field = "Model",
                Message = "Field is required!"
            });
        }

        return errors;
    }
}
