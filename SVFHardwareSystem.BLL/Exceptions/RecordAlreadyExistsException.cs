using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Exceptions
{
    /// <summary>
    /// Throw this exception for records that are exists
    /// </summary>
    public class RecordAlreadyExistsException : CustomBaseException
    {
        /// <summary>
        /// Initializer
        /// </summary>
        public RecordAlreadyExistsException() { }
        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="recordIdentifier">Record Already exists for {recordIdentifier}</param>
        public RecordAlreadyExistsException(string recordIdentifier) : base(String.Format("Record Already exists for {0}", recordIdentifier))
        {
        }
    }
}
