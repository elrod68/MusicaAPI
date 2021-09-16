using MusicaAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicaAPI.Models
{
    public class GenericEntity<Q> : IEntity<Q> where Q:IComparable
    {
        public Q ID { get; set; }
    }
}
