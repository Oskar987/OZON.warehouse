using System;
using System.Runtime.Serialization;

namespace Warehouse.Exceptions.Core
{
    [Serializable]
    public class WarehouseException : Exception
    {
        public WarehouseException(string message)
            : base(message)
        {
        }

        public WarehouseException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }

        public WarehouseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
