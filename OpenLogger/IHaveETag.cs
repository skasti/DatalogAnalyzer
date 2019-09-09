using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLogger.Core
{
    public interface IHaveETag
    {
        string ETag { get; set; }
    }
}
