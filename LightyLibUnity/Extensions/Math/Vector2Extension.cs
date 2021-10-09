using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LightyLibUnity.Extensions.Math
{
    public static class Vector2Extension
    {
        public static Vector3 MakeVector3XZ(this Vector2 vector2, float y = 0f)
        {
            return new Vector3(vector2.x, y, vector2.y);
        }
    }
}
