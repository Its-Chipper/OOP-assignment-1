using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Imp
{
    //this class will hold all of the functions that are needed for the code
    class Functions
    {
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
        bool SimpMajority(float percentOfVote, float percentOfPop)
        {
            return Majority(percentOfVote, percentOfPop, (float)0.5, (float)0.0);
        }
        bool ReinforcedMajority(float percentOfVote, float percentOfPop)
        {
            return Majority(percentOfVote, percentOfPop, (float)0.72, (float)0.65);
        }
        bool QualifiedMajority(float percentOfVote, float percentOfPop)
        {
            return Majority(percentOfVote, percentOfPop, (float)0.55, (float)0.65);
        }
    }
}
