using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polling_Station
{
    class Candidate
    {
        public string _name
        {
            get; set;
        }
        //Property to represent the candidate's name
        public string _party
        {
            get;set;
        }
        //Property to represent the candidate's party
        private int _numVotes
        {
            get; set;
        }
        //Int to represent the number of votes a candidate recieves
        public Candidate(string name, string party = "")
        {
            _name = name;
            _party = party;
            _numVotes = 0;
        }
        //Creator method
        public void AddVote()
        {
            _numVotes++;
        }
        //Method increments _numVotes
        public int GetTotalVotes()
        {
            return _numVotes;
        }
        //Method returns the number of votes the candidate recieves.
        public void Show()
        {
            Console.WriteLine($"{_name}: {_numVotes} votes");
        }
        //Method writes the Candidate's name and number of votes
    }
}
