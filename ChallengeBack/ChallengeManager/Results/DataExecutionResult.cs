using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeManager
{
    public class DataExecutionResult<T> : ExecutionResult
    {
        public T Data { get; set; }

    }
}
