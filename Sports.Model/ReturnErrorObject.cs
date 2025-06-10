using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Models
{

    public class SportAPIResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }

        public Exception? Ex { get; set; }
        public string? Message { get; set; }
        public int StatusCode { get; set; }


        public List<ValidationError> ValidationErrors { get; set; }  // Add ValidationErrors list

        public SportAPIResponse(T data, int statusCode = 200, bool sucess = false)
        {
            Data = data;
            ValidationErrors = new List<ValidationError>();  // Initialize empty validation errors list
            StatusCode = statusCode; // Default to 200 if not specified
            Success = sucess;

        }

        public SportAPIResponse(string message, int statusCode, bool sucess)
        {
            Message = message;
            StatusCode = statusCode;
            ValidationErrors = new List<ValidationError>();  // Initialize empty validation errors list
            Success = sucess;


        }
    }


}

