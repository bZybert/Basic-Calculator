using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_calculator
{
    /// <summary>
    /// Holds information about single calculator operation
    /// </summary>
    public class Operation
    {
        #region Public properties
        public string LeftSide { get; set; }
        public string RightSide { get; set; }
        public OperationType OperationType { get; set; }

        public Operation innerOperation { get; set; }
        #endregion

        #region Constructor
        public Operation()
        {
            this.LeftSide = string.Empty;
            this.RightSide = string.Empty;
        }
        #endregion
    }
}
