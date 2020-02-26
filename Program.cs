//This program was created by Seth Barrett to act as a polling machine
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polling_Station
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many candidates are running?(1-8)");
            PollBooth _polling = new PollBooth(UserInputVeri(lowerBound: 1, upperBound: 8, response: "Please enter a valid number of candidates."));
            _polling.SetUpBooth();
            _polling.AllowVoting();
            _polling.ShowWinner();
        }
        static int UserInputVeri(int lowerBound, int upperBound, bool letter = false, string response = "Please enter a valid value")
        {
            bool flag = false;
            bool realLet = false;
            int output = 0;
            char charput;
            if (letter)
            {
                while (!flag)
                {
                    string input = Console.ReadLine();
                    realLet = char.TryParse(input, out charput);
                    if (realLet)
                    {
                        int place = (int)charput;
                        if (place >= 65 && place <= 90) return output = place - 65;
                        else if (place >= 97 && place <= 122) return output = place - 97;
                        else flag = int.TryParse(input, out output);
                    }
                    else flag = int.TryParse(input, out output);

                    if (!flag || output < lowerBound || output > upperBound) Console.WriteLine(response);
                }
            }
            else
            {
                while (!flag || output < lowerBound || output > upperBound)
                {
                    flag = int.TryParse(Console.ReadLine(), out output);
                    if (!flag || output < lowerBound || output > upperBound) Console.WriteLine(response);
                }
            }
            return output;
        }
        //This method does user input verification for allowed int values and certain char values based upon the parameters.
    }
}
