using System;
using System.Timers;
using Timer = System.Timers.Timer;


namespace Pet_Simulator_Game
{
    public enum FoodType
    {
        baconsnack,
        drydogfood,
        tuna,
        drycatfood,
        water,
        plantfood,
        fishfood
    }
    public enum InteractionType
    {
        pet,
        rubbelly,
        play,
        ignore,
        scold,
        playmusic,
        talk,
        taponglass
    }

    public class pets
    {
        public string Name { get; set; }
        public int hungerLevel { get; set; }
        public int happinessLevel { get; set; }
        public int maxHunger { get; set; }
        public int maxHappiness { get; set; }

        public pets (string name, int hungerLevel, int happinessLevel, int maxHunger, int maxHappiness)
        {
            Name = name;
            this.hungerLevel = hungerLevel;
            this.happinessLevel = happinessLevel;
            this.maxHappiness = maxHappiness;
            this.maxHunger = maxHunger;
        }
        public virtual void Feed(FoodType food)
        {

        }

        public virtual void Interact(InteractionType action)
        {

        }

        public virtual void updateState()
        {

        }

        public static implicit operator Dictionary<object, object>(pets v)
        {
            throw new NotImplementedException();
        }
    }

    public class Dog : pets
    {
        private Timer timer;
        public Dog(string name, int hungerLevel, int happinessLevel, int maxHunger, int maxHappiness)
                                    : base(name, hungerLevel, happinessLevel, maxHunger, maxHappiness)
        {
            Name = name;
            this.hungerLevel = hungerLevel;
            this.happinessLevel = happinessLevel;
            this.maxHappiness = maxHappiness;
            this.maxHunger = maxHunger;

            timer = new Timer(120000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public override void Feed(FoodType food)
        {
            if (food == FoodType.baconsnack)
            {
                hungerLevel /= 2;
                happinessLevel += 1;
            }
            else if (food == FoodType.drydogfood)
            {
                hungerLevel = 0;
                happinessLevel += 1;
            }
            else
            {
                hungerLevel += 2;
                happinessLevel -= 2;
            }
            if (hungerLevel >= maxHunger)
            {
                happinessLevel = 0;
            }
            happinessLevel = Math.Max(happinessLevel, 0);
            hungerLevel = Math.Min(hungerLevel, maxHunger);
        }

        public override void Interact(InteractionType action)
        {
            if (action == InteractionType.rubbelly)
            {
                hungerLevel += 1;
                happinessLevel += 1;
            }
            else if (action == InteractionType.play)
            {
                hungerLevel += 3;
                happinessLevel += 2;
            }
            else if (action == InteractionType.scold)
            {
                hungerLevel += 2;
                happinessLevel -= 2;
            }
            else
            {
                hungerLevel += 2;
                happinessLevel -= 2;
            }

            if (hungerLevel >= maxHunger)
            {
                happinessLevel = 0;
            }
            happinessLevel = Math.Max(happinessLevel, 0);
            hungerLevel = Math.Min(hungerLevel, maxHunger);
        }

        public void OnTimedEvent(object Source, ElapsedEventArgs e)
        {
            updateState();
        }

        public override void updateState()
        {
            hungerLevel += 1;
            happinessLevel -= 1;

            if (hungerLevel > maxHunger)
            {
                happinessLevel = 0;
            }
            if (happinessLevel < 0)
            {
                happinessLevel = 0;
            }
            happinessLevel = Math.Max(happinessLevel, 0);
            hungerLevel = Math.Min(hungerLevel, maxHunger);
        }

        public void StopTimer()
        {
            timer.Stop();
        }
    }
    public class Fish : pets
    {
        private Timer timer;

        public Fish(string name, int hungerLevel, int happinessLevel, int maxHunger, int maxHappiness)
                                    : base(name, hungerLevel, happinessLevel, maxHunger, maxHappiness)
        {
            Name = name;
            this.hungerLevel = hungerLevel;
            this.happinessLevel = happinessLevel;
            this.maxHappiness = maxHappiness;
            this.maxHunger = maxHunger;

            timer = new Timer(180000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public override void Feed(FoodType food)
        {
            if (food == FoodType.fishfood)
            {
                hungerLevel = 0;
                happinessLevel += 1;
            }

            else
            {
                happinessLevel -= 2;
                hungerLevel += 2;
            }
            if (hungerLevel >= maxHunger)
            {
                happinessLevel = 0;
            }
            happinessLevel = Math.Max(happinessLevel, 0);
            hungerLevel = Math.Min(hungerLevel, maxHunger);
        }

        public override void Interact(InteractionType action)
        {
            if (action == InteractionType.playmusic)
            {
                hungerLevel += 1;
                happinessLevel += 1;
            }
            else if (action == InteractionType.talk)
            {
                hungerLevel += 1;
                happinessLevel += 1;
            }
            else if (action == InteractionType.taponglass)
            {
                hungerLevel += 3;
                happinessLevel -= 2;
            }
            else
            {
                hungerLevel += 2;
                happinessLevel -= 2;
            }

            if (hungerLevel >= maxHunger)
            {
                happinessLevel = 0;
            }
            happinessLevel = Math.Max(happinessLevel, 0);
            hungerLevel = Math.Min(hungerLevel, maxHunger);
        }

        public void OnTimedEvent(object Source, ElapsedEventArgs e)
        {
            updateState();
        }

        public override void updateState()
        {
            hungerLevel += 1;
            happinessLevel -= 1;

            if (hungerLevel >= maxHunger)
            {
                happinessLevel = 0;
                hungerLevel = maxHunger;
            }
            happinessLevel = Math.Max(happinessLevel, 0);
            hungerLevel = Math.Min(hungerLevel, maxHunger);
        }

        public void StopTimer()
        {
            timer.Stop();
        }
    }
    public class Cat : pets
    {
        private Timer timer;

        public Cat(string name, int hungerLevel, int happinessLevel, int maxHunger, int maxHappiness)
                                    : base(name, hungerLevel, happinessLevel, maxHunger, maxHappiness)
        {
            Name = name;
            this.hungerLevel = hungerLevel;
            this.happinessLevel = happinessLevel;
            this.maxHappiness = maxHappiness;
            this.maxHunger = maxHunger;

            timer = new Timer(120000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public override void Feed(FoodType food)
        {
            if (food == FoodType.tuna)
            {
                hungerLevel = 0;
                happinessLevel += 3;
            }
            else if (food == FoodType.drycatfood)
            {
                hungerLevel /= 2;
                happinessLevel += 1;
            }
            else
            {
                happinessLevel -= 2;
                hungerLevel += 2;
            }
            if (hungerLevel >= maxHunger)
            {
                happinessLevel = 0;
                hungerLevel = maxHunger;
            }
            happinessLevel = Math.Max(happinessLevel, 0);
            hungerLevel = Math.Min(hungerLevel, maxHunger);
        }

        public override void Interact(InteractionType action)
        {
            if (action == InteractionType.ignore)
            {
                hungerLevel += 1;
                happinessLevel += 2;
            }
            else if (action == InteractionType.scold)
            {
                hungerLevel += 2;
                happinessLevel -= 2;
            }
            else if (action == InteractionType.pet)
            {
                Random rnd = new Random();
                int num = rnd.Next(-10, 10);
                if (num > 0)
                {
                    hungerLevel += 1;
                    happinessLevel += 1;
                }
                else
                {
                    happinessLevel -= 2;
                    hungerLevel += 2;
                }
            }
            else
            {
                happinessLevel -= 2;
                hungerLevel += 2;
            }
            happinessLevel = Math.Max(happinessLevel, 0);
            hungerLevel = Math.Min(hungerLevel, maxHunger);
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            updateState();
        }

        public void timerStop()
        {
            timer.Stop();
        }

        public override void updateState()
        {
            hungerLevel += 1;
            happinessLevel -= 1;

            if (hungerLevel >= maxHunger)
            {
                happinessLevel = 0;
            }
            happinessLevel = Math.Max(happinessLevel, 0);
            hungerLevel = Math.Min(hungerLevel, maxHunger);
        }

    }

    public class Plant : pets
    {
        private Timer timer;

        public Plant(string name, int hungerLevel, int happinessLevel, int maxHunger, int maxHappiness)
                                    : base(name, hungerLevel, happinessLevel, maxHunger, maxHappiness)
        {
            Name = name;
            this.hungerLevel = hungerLevel;
            this.happinessLevel = happinessLevel;
            this.maxHappiness = maxHappiness;
            this.maxHunger = maxHunger;

            timer = new Timer(60000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public override void Feed(FoodType food)
        {
            if (food == FoodType.water)
            {
                hungerLevel /= 2;
                happinessLevel += 1;
            }
            else if (food == FoodType.plantfood)
            {
                hungerLevel = 0;
                happinessLevel += 1;
            }
            else
            {
                happinessLevel -= 2;
                hungerLevel += 2;
                happinessLevel = Math.Max(happinessLevel, 0);
            }
            if (hungerLevel >= maxHunger)
            {
                happinessLevel = 0;
                hungerLevel = Math.Min(hungerLevel, maxHunger);
            }
        }

        public override void Interact(InteractionType action)
        {
            if (action == InteractionType.talk)
            {
                happinessLevel += 1;
                hungerLevel += 1;
            }
            else if (action == InteractionType.playmusic)
            {
                happinessLevel += 2;
                hungerLevel += 1;
            }
            else if (action == InteractionType.ignore)
            {
                happinessLevel -= 3;
                hungerLevel += 3;
            }
            else
            {
                happinessLevel -= 2;
                hungerLevel += 2;
                happinessLevel = Math.Max(happinessLevel, 0);
                hungerLevel = Math.Min(hungerLevel, maxHunger);
            }
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            updateState();
        }

        public void timerStop()
        {
            timer.Stop();
        }

        public override void updateState()
        {
            hungerLevel += 1;
            happinessLevel -= 1;

            if (hungerLevel >= maxHunger)
            {
                happinessLevel = 0;
            }
            happinessLevel = Math.Max(happinessLevel, 0);
            hungerLevel = Math.Min(hungerLevel, maxHunger);
        }
    }
}



