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
        private int Vote; //store as int as there are 4 diffrent options forn the countries to vote for

        public bool ChangeVote(int NewVote)
        {
            if(NewVote >= 0 && NewVote <= 3){
                Vote = NewVote;
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetVote()
        {
            return Vote;
        }
    }
}
