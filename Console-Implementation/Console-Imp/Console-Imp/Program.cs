using System;
using System.IO;

namespace Console_Imp
{
    class Program
    {
        static Functions FunctionsCall = new Functions();
        static void Main(string[] args)
        {
            //array of the countries
            Country[] CountryInfo = new Country[27];

            //getting the infomation about the countries from the text file
            string Path = Directory.GetCurrentDirectory();
            string Text = File.ReadAllText(Path.Substring(0, Path.Length - 23) + "CountriesInfo.txt");

            string[] CountriesText = Text.Split('\n');

            //putting the infomation from the file into the array
            for(int i = 0; i < CountriesText.Length; i++)
            {
                string[] infoarray = CountriesText[i].Split(' ');
                CountryInfo[i] = new Country();
                CountryInfo[i].Name = infoarray[0];
                CountryInfo[i].Population = Convert.ToInt32(infoarray[1]);
            }

            //loop for the main menu
            //EurozoneVote(); //Test Eurozone method.
            while (true)
            {
                Console.WriteLine(DisplayMenu());

                bool TestInput = false;

                while (!TestInput)
                {
                    Console.WriteLine("Input:");
                    int InputValue = Convert.ToInt32(Console.ReadLine());
                    TestInput = TestMenuInput(InputValue);
                }
            }

            //Method for displaying current state of the votes to the user
            string DisplayVotes()
            {
                string Output = "\n";
                Output += "Country".PadRight(15) + "Population".PadRight(12) + "Vote\n\n";//formating for the output
                foreach (Country info in CountryInfo)//loops through the array of countries 
                {
                    Output += info.Name.PadRight(15) + String.Format("{0:n0}", info.Population).PadRight(12) + info.GetVoteString() + "\n";//formating the country output
                }
                return Output;
            }

            //Method for diaplaying menu to user
            string DisplayMenu()
            {
                string Output = "\nMenu\n";
                Output += "1: Change Single Vote\n";
                Output += "2: Change All Votes\n";
                Output += "3: Display Current Votes\n";
                Output += "4: Change Voting Rule\n";
                Output += "5: Change Country Rule\n";
                Output += "6: Exit\n";

                return Output;
            }

            //takes the users input from the menu
            bool TestMenuInput(int Input)
            {
                if(Input == 1)
                {
                    ChangeSingleVote();
                    return true;
                }else if(Input == 2)
                {
                    ChangeAllVotes();
                    return true;
                }else if(Input == 3)
                {
                    Console.WriteLine(DisplayVotes());
                    TestCurrentVote();
                    return true;
                }else if(Input == 4)
                {
                    //ChangeVoteRule();
                    return true;
                }else if(Input == 5)
                {
                    ChangeCountryRule();
                    return true;
                }else if(Input == 6)
                {
                    Environment.Exit(0);
                }
                return false;
            }

            //method for testing the current sate of the votes
            bool TestCurrentVote()
            {
                int TotalPop = 0;
                int ForPop = 0;
                int AgainstPop = 0;
                int AbstainPop = 0;
                int TotalVote = 0;
                int ForVote = 0;
                int AgainstVote = 0;
                int AbstainVote = 0;
                foreach (Country info in CountryInfo)//loop to get the current votes of all the countries and the population for against and abstaining
                {
                    int Vote = info.Vote;
                    if(Vote != 3)
                    {
                        TotalPop += info.Population;
                        TotalVote += 1;
                        if(Vote == 0)
                        {
                            ForVote += 1;
                            ForPop += info.Population;
                        }else if(Vote == 1)
                        {
                            AgainstVote += 1;
                            AgainstPop += info.Population;
                        }
                        else
                        {
                            AbstainVote += 1;
                            AbstainPop += info.Population;
                        }
                    }
                }

                //working out percentages for the votes and the population
                float VotePercent = (float) ForVote / TotalVote;
                float PopPercent = (float) ForPop / TotalPop;

                //output to the user
                Console.WriteLine("Vote:  For:" + ForVote + " Against:" + AgainstVote + " Abstain:" + AbstainVote + " Percent:" + Math.Round(VotePercent * 100, 2));
                Console.WriteLine("Population:  For:" + String.Format("{0:n0}", ForPop) + " Against:" + String.Format("{0:n0}", AgainstPop) + " Abstain:" + String.Format("{0:n0}", AbstainPop) + " Percent:" + Math.Round(PopPercent * 100, 2));


                //test if the vote passed or was rejected
                if (FunctionsCall.QualifiedMajority(VotePercent, PopPercent))
                {
                    Console.WriteLine("Approved");
                    return true;
                }
                else
                {
                    Console.WriteLine("Rejected");
                    return false;
                }
            }

            //method to change a single vote in the array
            void ChangeSingleVote()
            {
                Console.WriteLine("\nNum".PadRight(6) + "Country".PadRight(15) + "Vote");//formating the output
                for(int i = 0; i < CountryInfo.Length; i++)
                {
                    Console.WriteLine((i+1).ToString().PadRight(5) + CountryInfo[i].Name.PadRight(15) + CountryInfo[i].GetVoteString().PadRight(7));
                }
                int Value = 0;
                //select value
                while (true)
                {
                    //taking users input
                    Console.WriteLine("\nChoose Contry:");
                    Value = Convert.ToInt32(Console.ReadLine());
                    if(Value < 27)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Country (Expecting Int)");
                    }
                }

                //change vote
                while (true)
                {
                    Console.WriteLine("1: For");
                    Console.WriteLine("2: Against");
                    Console.WriteLine("3: Abstain");
                    Console.WriteLine("4: No Vote");
                    
                    Console.WriteLine("Vote");
                    int Vote = Convert.ToInt32(Console.ReadLine());

                    if (CountryInfo[Value-1].ChangeVote(Vote - 1) == true)
                    {
                        Console.WriteLine("Vote Changed");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Vote (Expecting Int)");
                    }
                }
                
            }

