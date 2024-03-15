using Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Domain.Exceptions;

public class BadRequestException : Exception, ICustomException
{ 
    private List<ErrorMessageResponse> Errors { get; }

    public int StatusCode { get => 400;}

    public BadRequestException(List<ErrorMessageResponse> errors) : base()
    {
        Errors = errors;
    }

    public string GetResponse() => JsonSerializer.Serialize(Errors);
}
