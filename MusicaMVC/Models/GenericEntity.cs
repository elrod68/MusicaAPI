using MusicaMVC.Interfaces;
using System;

namespace MusicaMVC.Models
{
    //generic entity, as used in API also
    public class GenericEntity<Q> : IEntity<Q> where Q:IComparable
    {
        public Q ID { get; set; }
    }
}
