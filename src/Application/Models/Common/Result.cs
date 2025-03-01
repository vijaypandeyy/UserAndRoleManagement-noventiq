using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Common
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }
        public int StatusCode { get; set; }

        private Result(bool success, T? data, string? message, List<string>? errors, HttpStatusCode statusCode)
        {
            Success = success;
            Data = data;
            Message = message;
            Errors = errors;
            StatusCode = (int)statusCode;
        }

        
        public static Result<T> SuccessResult(T data, string message = "Operation successful")
        {
            return new Result<T>(true, data, message, null,HttpStatusCode.OK);
        }

        
        public static Result<T> FailureResult(List<string> errors, HttpStatusCode statusCode, string message = "Operation failed")
        {
            return new Result<T>(false, default, message, errors, statusCode);
        }

        
        public static Result<T> FailureResult(string error, HttpStatusCode statusCode, string message = "Operation failed")
        {
            return new Result<T>(false, default, message, new List<string> { error }, statusCode);
        }

        public static Result<T> BadRequest(string error) => FailureResult(error, HttpStatusCode.BadRequest, "Invalid request");
        public static Result<T> BadRequest(List<string> errors) => FailureResult(errors, HttpStatusCode.BadRequest, "Invalid request");
        public static Result<T> Forbidden(string error) => FailureResult(error, HttpStatusCode.Forbidden, "Access denied");
        public static Result<T> NotFound(string error) => FailureResult(error, HttpStatusCode.NotFound, "Resource not found");
        public static Result<T> ServerError(string error) => FailureResult(error, HttpStatusCode.InternalServerError, "Internal server error");
        public static Result<T> ServerError(List<string> errors) => FailureResult(errors, HttpStatusCode.InternalServerError, "Internal server error");
    }
}