            //change all votes
            void ChangeAllVotes()
            {
                foreach (Country info in CountryInfo)
                {
                    Console.WriteLine(info.Name);
                    while (true)
                    {
                        Console.WriteLine("1: For");
                        Console.WriteLine("2: Against");
                        Console.WriteLine("3: Abstain");
                        Console.WriteLine("4: No Vote");

                        Console.WriteLine("Vote");
                        int Vote = Convert.ToInt32(Console.ReadLine());

                        if (info.ChangeVote(Vote - 1))
                        {
                            Console.WriteLine("Vote Changed");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Vote (Expecting Int)");
                        }
                    }
                    Console.WriteLine(info.Name + ":" + info.GetVoteString());
                }
            }
        
            void AllCountriesParticipating()
            {
          
                foreach (Country info in CountryInfo) //loops through each country as info 
                {
                    //If the country vote is set to NoVote(3). It will be set to Against(1) 
                    if (info.GetVote() == 3) 
                    {
                        info.ChangeVote(1);
                    }
                }
            }
        
       
            void EurozoneVote() //Eurozone method to change all non-eurozone votes to not paricipating.
            {
                CountryInfo[1].ChangeVote(3); //Bulgaria
                CountryInfo[3].ChangeVote(3); //Croatia
                CountryInfo[5].ChangeVote(3); //Czech Republic
                CountryInfo[6].ChangeVote(3); //Denmark
                CountryInfo[12].ChangeVote(3); //Hungary
                CountryInfo[20].ChangeVote(3); //Poland
                CountryInfo[22].ChangeVote(3); //Romania
                CountryInfo[26].ChangeVote(3); //Sweden
            }
            void ChangeCountryRule() //Method for the user to select country rule.
            {
                int choice = 0; //Initial choice of user choice.
                while (true) //While loop to run until a valid input is given.
                {
                    Console.WriteLine("\nChoose Eurozone Countries Only [1] OR All Pariticpating Countries [2]:");
                    choice = Convert.ToInt32(Console.ReadLine()); //Prompt and input collection for user choice.
                    if (choice == 1)
                    {
                        EurozoneVote(); //Run EurozoneVote method.
                        Console.WriteLine("Now Showing Eurozone Only");
                        break;
                    }
                    else if(choice == 2)
                    {
                        //AllCountriesParticipating(); //Run AllCountriesParticipating method.
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice (Expecting Int)"); //Error message for invalid input.
                    }
                }
            }
        }
    }
}
