using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сalculator;

namespace calculator.Operations
{
    class PrioritizedOperation
    {
        public IOperation Operation { get; set; }
        public byte Priority { get; set; }
    }
}
