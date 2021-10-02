using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LightyLibUnity.Extensions.Math
{
    public static class Vector3Extension
    {
        public static Vector3 SwithYZ(this Vector3 vector3)
        {
            return new Vector3(vector3.x, vector3.z, vector3.y);
        }
    }
}
