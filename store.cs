using System;



namespace Pet_Simulator_Game
{
    public class store
    {
        private Dictionary<string, pets> petList;
        private Dictionary<string, Dictionary<string, object>> petList1;

        public store(Dictionary<string, pets> petList)
        {
            this.petList = petList;
        }

        public store(Dictionary<string, Dictionary<string, object>> petList1)
        {
            this.petList1 = petList1;
        }

        public void DisplayPets()
        {
            Console.WriteLine("Available pets for purchasing: \n - Dog \n - Cat \n - Fish \n - Plant");
        }

        public void aquirePet(string pet, string petName)
        {
            if (pet == "dog")
            {
                petList.Add(pet, new Dog(petName, 2, 5, 10, 10));

            }
            else if (pet == "cat")
            {
                petList.Add(pet, new Cat(petName, 2, 4, 8, 5));
            }
            else if (pet == "fish")
            {
                petList.Add(pet, new Fish(petName,2, 2, 5, 5));
            }
            else if (pet == "plant")
            {
                petList.Add(pet, new Plant(petName, 5, 2, 6, 5));
            }
            else
            {
                Console.WriteLine("Required pet is not available for purchesing, please pick one from the existing list: /n Dog, /n Cat /n Fish /n Plant");
            }
        }
    }

}
