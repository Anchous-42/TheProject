using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.Models
{
    internal class Record<T>: DynamicObject
    {
        public int Id { get; private set; }
        public T Data { get; set; }

        public Record(int id, T data) {
            Id = id;
            Data = data; 
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
