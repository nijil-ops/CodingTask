using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JellyMoveLib
{
    public class Input
    {
        public string GetInput()
        {
            var inputValue = new StringBuilder();
            string value;
            do
            {
                value = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(value))
                {
                    inputValue.AppendLine(value);
                }
            } while (value != "");
            return inputValue.ToString();
        }

        public List<Jelly> ExtractInputAndGenerateResult(string inputValue)
        {
            List<Jelly> lstJelly = new List<Jelly>();
            var inputArr = inputValue.Split(
                                            new[] { Environment.NewLine },
                                            StringSplitOptions.RemoveEmptyEntries
                                            ).ToArray();

            int range = Convert.ToInt32(inputArr[0]);
            int maxX = range / 10;
            int maxY = range % 10;

            for (int i = 1; i < inputArr.Length; i++)
            {
                //jellyfish loc and orientation
                //considering only one row right now.
                string jellyFishPositionDirectionAndInstruction = inputArr[i];
                if (!string.IsNullOrEmpty(jellyFishPositionDirectionAndInstruction))
                {
                    string jellyFishPosition = jellyFishPositionDirectionAndInstruction.Split()[0];
                    string jellyFishCoordinate = new string(jellyFishPosition.Where(Char.IsDigit).ToArray());
                    string jellyFishOrientation = jellyFishPosition.Last().ToString();
                    string jellyFishInstruction = jellyFishPositionDirectionAndInstruction.Split()[1];
                    int jellyFishCoordinateX = Convert.ToInt32(jellyFishCoordinate) / 10;
                    int jellyFishCoordinateY = Convert.ToInt32(jellyFishCoordinate) % 10;

                    //Create Jelly tank object
                    var objJellyTank = new JellyTank(maxX, maxY);
                    //Create Jelly object
                    var objJelly = new Jelly(jellyFishCoordinateX, jellyFishCoordinateY, jellyFishOrientation);
                    char[] instructionArr = jellyFishInstruction.ToCharArray();
                    foreach (char inst in instructionArr)
                    {
                        objJelly.RunInstruction(GetInstruction(inst.ToString()), objJellyTank);
                    }
                    lstJelly.Add(objJelly);
                }
            }
            return lstJelly;
        }

        private Instruction GetInstruction(string instruction)
        {
            switch (instruction)
            {
                case "F":
                    return Instruction.forward;
                case "R":
                    return Instruction.right;
                case "L":
                    return Instruction.left;
                default:
                    throw new ArgumentException("Instruction is not available");
            }
        }
    }
}
