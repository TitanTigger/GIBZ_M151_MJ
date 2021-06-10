using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_Business.Models
{
    public class Generic_ResultSet<T>:StandardResultObject
    {
        
            public T result_set { get; set; }
        
    }
}
