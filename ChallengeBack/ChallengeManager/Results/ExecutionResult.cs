using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeManager
{
    public class ExecutionResult
    {

        public bool Success { get; set; } = true;
        public int ErrorCode { get; set; }
        public string Message { get; set; }

        /// <summary>
        /// Unsuccess result for object not found
        /// </summary>
        /// <returns>Unsuccess result</returns>
        public dynamic ToObjectNotFound()
        {
            ErrorCode = 1;
            Success = false;
            return this;
        }

        /// <summary>
        /// Unsuccess result for object duplicated
        /// </summary>
        /// <returns>Unsuccess result</returns>
        public dynamic ToObjectDuplicated()
        {
            ErrorCode = 2;
            Success = false;
            return this;
        }

        /// <summary>
        /// Unsuccess result for bad request
        /// </summary>
        /// <returns>Unsuccess result</returns>
        public dynamic ToBadRequest()
        {
            ErrorCode = 3;
            Success = false;
            return this;
        }

        /// <summary>
        /// Unsuccess result for bad request include message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public dynamic ToBadRequest(string message)
        {
            Message = message;
            ErrorCode = 3;
            Success = false;
            return this;
        }

    }
}
