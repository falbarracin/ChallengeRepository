using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationChallenge.Models
{
    /// <summary>
    /// response base
    /// </summary>
    public class RespnseBase
    {
        /// <summary>
        /// Response base class.
        /// </summary>
        public class ResponseBase
        {
            public DateTime CurrentTime { get; set; } = DateTime.Now;

            public DateTime CurrentTimeUtc { get; set; } = DateTime.Now.ToUniversalTime();

            public string Message { get; set; }
            public bool Sucess { get; set; }
        }

        /// <summary>
        /// Override class of Response base.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class ResponseBase<T> : ResponseBase
        {
            public T Data { get; set; }
        }
    }
}