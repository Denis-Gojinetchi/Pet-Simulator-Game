using System;
using System.IO;
using System.Text.Json;


namespace Pet_Simulator_Game
{

    class Program
    {
        static void Main(string[] args)
        {
            FoodType foodType;
            InteractionType interactionType;
            Console.WriteLine("Welcome to Pet Simulator Game!");

            Dictionary<string, pets> petList;
            if (File.Exists("petList.json"))
            {
                string load = File.ReadAllText("petList.json");
                petList = JsonSerializer.Deserialize<Dictionary<string, pets>>(load);
            }
            else
            {
                petList = new Dictionary<string, pets>();
            }
            if (petList.ContainsKey("dog"))
            {
                var dogData = petList["dog"];
                Dog dog = new Dog(dogData.Name, dogData.hungerLevel, dogData.happinessLevel, dogData.maxHunger, dogData.maxHappiness);
                petList["dog"] = dog;
            }
            if (petList.ContainsKey("cat"))
            {
                var catData = petList["cat"];
                Cat cat = new Cat(catData.Name, catData.hungerLevel, catData.happinessLevel, catData.maxHunger, catData.maxHappiness);
                petList["cat"] = cat;
            }
            if (petList.ContainsKey("fish"))
            {
                var fishData = petList["fish"];
                Fish fish = new Fish(fishData.Name, fishData.hungerLevel, fishData.happinessLevel, fishData.maxHunger, fishData.maxHappiness);
                petList["fish"] = fish;
            }
            if (petList.ContainsKey("plant"))
            {
                var plantData = petList["plant"];
                Plant plant = new Plant(plantData.Name, plantData.hungerLevel, plantData.happinessLevel, plantData.maxHunger, plantData.maxHappiness);
                petList["plant"] = plant;
            }

            store store = new store(petList);
            while (true)
            {
                Console.WriteLine("\nWould you like to: \n- Visit pet store \n- Check collection \n- quit");
                string action = Console.ReadLine().Trim().ToLower();
                if (action == "visit pet store")
                {
                    while (true)
                    {
                        Console.WriteLine("\nWhat would you like to do in store? \n -List pets \n -Buy pet \n -Back");
                        action = Console.ReadLine().Trim().ToLower();
                        if (action == "back")
                        {
                            break;
                        }
                        if (action == "list pets")
                        {
                            store.DisplayPets();
                        }
                        else if (action == "buy pet")
                        {
                            Console.WriteLine("\nWhat pet would you like to buy?");
                            string petType = Console.ReadLine().Trim().ToLower();
                            Console.WriteLine("\nGive a name to your pet");
                            string name = Console.ReadLine().Trim();
                            if (petList.ContainsKey(petType))
                            {
                                Console.WriteLine("You already own this pet");
                            }
                            else
                            {
                                if (petType == "dog")
                                {
                                    store.aquirePet(petType, name);
                                }
                                else if (petType == "cat")
                                {
                                    store.aquirePet(petType, name);
                                }
                                else if (petType == "fish")
                                {
                                    store.aquirePet(petType, name);
                                }
                                else if (petType == "plant")
                                {
                                    store.aquirePet(petType, name);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nCurrent action is not allowed");
                        }
                    }
                }
                else if (action == "check collection")
                {
                    if (petList.Count < 1)
                    {
                        Console.WriteLine("\nYou dont have any pets in the collection!");
                    }
                    else
                    {
                        Console.WriteLine("\nHere is the list of avalable pets in your collection:\n");
                        foreach (KeyValuePair<string, pets> entry in petList)
                        {
                            Console.WriteLine("Pet type: " + entry.Key);
                        }
                        Console.WriteLine("\nPlease pick one with who you would like to interact:");

                        string petName = Console.ReadLine().Trim().ToLower();
                        if (petName == "quit")
                        {
                            break;
                        }
                        else if (!petList.ContainsKey(petName))
                        {
                            Console.WriteLine("\nInvalid pet type, please try again.");
                        }
                        else
                        {
                            pets selectedPet = petList[petName];
                            Console.WriteLine($"You have selected {selectedPet.Name}.");

                            while (true)
                            {
                                Console.WriteLine("\nPlease enter the action you would like to perform, or enter 'back' to select a different pet.");
                                Console.WriteLine("\n- Feed \n- Interact \n- Check status \n- Remove pet \n- Back");

                                string input = Console.ReadLine().Trim().ToLower();
                                if (input == "back")
                                {
                                    break;
                                }
                                else if (input == "feed")
                                {
                                    Console.WriteLine("\nHere are the available foods: \n- Bacon Snack \n- Dry Dog Food \n- Tuna \n- Dry Cat Food \n- Water \n- Plant Food \n- Fish Food");
                                    Console.WriteLine("\nPlease enter the name of the food you would like to feed your pet.");

                                    string foodInput = Console.ReadLine().Trim().ToLower();
                                    if (!Enum.IsDefined(typeof(FoodType), foodInput.Replace(" ", "")))
                                    {
                                        Console.WriteLine("Invalid food name, please try again.");
                                    }
                                    else
                                    {
                                        foodType = (FoodType)Enum.Parse(typeof(FoodType), foodInput.Replace(" ", ""));
                                        selectedPet.Feed(foodType);
                                        Console.WriteLine($"{selectedPet.Name} has been fed {foodInput}.");
                                    }
                                }
                                else if (input == "interact")
                                {
                                    Console.WriteLine("Here are the available actions:");
                                    Console.WriteLine("\n- Pet \n- Rub Belly \n- Play \n- Ignore \n- Scold \n- Play Music \n- Talk \n- Tap on Glass ");
                                    Console.WriteLine("\nPlease enter the name of the action you would like to perform.");
                                    if (selectedPet.happinessLevel > 0)
                                    {
                                        string actionInput = Console.ReadLine().Trim().ToLower();

                                        if (!Enum.IsDefined(typeof(InteractionType), actionInput.Replace(" ", "")))
                                        {
                                            Console.WriteLine("\nInvalid action name, please try again.");
                                        }
                                        else
                                        {
                                            interactionType = (InteractionType)Enum.Parse(typeof(InteractionType), actionInput.Replace(" ", ""));
                                            selectedPet.Interact(interactionType);
                                            Console.WriteLine($"You performed {actionInput} to {selectedPet.Name}.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nPet is unhappy and doesn't want to interact, please feed your pet!");
                                    }
                                }
                                else if (input == "check status")
                                {
                                    Console.WriteLine($"Name: {selectedPet.Name}");
                                    Console.WriteLine($"Hunger Level: {selectedPet.hungerLevel}");
                                    Console.WriteLine($"Happiness Level: {selectedPet.happinessLevel}");
                                }
                                else if (input == "remove pet")
                                {
                                    Console.WriteLine("\nHere is the list of pets in your collection, \nWho would you like to remove?\n");
                                    foreach (KeyValuePair<string, pets> entry in petList)
                                    {
                                        Console.WriteLine("Pet type: " + entry.Value.GetType().Name);
                                    }
                                    string removePet = Console.ReadLine().Trim().ToLower();

                                    petList.Remove(removePet);
                                    Console.WriteLine($"Pet has been removed from your collection");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("\nInvalid input, please try again.");
                                }
                            }
                        }
                    }
                }
                else if (action == "quit")
                {
                    break;
                }
            }
            string save = JsonSerializer.Serialize(petList);
            File.WriteAllText("petList.json", save);
        }
    }
}
