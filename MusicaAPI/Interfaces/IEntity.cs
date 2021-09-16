using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicaAPI.Interfaces
{
    public interface IEntity<Q> where Q:IComparable
    {
        public Q ID { get; set; }
    }
}
