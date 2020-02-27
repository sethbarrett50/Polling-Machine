using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polling_Station
{
    class PollBooth
    {
        public List<Candidate> _candidates = new List<Candidate>();
        //List of Candidates
        private bool _allowUnder18 = false;
        //Bool to represent if under 18 voters are allowed.
        private bool _party = false;
        //Bool to represent if the options are affiliated with parties
        private int _numCandidates = 0;
        //Int representing the number of candidates
        private List<Candidate> _winner = new List<Candidate>();

        //Candidate that will reference the candidate with the most final votes
        public PollBooth(int numCandidates)
        {
            _numCandidates = numCandidates;
        }
        //Creator method that sets the number of candidates
        public void SetUpBooth()
        {
            Console.Clear();
            Console.WriteLine("Are there any party affiliations for the options?(y/n)");
            if (Console.ReadLine() == "y") _party = true;
            Console.Clear();
            Console.WriteLine("Do voters have to be 18?(y/n)");
            if (Console.ReadLine() == "n") _allowUnder18 = true;
            Console.Clear();
            for (int i = 0; i < _numCandidates; i++)
            {
                Console.WriteLine($"What is Option {i + 1}'s name?");
                _candidates.Add(new Candidate(name: Console.ReadLine()));
                if (_party)
                {
                    Console.WriteLine($"What is {_candidates[0]._name}'s party?");
                    _candidates[0]._party = Console.ReadLine();
                }
                Console.WriteLine();
            }
            Console.Clear();
        }
        //This method sets up the _candidates List with all the candidate's names and party affiliations
        public void AllowVoting()
        {
            bool flag = false;
            List<Voter> _voters = new List<Voter>();
            //By using an instance List, the List's data is removed keeping voter names safe.
            do
            {
                Console.WriteLine("Hello voter! What is your name?");
                _voters.Insert(0, new Voter(Console.ReadLine()));
                Console.WriteLine("How old are you?");
                bool cheesy = false;
                int tempAge = 1;
                while (!cheesy || tempAge <= 0 || tempAge > 150)
                {
                    cheesy = int.TryParse(Console.ReadLine(), out tempAge);
                    if (!cheesy || tempAge <= 0 || tempAge > 150) Console.WriteLine("Enter a valid age.");
                }
                //Does input verification for the voter's inputted age
                _voters[0]._age = tempAge;
                if(_voters[0]._age >= 18 || _allowUnder18)
                {
                    ShowAllCandidates();
                    Console.WriteLine("Please enter the number of the candidate you would like to vote for");
                    _candidates[UserInputVeri(lowerBound: 1, upperBound: _numCandidates, response: "Please enter a valid candidate number.") - 1].AddVote();
                    Console.WriteLine("Thank you for voting!");
                }
                //Allows valid voters to cast their votes
                else Console.WriteLine("You are too young to vote. Come back when you are 18!");
                Console.WriteLine("Are there any more voters?(y/n)");
                if (Console.ReadLine() == "n") flag = true;
                Console.Clear();
                //Checks to see if there are any more voters
            } while (!flag);
            //Runs a loop for voters to vote
            _winner.Add(_candidates[0]);
            for(int i = 1; i< _numCandidates; i++)
            {
                if (_candidates[i].GetTotalVotes() > _winner[0].GetTotalVotes())
                {
                    _winner.Clear();
                    _winner[0] = _candidates[i];
                }
                else if(_candidates[i].GetTotalVotes() == _winner[0].GetTotalVotes()) _winner.Insert(0, _candidates[i]);
            }
            Console.Clear();
            //Calculates the winner
        }
        //This method allows voters to cast their votes as well as finding the candidate with the most final votes
        public void ShowAllCandidates()
        {
            Console.WriteLine("Candidates:");
            for(int i = 0; i < _numCandidates; i++)
            {
                string temp = $"[{i + 1}]: {_candidates[i]._name}";
                if (_party) temp += $": {_candidates[i]._party} party";
                Console.WriteLine(temp);
            }
        }
        //Displays all the candidates
        public void ShowFinalVotes()
        {
            for(int i = 0; i < _numCandidates; i++)
            {
                _candidates[i].Show();
            }
        }
        //Displays all candidates and their final votes
        public void ShowWinner()
        {
            bool tie = false;
            if (_winner.Count() > 1) tie = true;
            string temp;
            if (tie)
            {
                temp = "There was a tie between";
                for (int i = 0; i < _winner.Count() - 1; i++)
                {
                    temp += $" {_winner[i]._name},";
                    if (_party) temp += $" representing the {_winner[i]._party} party,";
                }
                temp += $" and {_winner[_winner.Count() - 1]._name}";
                if (_party) temp += $", representing the {_winner[_winner.Count() - 1]._party}! ";
                else temp += "! ";
                temp += "They ";
            }
            else
            {
                temp = $"The winning candidate was { _winner[0]._name}";
                if (_party) temp += $"running for the {_winner[0]._party}! ";
                else temp += "! ";
                temp += $"{_winner[0]._name} "; 
            }
            temp += $"won with { _winner[0].GetTotalVotes()} vote";
            if (_winner[0].GetTotalVotes() > 1) temp += "s!";
            else temp += "!";
            Console.WriteLine(temp);
        }
        //Displays the Candidate with the most votes
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
