using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Imp
{
    //this class will hold all of the functions that are needed for the code
    class Functions
    {
        private int CurrentRule = 1;
        Program P = new Program();

        private bool Majority(float percentOfVote, float percentOfPop, float percentNeed, float popNeeded)
        {
            if ((percentOfVote > percentNeed) && (percentOfPop > popNeeded))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SimpMajority(float percentOfVote, float percentOfPop)
        {
            return Majority(percentOfVote, percentOfPop, (float)0.5, (float)0.0);
        }
        public bool ReinforcedMajority(float percentOfVote, float percentOfPop)
        {
            return Majority(percentOfVote, percentOfPop, (float)0.72, (float)0.65);
        }
        public bool QualifiedMajority(float percentOfVote, float percentOfPop)
        {
            
            return Majority(percentOfVote, percentOfPop, (float)0.55, (float)0.65);
        }

        public bool TestMajority(float percentOfVote, float percentOfPop)
        {
            if(CurrentRule == 0)
            {
                return SimpMajority(percentOfVote, percentOfPop);
            }
            if (CurrentRule == 1)
            {
                return ReinforcedMajority(percentOfVote, percentOfPop);
            }
            if (CurrentRule == 2)
            {
                return QualifiedMajority(percentOfVote, percentOfPop);
            }
            if(CurrentRule == 3)
            {
                return Unanimity(percentOfVote, percentOfPop);
            }
            else
            {
                return false;
            }
        }
        public bool Unanimity(float percentOfVote, float percentOfPop)
        {
            if((percentOfVote == 1.0) && (percentOfPop == 1.0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
