﻿using Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Domain.Exceptions;

public class NotFoundException : Exception, ICustomException
{
    public NotFoundException(string message) : base(message)
    {
    }

    public int StatusCode { get => 404; }

    public string GetResponse() => JsonSerializer.Serialize(new ErrorResponse(base.Message));
}
