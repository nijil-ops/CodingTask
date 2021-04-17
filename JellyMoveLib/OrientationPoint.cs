using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JellyMoveLib
{
    public static class OrientationPoint
    {
        public static string[] OrientationArr = new string[4] { "N", "E", "S", "W" };
    }
    public enum Instruction
    {
        forward,
        right,
        left
    }
}
