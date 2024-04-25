using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTask.Shared.Response
{
    public class APIResponse<T>// business response and api response can be seperated will fix
    {
        public bool IsSucceeded { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public static APIResponse<T> Success(string message, T data)
        {
            return new APIResponse<T>
            {
                Data = data,
                IsSucceeded = true,
                Message = message
            };
        }
        public static APIResponse<T> Success(string message)
        {
            return new APIResponse<T>
            {
                Data = default(T),
                IsSucceeded = true,
                Message = message
            };
        }
        public static APIResponse<T> Fail(string message)
        {
            return new APIResponse<T>
            {
                IsSucceeded = false,
                Message = message
            };
        }
    }
}
