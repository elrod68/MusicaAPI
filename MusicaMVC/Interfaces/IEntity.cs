using System;

namespace MusicaMVC.Interfaces
{
    public interface IEntity<Q> where Q:IComparable
    {
        public Q ID { get; set; }
    }
}
