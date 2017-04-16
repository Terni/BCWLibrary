using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expanded.DBase.Interface
{
    public interface ITwithId
    {
        // For your method the set(ter) isn't necessary
        // public int Id { get; set; }
        int Id { get; }
    }

}
