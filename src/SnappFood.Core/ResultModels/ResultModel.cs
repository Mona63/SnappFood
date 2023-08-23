using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappFood.Core
{
    public class ResultModel<TEntity>
    {
        public bool Succeeded { get; set; }
        public TEntity? Entity { get; set; }
        public Error? Error { get; set; }

        public static ResultModel<TEntity> StandardOk(TEntity entity)
        {
            return new ResultModel<TEntity>
            {
                Succeeded = true,
                Entity = entity
            };
        }
        public static ResultModel<TEntity> StandardError(Error error)
        {
            return new ResultModel<TEntity>
            {
                Succeeded = false,
                Error = error
            };
        }
    }
}
