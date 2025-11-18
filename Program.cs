using System.Data;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; // Solución para que la consola muestre los emojis
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Random rand = new Random();
        const string MsgMenu = "===== MAIN MENU - CODEQUEST =====\r\n\r\n" +
            "1. Train your wizard\r\n" +
            "2. Increase LVL (Update)\r\n" +
            "3. Loot the mine (New!)\r\n" +
            "4. Show inventory (New!)\r\n" +
            "5. Buy items (New!)\r\n" +
            "6. Show attacks by LVL (New!)\r\n" +
            "7. Decode ancient Scroll (New!)\r\n" +
            "0. Exit game\r\n" +
            "Choose an option (1-7) - (0) to exit:";
        const string MsgMenuName = "===== MAIN MENU - CODEQUEST =====\r\n" +
            "===== Welcome, {0} the {1} with level {2} =====\r\n" +
            "1. Train your wizard\r\n" +
            "2. Increase LVL (Update)\r\n" +
            "3. Loot the mine (New!)\r\n" +
            "4. Show inventory (New!)\r\n" +
            "5. Buy items (New!)\r\n" +
            "6. Show attacks by LVL (New!)\r\n" +
            "7. Decode ancient Scroll (New!)\r\n" +
            "0. Exit game\r\n" +
            "Choose an option (1-7) - (0) to exit:";
        const string MsgDays = "day {0} -> {1}, ja has meditat {2} hores i el teu poder ara és de {3} punts.";
        const string MsgLvlOne = "Repeteixes a segona convocatoria.";
        const string MsgLvlTwo = "Encara confons la vara amb una cullera.";
        const string MsgLvlThree = "Ets un invocador de brises màgiques.";
        const string MsgLvlFour = "Uau! Pots invocar dracs sense cremar el laboratori!";
        const string MsgLvlFive = "Has assolit el rang de Mestre dels Arcans!";
        const string TitleOne = "Raoden el Elantrí";
        const string TitleTwo = "Zyn el buguejat";
        const string TitleThree = "Arka Nullpointer";
        const string TitleFour = "Elarion de les Brases";
        const string TitleFive = "ITB-Wizard el Gris";
        const string MsgInput = "Hi! Input your wizard's name: ";
        const string MonsterSkeleton = "Wandering Skeleton 💀";
        const string MonsterForestGoblin = "Forest Goblin 👹";
        const string MonsterGreenSlime = "Green Slime 🟢";
        const string MonsterEmberWolf = "Ember Wolf 🐺";
        const string MonsterGiantSpider = "Giant Spider 🕷️";
        const string MonsterIronGolem = "Iron Golem 🤖";
        const string MonsterLostNecromancer = "Lost Necromancer 🧝‍♂️";
        const string MonsterAncientDragon = "Ancient Dragon 🐉";
        const string MonsterAppearance = "A wild {0} appears! Rolling dice to determine the outcome of the battle...";
        const string MonsterHP = "The {0} has {1} HP.";
        const string DiceRoll = "You rolled a {0}!";
        const string MonsterDefeated = "The {0} has been defeated.";
        const string LvlUp = "You've leveled up! You're now level {0}.";
        const string KeyToContinue = "Press any key to roll the dice again...";
        const string TrainingComplete = "Training complete! {0} has achieved a total power of {1} points and earned the title '{2}'";
        const string MsgInvalidOption = "Invalid option. Try again!";
        const string MsgProgramEnd = "Ending program.";
        const string DiceOne = "   ________\r\n  /       /|   \r\n /_______/ |\r\n |       | |\r\n |   o   | /\r\n |       |/ \r\n '-------'\r\n";

        const int WanderSkeletonHP = 3, ForestGoblinHP = 5, GreenSlimeHP = 10, EmberWolfHP = 11,
            GiantSpiderHP = 18, IronGolemHP = 15, LostNecromancerHP = 20, AncientDragonHP = 50;

        Console.WriteLine(MsgInput);
        int poder = 1, randomHours, menu, dice, totalHours = 0, wizardLevel = 1, randomMonster;
        
        
        bool end = false, isMenu;

        
        int[] healthpoints = { WanderSkeletonHP, ForestGoblinHP, GreenSlimeHP, EmberWolfHP,
        GiantSpiderHP, IronGolemHP, LostNecromancerHP, AncientDragonHP};


        string wizardName = Console.ReadLine(), wizardTitle = TitleOne;


        string[] monsters = {MonsterSkeleton, MonsterForestGoblin, MonsterGreenSlime, MonsterEmberWolf,
        MonsterGiantSpider, MonsterIronGolem, MonsterLostNecromancer, MonsterAncientDragon};


        wizardName = wizardName.Substring(0, 1).ToUpper() + wizardName.Substring(1, wizardName.Length - 1).ToLower(); // Capitalitza correctament el nom, s'escrigui com s'escrigui
        while (!end)
        {
            if (wizardName != "")
            {
                Console.WriteLine(MsgMenuName, wizardName, wizardTitle, wizardLevel);
            }
            else Console.WriteLine(MsgMenu);

            isMenu = Int32.TryParse(Console.ReadLine(), out menu);

            if (isMenu && menu < 8)
            {

                switch (menu)
                {
                    case 1:
                        for (int day = 1; day <= 5; day++)
                        {
                            randomHours = rand.Next(0, 25);
                            poder += rand.Next(1, 11);
                            totalHours += randomHours;
                            Console.Write(MsgDays, day, wizardName, totalHours, poder);
                            Console.WriteLine();
                        }
                        if (poder < 20)
                        {
                            Console.WriteLine(MsgLvlOne);
                            wizardTitle = TitleOne;
                        }
                        else if (poder >= 20 && poder < 30)
                        {
                            Console.WriteLine(MsgLvlTwo);
                            wizardTitle = TitleTwo;
                        }
                        else if (poder >= 30 && poder < 35)
                        {
                            Console.WriteLine(MsgLvlThree);
                            wizardTitle = TitleThree;
                        }
                        else if (poder >= 35 && poder < 40)
                        {
                            Console.WriteLine(MsgLvlFour);
                            wizardTitle = TitleFour;
                        }
                        else if (poder >= 40)
                        {
                            Console.WriteLine(MsgLvlFive);
                            wizardTitle = TitleFive;
                        }
                        Console.WriteLine(TrainingComplete, wizardName, poder, wizardTitle);
                        break;


                    case 2:
                        randomMonster = rand.Next(0, monsters.Length);
                        int tempHP = healthpoints[randomMonster];

                        Console.WriteLine(MonsterAppearance, monsters[randomMonster]);

                        while (healthpoints[randomMonster] > 0)
                        {
                            Console.WriteLine(MonsterHP, monsters[randomMonster], healthpoints[randomMonster]);
                            dice = rand.Next(1, 7);

                            Console.WriteLine(DiceRoll, dice);
                            healthpoints[randomMonster] -= dice;

                            if (healthpoints[randomMonster] > 0)
                            {
                                Console.WriteLine(MonsterHP, monsters[randomMonster], healthpoints[randomMonster]);
                                Console.WriteLine(KeyToContinue);
                                Console.ReadKey();
                            }

                            else if (healthpoints[randomMonster] <= 0) {
                                Console.WriteLine(MonsterDefeated, monsters[randomMonster]);
                                wizardLevel++;
                                Console.WriteLine(LvlUp, wizardLevel);
                            }
                        }

                        healthpoints[randomMonster] = tempHP; // Variables to restore enemy's HP once it is defeated, so that if the player faces it again, it won't be at 0 HP.
                        
                        break;


                    case 3:

                        break;


                    case 4:

                        break;


                    case 5:

                        break;


                    case 6:

                        break;


                    case 7:

                        break;


                    case 0:
                        end = true;
                        Console.WriteLine(MsgProgramEnd);
                        break;
                }
            }
            else Console.WriteLine(MsgInvalidOption);
        }
    }
}