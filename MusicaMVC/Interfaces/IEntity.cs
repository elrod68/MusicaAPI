using System;

namespace MusicaMVC.Interfaces
{
    //generic entity interface
    public interface IEntity<Q> where Q:IComparable
    {
        public Q ID { get; set; }
    }
}
