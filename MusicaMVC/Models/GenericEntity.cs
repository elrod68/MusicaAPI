using MusicaMVC.Interfaces;
using System;

namespace MusicaMVC.Models
{
    public class GenericEntity<Q> : IEntity<Q> where Q:IComparable
    {
        public Q ID { get; set; }
    }
}
