using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzelDers.Entity.Abstract
{
    public interface IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsApproved { get; set; }
        public string Url { get; set; }
    }
}