﻿using System;
using System.IO;

namespace Console_Imp
{
    class Program
    {
        static Functions FunctionsCall = new Functions();
        static void Main(string[] args)
        {
            Country[] CountryInfo = new Country[27];

            string Path = Directory.GetCurrentDirectory();
            string Text = File.ReadAllText(Path.Substring(0, Path.Length - 23) + "CountriesInfo.txt");

            string[] CountriesText = Text.Split('\n');

            for(int i = 0; i < CountriesText.Length; i++)
            {
                string[] infoarray = CountriesText[i].Split(' ');
                CountryInfo[i] = new Country();
                CountryInfo[i].Name = infoarray[0];
                CountryInfo[i].Population = Convert.ToInt32(infoarray[1]);
            }
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
            string DisplayVotes()
            {
                string Output = "\n";
                Output += "Country".PadRight(15) + "Population".PadRight(12) + "Vote\n\n";
                foreach (Country info in CountryInfo)
                {
                    Output += info.Name.PadRight(15) + String.Format("{0:n0}", info.Population).PadRight(12) + info.GetVoteString() + "\n";
                }
                return Output;
            }
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
                foreach (Country info in CountryInfo)
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
                float VotePercent = (float) ForVote / TotalVote;
                float PopPercent = (float) ForPop / TotalPop;

                Console.WriteLine("Vote:  For:" + ForVote + " Against:" + AgainstVote + " Abstain:" + AbstainVote + " Percent:" + Math.Round(VotePercent * 100, 2));
                Console.WriteLine("Population:  For:" + String.Format("{0:n0}", ForPop) + " Against:" + String.Format("{0:n0}", AgainstPop) + " Abstain:" + String.Format("{0:n0}", AbstainPop) + " Percent:" + Math.Round(PopPercent * 100, 2));

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
            void ChangeSingleVote()
            {
                for(int i = 0; i < CountryInfo.Length; i++)
                {
                    Console.WriteLine((i+1) + ":" + CountryInfo[i].Name + ":" + CountryInfo[i].GetVoteString());
                }
                int Value = 0;
                while (true)
                {
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
