using System;
using System.Collections.Generic;

namespace TextBasedGame
{
    class Program
    {
        static void Main(string[] args)
        {
            
            startText();
            while (Global.isRunning)
            {
                try
                {

                    bool isDead1 = showQuestionLevel1(0);
                    bool isDead2 = showQuestionLevel1(1);
                    bool isDead3 = showQuestionLevel1(2);
                    bool isDead4 = showQuestionLevel1(3);
                    if (isDead1 || isDead2 || isDead3 || isDead4)
                    {
                        if (controllAnswer())
                        {
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    string baba = babaQuestion(true);
                    if (baba == "hint")
                    {
                        Console.WriteLine("first letters");
                        baba = babaQuestion(false);
                    }
                    if (baba != "baba" && baba != "BABA")
                    {
                        if (controllAnswer())
                        {
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (baba == "hint")
                    {
                        Console.WriteLine("Hint: first letters");
                    }
                    bool isDead5 = showQuestionLevel1(4);
                    if (isDead5)
                    {
                        if (controllAnswer())
                        {
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("Hey You, you completed the first level of the BABA games. There are no alternatives on this level");


                    Console.WriteLine("What do you do in the following senarios?");
                    string answer1 = showLevel2Question("You are out there in the cold: ");
                    string answer2 = showLevel2Question("You are out there on your own: ");
                    string answer3 = showLevel2Question("You are out there on the road: ");
                    Console.WriteLine();
                    if (answer1 != "Getting lonely, getting old" || answer2 != "Sitting naked by the phone" || answer3 != "Always doing what you're told")
                    {
                        if (controllAnswer())
                        {
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    Console.WriteLine("You can concider yourself somewhat of a genius as you have arrivded at the last lavel of the BABA games");
                    Console.WriteLine("You will be given different options and you will try to find the correct path to your victory");

                    while (Global.isRunningLevel3)
                    {
                        showLevel3Question(0);
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            static void startText()
            {
                Console.WriteLine("Welcome to the BABA games.");
                Console.WriteLine("Here you will try to survive the BABA games by answering the rigth answer, purhaps. This is the ultimate test to see if you got some kind of intelligence");
                Console.WriteLine();
                Console.WriteLine("In the first part of the games you will be faced with a small quiz");
                Console.WriteLine();
                Console.Write("Press any key to continue");
                Console.ReadKey();
                Console.WriteLine();
            }

            static bool showQuestionLevel1(int index)
            {
                string[] questions = { "What is heavier, a pound of steel or a pound of fethers: ", "I read the news today, oh boy...: ", "The year is 1984. Who is watching you?: ", "Who wrote \"Murder on the Orient Express\": ", "You arrive at [59.3434615663417, 18.055658540702535], where are you: " };
                int[] correctAnswer = { 3, 1, 1, 3, 2 };
                List<List<string>> alternatives = new List<List<string>>()
                { new List<string>() { "steel", "fethers", "both" },
                  new List<string>() {       "About a lucky man who made the grade",
                    "The English Army had just won the war",
                    "Four thousand holes in Blackburn, Lancashire" },
                  new List<string>()  { "Big Brother", "Michael Jackson", "Richard Nixon" },
                  new List<string>()  { "Da Baby", "Margert Wtwood", "Agatha Chriti" },
                  new List<string>()  { "Eiffel Tower", "Falafel Kungen", "Huston" },};
                while(true)
                {
                    try
                    {
                        Console.WriteLine(questions[index]);
                        showAlternatives(alternatives[index]);
                        int answer = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        return !(correctAnswer[index] == answer);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            static void showAlternatives(List<string> alternatives)
            {
                for (int i = 0; i < alternatives.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] {alternatives[i]}: ");
                }
                Console.Write("answer: ");
            }

            static bool controllAnswer()
            {
                Console.WriteLine();
                Console.WriteLine("*You Died*");
                Console.WriteLine();
                Console.Write("Do you want to try again (y/n): ");
                string answer = Console.ReadLine();
                if (answer == "y" || answer == "Y")
                {
                    Console.WriteLine();
                    Console.Write("Ok, here comes another try");
                    Console.WriteLine();
                    return false;

                }
                else if (answer == "n" || answer == "N")
                {
                    Console.WriteLine();
                    Console.Write("Ok loser");
                    Console.WriteLine();
                    return true;
                }
                else
                {
                    Console.WriteLine();
                    Console.Write($"What the fuck is {answer}. You automatically lose");
                    Console.WriteLine();
                    return true;
                }
            }

            static string babaQuestion(bool isFirstTime)
            {
                if (isFirstTime)
                {
                    Console.Write("What word does your answers form (wirght \"hint\" if you need a hint): ");
                }
                else
                {
                    Console.Write("What word does your answers form: ");
                }
                return Console.ReadLine();
            }

            static string showLevel2Question(string question)
            {
                Console.WriteLine();
                Console.Write(question);
                return Console.ReadLine();
            }

            static void showLevel3Question(int index)
            {
                int death = 100;
                string[,] alternatives = {
                    { "go in","stay outside"},
                    { "pick them up",  "ignore them"},
                    { "die", "take it like a champ"},
                    { "kick it in the balls" , "run"},
                    { "make some pizza" , "go inside of the house"},
                    { "eat them" , "throw them away in the trash"},
                    { "go to the mall" , "eat your own leg"},
                    { "keep it and go back to the house", "just go back to the house"},
                    { "go left" , "rigth"},
                    { "keep it", "throw it away"},
                    { "keep it", "throw it away"},
                    { "read it", "ignore it"},
                    { "eat it", "ignore it"},
                    { "go to the corridor", "the right room"},
                    { "go to the corridor", "the left room"},
                    { "turn it around", "countinue down stairs"},
                    { "keep it", "go down stairs"},
                    { "go to the mall", "upstairs"},

                };
                string endQuestion = $" Do you {alternatives[index, 0]} or {alternatives[index, 1]}? ";
                string[] questions = { 
                $"You find yourself infront of an house.{endQuestion}",
                $"Once you step inside you see two dead people.{endQuestion}",
                $"You get bored styaying outside so you start doing backflips and land on your neck.{endQuestion}",
                $"Your neck hearts a bit but everything is still fine. Until a zebra comes running at you in full speed.{endQuestion}",
                $"The zebra starts screaming.{endQuestion}",
                $"They are really heavy and you can not carry them anymore.{endQuestion}",
                $"They tasted really good and you want to find more people to eat.{endQuestion}",
                $"You arrive at the mall where you don't find any people, but a little note on the ground saying {note()}.{endQuestion}",
                $"You pass by a corridor where there are two rooms. One to the left and one on the right.{endQuestion}",
                $"in the left room you find a note saying {note()}.{endQuestion}",
                $"in the right room you find a note saying {note()}.{endQuestion}",
                $"in the room you find a book called \"6 Ways To Find The Key\".{endQuestion}",
                $"in the room you find left behind pizza.{endQuestion}",
                $"The left room became quite boring suddenly.{endQuestion}",
                $"The right room became quite boring suddenly.{endQuestion}",
                $"You go further down the corridor and find a mouse trap infront of a pair of stairs going to the basement.{endQuestion}",
                $"On the backside of the mouse trap it says {note()}.{endQuestion}",
                $"in the basement you find nothing but a car tire that has to be retruned to the mall.{endQuestion}",
                };
                int[,] nextIndex = { 
                    {1, 2},
                    {5, 8},
                    {death, 3},
                    {4, death},
                    {death, 1},
                    {6, death},
                    {7, death},
                    {8, 8},
                    {9, 10},
                    {11, 11},
                    {12, 12},
                    {death, 13},
                    {death, 14},
                    {15, 10},
                    {15, 9},
                    {16, 17},
                    {17, 17},
                    {7, 8},
                };
                string[] deathMessage = { 
                    "",
                    "",
                    "Well",
                    "You start running so fast your hair ripps out of your scull, and you eventually dies",
                    "You realize there is no oven around and you start to cry and get deppresed and kill yourself ",
                    "In the trash can you find a ton of radioactive material. You get cancer and die immediately",
                    "Not a good choice. You empty all your blood within minutes and you die",
                    "",
                    "",
                    "",
                    "",
                    "You start reading and realize the auther is talking about the kays to death. You realize it abou the same instance as a massive tarantella jump up in your face",
                    "Ooopsie, wrong mushrooms. They start taking you on a trip. Infact the intire way to deaths",
                    "",
                    "",
                    "",
                    "",
                    "",
                };
                string note()
                {
                    switch (Global.notes)
                    {
                        case 0:
                            return "\"b * * *\"";
                        case 1:
                            return "\"* a * *\"";
                        case 2:
                            return "\"* * b *\"";
                        case 3:
                            return "\"* * * a\"";
                        default:
                            return "\"* * * *\"";
                    }
                }
                while (true)
                {
                    try
                    {

                        if(Global.notes == 4)
                        {
                            Console.WriteLine("Take a look at your notes and see what word they form");
                            Console.Write("Enter the word to win the BABA games: ");
                            if(Console.ReadLine() == "baba")
                            {
                                Console.WriteLine("Congrats, you won, woohoo");
                                Global.isRunning = false;
                                Global.isRunningLevel3 = false;
                                break;
                            } 
                            else
                            {
                                if (controllAnswer())
                                {
                                   
                                    Global.isRunning = false;
                                    Global.isRunningLevel3 = false;
                                    break;
                                }
                                else
                                {
                                    Global.notes = 0;
                                    break;
                                }
                            }
                        }
                        Console.WriteLine();
                        Console.Write(questions[index]);
                        string input = Console.ReadLine();
                        if ((input == alternatives[index, 0] && nextIndex[index, 0] == death) || (input == alternatives[index, 1] && nextIndex[index, 1] == death))
                        {
                            Console.WriteLine(deathMessage[index]);
                            if (controllAnswer())
                            {
                                Global.isRunning = false;
                                Global.isRunningLevel3 = false;
                                break;
                            }
                            else
                            {
                                Global.notes = 0;
                                break;
                            }
                        }
                        else
                        {
                            if(input.Contains("keep it"))
                            {
                                Global.notes++;
                            }
                            if (input == alternatives[index, 0])
                            {
                                showLevel3Question(nextIndex[index, 0]);
                                break;
                            }
                            else if (input == alternatives[index, 1])
                            {
                                showLevel3Question(nextIndex[index, 1]);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("You gave an invalid input, please reenter your answer");
                            }
                        }

                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
    }

    class Global
    {
        public static bool isRunning = true;
        public static bool isRunningLevel1 = true;
        public static bool isRunningLevel2 = true;
        public static bool isRunningLevel3 = true;
        public static int notes = 0;
    }
}
