using Achievers.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Achievers.Data.Models
{
    public class File : BaseModel<int>
    {
        public string Name { get; set; }

        public byte[] Content { get; set; }

        public string ContentType { get; set; }
    }
}
