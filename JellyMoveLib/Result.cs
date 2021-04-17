using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JellyMoveLib
{
    public static class Result
    {
        public static string DisplayResult(List<Jelly> lstJelly)
        {
            var finalResult = new StringBuilder();
            foreach (var jelly in lstJelly)
            {
                string result = jelly.X + " " + jelly.Y + " " + jelly.Orientation;
                if (jelly.IsLost)
                {
                    result += "LOST";
                }
                finalResult.Append(result);
            }
            return finalResult.ToString();
        }
    }
}
