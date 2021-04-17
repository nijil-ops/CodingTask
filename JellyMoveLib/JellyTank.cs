using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JellyMoveLib
{
    public class JellyTank
    {
        public int MaxX { get; }
        public int MaxY { get; }
        private List<Coordinate> lstScentedCoordinates = new List<Coordinate>();
        public JellyTank(int x, int y)
        {
            MaxX = x;
            MaxY = y;
        }
        public bool IsScent(int x, int y)
        {
            return lstScentedCoordinates.Any(a => a.X == x && a.Y == y);
        }
        public void AddScentedCoordinates(Coordinate objCordinate)
        {
            lstScentedCoordinates.Add(objCordinate);
        }
    }
}
