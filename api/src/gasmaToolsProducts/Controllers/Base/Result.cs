using System.Collections.Generic;

namespace gasmaToolsProducts.Controllers.Base
{
    public class Result : IResult
    {
        public bool Success { get; }

        public IEnumerable<string> Messages { get; }

        public object Data { get; }

        public Result(bool success, IEnumerable<string> messages, object data)
        {
            Success = success;
            Messages = messages;
            Data = data;
        }
    }

    public interface IResult
    {
        bool Success { get; }

        IEnumerable<string> Messages { get; }

        object Data { get; }
    }
}
