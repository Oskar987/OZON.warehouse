﻿using Newtonsoft.Json;

namespace Warehouse.API.Exceptions
{
    public class ErrorDetails
    {
        public ErrorDetails()
        {
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
