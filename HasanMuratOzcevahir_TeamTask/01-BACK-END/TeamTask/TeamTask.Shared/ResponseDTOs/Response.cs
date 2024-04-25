using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTask.Shared.ResponseDTOs
{
    public class Response<T>
    {
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string Error { get; set; }
        public static Response<T> Success(T data)
        {
            return new Response<T>
            {
                Data = data,
                Succeeded = true
            };
        }
        public static Response<T> Failed(string error)
        {
            return new Response<T>
            {
                Succeeded = false,
                Error = error
            };
        }
    }
}
