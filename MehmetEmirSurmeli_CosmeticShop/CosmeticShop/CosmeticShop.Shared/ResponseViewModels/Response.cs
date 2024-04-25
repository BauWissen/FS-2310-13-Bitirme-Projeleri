using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticShop.Shared.ResponseViewModels
{
    public class Response<T>
    {
        public T Data { get; set; }
        public string Error { get; set; }
        public bool IsSucceeded { get; set; }
        public static Response<T> Success(T data)
        {
            return new Response<T>
            {
                Data = data,
                IsSucceeded = true
            };
        }
        public static Response<T> Success()
        {
            return new Response<T>
            {
                Data = default(T),
                IsSucceeded = true
            };
        }
        public static Response<T> Fail(string error)
        {
            return new Response<T>
            {
                Error = error,
                IsSucceeded = false
            };
        }
    }
}
