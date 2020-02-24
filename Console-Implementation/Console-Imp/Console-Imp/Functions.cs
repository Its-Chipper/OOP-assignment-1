using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Imp
{
    //This class will hold all of the functions that are needed for the code.
    class Functions
    {
<<<<<<< HEAD
        private int CurrentRule = 1;
        Program P = new Program();
=======
        private int CurrentRule = 1; //Default vote of 'yes'.
>>>>>>> origin/New_Functions

        private bool Majority(float percentOfVote, float percentOfPop, float percentNeed, float popNeeded) //Framework method for different types of majority vote.
        {
            if ((percentOfVote > percentNeed) && (percentOfPop > popNeeded)) //Validation for votes and population to be more than required of each majority type.
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SimpMajority(float percentOfVote, float percentOfPop) //Percentage of vote >= 50%.
        {
            return Majority(percentOfVote, percentOfPop, (float)0.5, (float)0.0);
        }
        public bool ReinforcedMajority(float percentOfVote, float percentOfPop) //Percentage of vote >= 72%, percentage of population >= 65%.
        {
            return Majority(percentOfVote, percentOfPop, (float)0.72, (float)0.65);
        }
        public bool QualifiedMajority(float percentOfVote, float percentOfPop) //Percentage of vote >= 55%, percentage of population >= 65%.
        {
            
            return Majority(percentOfVote, percentOfPop, (float)0.55, (float)0.65);
        }
        public bool TestMajority(float percentOfVote, float percentOfPop) //Method for majority choice from menu.
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
