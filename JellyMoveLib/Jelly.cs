using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JellyMoveLib
{
    public class Jelly
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsLost { get; set; }
        public string Orientation { get; set; }
        public Jelly(int x, int y, string orientation)
        {
            X = x;
            Y = y;
            Orientation = orientation;
        }
        public void RunInstruction(Instruction instruction, JellyTank objJellyTank)
        {
            if (!IsLost)
            {
                switch (instruction)
                {
                    case Instruction.forward:
                        MoveFoward(objJellyTank);
                        break;
                    case Instruction.right:
                        MoveRight();
                        break;
                    case Instruction.left:
                        MoveLeft();
                        break;
                }
            }
        }

        private void MoveFoward(JellyTank objJellyTank)
        {
            var nextPosition = NextPosition();
            if (IsOutside(nextPosition.X, nextPosition.Y, objJellyTank) && !objJellyTank.IsScent(X, Y))
            {
                this.IsLost = true;
                objJellyTank.AddScentedCoordinates(new Coordinate(X, Y));
            }
            else
            {
                X = nextPosition.X;
                Y = nextPosition.Y;
            }
        }
        private void MoveRight()
        {
            if (Orientation == "W")
            {
                Orientation = "N";
            }
            else
            {
                var index = Array.FindIndex(OrientationPoint.OrientationArr, row => row == Orientation);
                Orientation = OrientationPoint.OrientationArr[index + 1];
            }
        }
        private void MoveLeft()
        {
            if (Orientation == "N")
            {
                Orientation = "W";
            }
            else
            {
                var index = Array.FindIndex(OrientationPoint.OrientationArr, row => row == Orientation);
                Orientation = OrientationPoint.OrientationArr[index + 1];
            }
        }
        private bool IsOutside(int x, int y, JellyTank objJellyTank)
        {
            bool isOut = false;

            if (x > objJellyTank.MaxX || x < 0 || y > objJellyTank.MaxY || y < 0)
            {
                isOut = true;
            }
            return isOut;
        }

        private Coordinate NextPosition()
        {
            var nextPosition = new Coordinate(X, Y);
            switch (Orientation)
            {
                case "N":
                    nextPosition.Y++;
                    break;
                case "E":
                    nextPosition.X++;
                    break;
                case "S":
                    nextPosition.Y--;
                    break;
                case "W":
                    nextPosition.X--;
                    break;
                default:
                    break;
            }
            return nextPosition;
        }
    }
}
