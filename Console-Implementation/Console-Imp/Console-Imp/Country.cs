using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Imp
{
    //this will hold all the infomation for the countries and will hold the functions specific to the countries
    public class Country
    {
        public int Population;
        public string Name;
        private int Vote_; //store as int as there are 4 diffrent options forn the countries to vote for
        public int Vote { get
            {
                return Vote_;
            } 
        }

        public bool ChangeVote(int NewVote)
        {
            if(NewVote >= 0 && NewVote <= 3){
                Vote_ = NewVote;
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetVote()
        {
            return Vote_;
        }

        public string GetVoteString()
        {
            if(Vote_ == 0)
            {
                return "For";
            }
            else if(Vote_ == 1)
            {
                return "Against";
            }
            else if(Vote_ == 2)
            {
                return "Abstain";
            }
            else if(Vote_ == 3)
            {
                return "No Vote";
            }
            else
            {
                return "Invalid Vote";
            }
        }
    }
}
