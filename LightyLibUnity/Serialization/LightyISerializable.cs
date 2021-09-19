using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightyLibUnity.Serialization
{
    public interface LightyISerializable
    {
        string ToSerializedString();
        void FromSerializedString(string serializedData);
    }
}
