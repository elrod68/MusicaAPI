using MusicaAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicaAPI.Models
{
    //generic entity prototype, for the time being contains only ID.
    //could be expanded to add more properties, such as user/update info or switch to another ORM, for example XPO
    public abstract class GenericEntity<Q> : IEntity<Q> where Q:IComparable
    {
        public Q ID { get; set; }
    }
}
