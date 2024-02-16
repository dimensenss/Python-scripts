using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDZ
{
    public interface IName : IComparable<IName>
    {
        string Name { get; }
    }
    public interface IPrice
    {
        decimal Price { get; }
        event EventHandler<PriceEventData> update;
    }
    public interface ISerializable
    {
        void GetObjectData(BinaryWriter _writer);
        void SetObjectData(BinaryReader _reader);
    }
    public class PriceEventData : EventArgs
    {
        public PriceEventData(decimal price)
        {
            _price = price;
        }
        public decimal _price { get; }
    }
}
