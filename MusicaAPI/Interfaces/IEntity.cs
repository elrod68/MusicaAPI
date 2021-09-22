using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicaAPI.Interfaces
{
    //generic entity interface, for the time being contains only ID.
    //could be expanded to add more properties, such as user/update info 
    public interface IEntity<Q> where Q:IComparable
    {
        public Q ID { get; set; }
    }
}
