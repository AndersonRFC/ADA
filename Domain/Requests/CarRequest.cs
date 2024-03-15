using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Requests;

public class BaseCarRequest
{
    public string? Brand { get; set; }

    public string? Model { get; set; }
}

public class UpdateCarRequest : BaseCarRequest
{
    public int Id { get; set; }
}
