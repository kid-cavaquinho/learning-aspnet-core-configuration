using System;
using System.Collections.Generic;

namespace WebApplication.Filters.Startup.Interfaces
{
    public interface IValidatable
    {
        (IEnumerable<string> results, bool valid) Validate();
    }
}
