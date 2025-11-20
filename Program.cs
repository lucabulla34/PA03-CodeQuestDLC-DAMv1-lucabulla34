using System.Data;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; // Solución para que la consola muestre los emojis
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Random rand = new Random();
        const int ROWS = 5, COLS = 5;
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
        const string MsgInput = "Hi! Input your wizard's name: ";

        //1
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
        const string TrainingComplete = "Training complete! {0} has achieved a total power of {1} points and earned the title '{2}'";

        //2
        const string MonsterSkeleton = "Wandering Skeleton 💀";
        const string MonsterForestGoblin = "Forest Goblin 👹";
        const string MonsterGreenSlime = "Green Slime 🟢";
        const string MonsterEmberWolf = "Ember Wolf 🐺";
        const string MonsterGiantSpider = "Giant Spider 🕷️";
        const string MonsterIronGolem = "Iron Golem 🤖";
        const string MonsterLostNecromancer = "Lost Necromancer 🧝‍♂️";
        const string MonsterAncientDragon = "Ancient Dragon 🐉";
        const string MonsterAppearance = "A wild {0} appears! Rolling dice to determine the outcome of the battle...";
        const string DiceRoll = "You rolled a {0}!";
        const string MonsterHP = "The {0} has {1} HP.";
        const string MonsterDefeated = "The {0} has been defeated.";
        const string LvlUp = "You've leveled up! You're now level {0}.";

        //3
        const string KeyToContinue = "Press any key to roll the dice again...";
        const string ChooseX = "Insert the X axis: ";
        const string ChooseY = "Insert the Y axis: ";
        const string MsgCoinFound = "You mined at [{0}, {1}] and found a coin which contained {2} bits! You now have {3} attempts.";
        const string MsgNotFound = "You mined at [{0}, {1}] and didn't find anything. You now have {2} attempts.";

        //4
        const string MsgInventoryContains = "Your inventory contains:\n";
        const string MsgEmptyInventory = "Your inventory is empty.";

        //5
        const string MsgShop = "You chose to buy items. \nYou have {0} bits available.\nObjecte \t\t\t\tPreu (bits)\n";
        const string MsgSelectItem = "Select the item you wish to buy (1 - 5) (0 to exit):";
        const string MsgItemBought = "You have purchased: {0} for {1} bits. Bits remaining: {2}";
        const string MsgNotEnoughFunds = "You haven't got enough bits for this purchase.";

        //6
        const string MsgAttacks = "Available attacs for level {0}: \n";

        //7
        const string MsgAncientFound = "You found an ancient scroll with encrypted messages!";
        const string MsgScrollIntro = "Scroll to decode: ";
        const string MsgAction = "You must decode the following scroll:\r\n" +
            "Choose a decoding operation:\r\n" +
            "1. Decipher spell (remove spaces)\r\n" +
            "2. Count magical runes (vowels)\r\n" +
            "3. Extract secret code (numbers)\n";
        const string MsgDeciphered = "Deciphered spell: {0}";
        const string MsgCounted = "{0} magical runes (vowels) found";
        const string MsgExtracted = "🔮 Decoded number: {0}";
        const string MsgCongratulations = "Congratulations! You have successfully decoded all parts of the scroll.";

        //generic
        const string MsgError = "Invalid option. Try again!";
        const string MsgProgramEnd = "Ending program.";


        const int WanderSkeletonHP = 3, ForestGoblinHP = 5, GreenSlimeHP = 10, EmberWolfHP = 11,
            GiantSpiderHP = 18, IronGolemHP = 15, LostNecromancerHP = 20, AncientDragonHP = 50;



        Console.WriteLine(MsgInput);
        int poder = 1, randomHours, menu, dice, totalHours = 0, wizardLevel = 1, randomMonster, attempts = 5, yAxis, xAxis, bits,
            totalBits = 0, progress = 0, stepOne = 0, stepTwo = 0, stepThree = 0;


        bool end = false, isMenu, itemAdded = false;

        string wizardName = "Name", wizardTitle = TitleOne, vowels = "aeiouAEIOU", numbers = "1234567890";
        string scrollPartOne = "\"The 🐲 sleeps in the mountain of fire 🔥\"";
        string scrollPartTwo = "\"Ancient magic flows through the crystal caves\"";
        string scrollPartThree = "\"Spell: Ignis 5 🔥, Aqua 6 💧, Terra 3 🌍, Ventus 8 🌪️\"\n";

        int[] healthpoints = { WanderSkeletonHP, ForestGoblinHP, GreenSlimeHP, EmberWolfHP,
        GiantSpiderHP, IronGolemHP, LostNecromancerHP, AncientDragonHP}, itemsPrice = { 30, 10, 50, 40, 20 };

        bool[] itemPresent = new bool[6];


        string[] monsters = {MonsterSkeleton, MonsterForestGoblin, MonsterGreenSlime, MonsterEmberWolf,
        MonsterGiantSpider, MonsterIronGolem, MonsterLostNecromancer, MonsterAncientDragon},
        userOutput = { "➖", "🪙", "❌" },
        treasures = { "Empty", "Coin" },
        items = { "Iron Dagger 🗡️", "Healing Potion ⚗️", "Ancient Key 🗝️", "Crossbow 🏹", "Metal Shield 🛡️" },
        inventory = new string[items.Length],
        scrolls = { scrollPartOne, scrollPartTwo, scrollPartThree };
        string[][] levels = new string[5][];
        levels[0] = new string[] { "Magic Spark 💫" };
        levels[1] = new string[] { "Fireball 🔥", "Ice Ray 🥏", "Arcane Shield ⚕️" };
        levels[2] = new string[] { "Meteor ☄️", "Pure Energy Explosion 💥", "Minor Charm 🎭", "Air Strike 🍃" };
        levels[3] = new string[] { "Wave of Light ⚜️", "Storm of Wings 🐦" };
        levels[4] = new string[] { "Cataclysm 🌋", "Portal of Chaos 🌀", "Arcane Blood Pact 🩸", "Elemental Storm ⛈️" };


        wizardName = Console.ReadLine();
        wizardName = wizardName.Substring(0, 1).ToUpper() + wizardName.Substring(1, wizardName.Length - 1).ToLower(); // This will properly capitalize the message, no matter how it's written.
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
                            Console.WriteLine(TrainingComplete, wizardName, poder, wizardTitle);
                        }
                        break;


                    case 2:
                        randomMonster = rand.Next(0, monsters.Length);
                        int tempHP = healthpoints[randomMonster];

                        Console.WriteLine(MonsterAppearance, monsters[randomMonster]);
                        while (healthpoints[randomMonster] > 0)
                        {
                            dice = rand.Next(1, 7);
                            Console.WriteLine(MonsterHP, monsters[randomMonster], healthpoints[randomMonster]);


                            Console.WriteLine(DiceRoll, dice);
                            healthpoints[randomMonster] -= dice;

                            if (healthpoints[randomMonster] > 0)
                            {
                                Console.WriteLine(MonsterHP, monsters[randomMonster], healthpoints[randomMonster]);
                                Console.WriteLine(KeyToContinue);
                                Console.ReadKey();
                            }

                            else if (healthpoints[randomMonster] <= 0)
                            {
                                Console.WriteLine(MonsterDefeated, monsters[randomMonster]);
                                wizardLevel++;
                                Console.WriteLine(LvlUp, wizardLevel);
                            }
                        }

                        healthpoints[randomMonster] = tempHP; // Variables to restore enemy's HP once it is defeated, so that if the player faces it again, it won't be at 0 HP.

                        break;


                    case 3:
                        attempts = 5;
                        string[,] invisibleMap = new string[ROWS, COLS], userMap = new string[ROWS, COLS];
                        Console.WriteLine("0 1 2 3 4");
                        for (int i = 0; i < invisibleMap.GetLength(0); i++)
                        {
                            Console.Write(i);
                            for (int j = 0; j < invisibleMap.GetLength(1); j++)
                            {
                                invisibleMap[i, j] = treasures[rand.Next(0, treasures.Length)];
                                Console.Write($"{userOutput[0]} ");
                            }
                            Console.WriteLine();
                        }

                        do
                        {
                            Console.Write($"{ChooseX} \n");
                            bool isAxis = Int32.TryParse(Console.ReadLine(), out xAxis);

                            if (isAxis && xAxis < 5)
                            {
                                Console.Write($"{ChooseY} \n");
                                isAxis = Int32.TryParse(Console.ReadLine(), out yAxis);
                                if (isAxis && yAxis < 5)
                                {
                                    if (invisibleMap[xAxis, yAxis] == treasures[1])
                                    {
                                        bits = rand.Next(5, 51);
                                        totalBits += bits;
                                        userMap[xAxis, yAxis] = userOutput[1];
                                        attempts--;
                                        Console.WriteLine(MsgCoinFound, xAxis, yAxis, bits, attempts);
                                        invisibleMap[xAxis, yAxis] = treasures[0]; // This line prevents the same spot from being exploited twice.
                                    }
                                    else if (invisibleMap[xAxis, yAxis] == treasures[0])
                                    {
                                        userMap[xAxis, yAxis] = userOutput[2];
                                        attempts--;
                                        Console.WriteLine(MsgNotFound, xAxis, yAxis, attempts);
                                    }
                                    Console.WriteLine("0 1 2 3 4");
                                    for (int i = 0; i < invisibleMap.GetLength(0); i++)
                                    {
                                        Console.Write(i);
                                        for (int j = 0; j < invisibleMap.GetLength(1); j++)
                                        {
                                            if (userMap[i, j] == userOutput[1])
                                            {
                                                Console.Write($"{userOutput[1]} ");
                                            }
                                            else if (userMap[i, j] == userOutput[2])
                                            {
                                                Console.Write($"{userOutput[2]} ");
                                            }
                                            else Console.Write($"{userOutput[0]} ");
                                        }
                                        Console.WriteLine();

                                    }
                                }
                                else Console.WriteLine(MsgError);
                            }
                            else Console.WriteLine(MsgError);
                        } while (attempts > 0);

                        //easter egg [6,7]????
                        break;


                    case 4:
                        Console.Write(MsgInventoryContains);

                        if (inventory[0] == null)
                        {
                            Console.WriteLine(MsgEmptyInventory);
                        }
                        else
                        {
                            for (int i = 0; i < inventory.Length; i++)
                            {
                                Console.WriteLine($"{inventory[i]}"); //Adds the items bought in the shop to current inventory.
                            }
                        }
                        break;


                    case 5:
                        int itemBought;
                        bool isValid;
                        itemAdded = false;
                        Console.WriteLine(MsgShop, totalBits);
                        for (int i = 0; i < items.Length; i++)
                        {
                            Console.Write($"{items[i]}     \t\t\t\t{itemsPrice[i]}\n");
                        }
                        Console.WriteLine(MsgSelectItem);
                        isValid = Int32.TryParse(Console.ReadLine(), out itemBought);
                        if (isValid && itemBought < 6)
                        {
                            if (totalBits - itemsPrice[itemBought - 1] >= 0) // User can buy the item
                            {
                                totalBits = totalBits - itemsPrice[itemBought - 1];
                                Console.WriteLine(MsgItemBought, items[itemBought - 1], itemsPrice[itemBought - 1], totalBits);
                                for (int i = 0; (i < inventory.Length) && !itemAdded; i++)
                                {
                                    if (!itemPresent[i])
                                    {
                                        itemPresent[i] = true;
                                        inventory[i] = items[itemBought - 1];
                                        itemAdded = true;
                                    }
                                }
                            }
                            else Console.WriteLine(MsgNotEnoughFunds);
                        }
                        if (!isValid)
                        {
                            Console.WriteLine(MsgError);
                        }
                        break;


                    case 6:

                        int maxLevelIndex = levels.Length - 1;
                        int targetIndex = wizardLevel - 1;

                        if (targetIndex > maxLevelIndex)
                        {
                            targetIndex = maxLevelIndex;
                        }
                        Console.Write(MsgAttacks, targetIndex + 1);

                        for (int i = 0; i < levels[targetIndex].Length; i++)
                        {
                            Console.Write($"- {levels[targetIndex][i]}\n");
                        }
                        break;


                    case 7:
                        int action, counter = 0;
                        bool isAction;
                        Console.WriteLine(MsgAncientFound);
                        Console.Write($"{scrollPartOne}\n{scrollPartTwo}\n{scrollPartThree}\n{MsgScrollIntro}\n{MsgAction}");
                        isAction = Int32.TryParse(Console.ReadLine(), out action);

                        if (isAction)
                        {
                            switch (action)
                            {
                                case 1:
                                    stepOne = 1;
                                    Console.WriteLine(MsgDeciphered, scrolls[0].Replace(' ', '\0'));
                                    break;
                                case 2:
                                    stepTwo = 1;
                                    foreach (char caracter in scrollPartTwo)
                                    {
                                        if (vowels.Contains(caracter))
                                        {
                                            counter++;
                                        }
                                    }
                                    Console.WriteLine(MsgCounted, counter);
                                    break;
                                case 3:
                                    stepThree = 1;
                                    string extractedNumbers = "";
                                    foreach (char caracter in scrollPartThree)
                                    {
                                        if (numbers.Contains(caracter))
                                        {
                                            extractedNumbers += caracter;
                                        }
                                    }
                                    Console.WriteLine(MsgExtracted, extractedNumbers);
                                    break;
                            }
                        }
                        if (!isAction || action < 1 || action > 3)
                        {
                            Console.WriteLine(MsgError);
                        }
                        progress = stepOne + stepTwo + stepThree;

                        if (progress >= 3)
                        {
                            Console.WriteLine(MsgCongratulations);
                        }
                        break;


                    case 0:
                        end = true;
                        Console.WriteLine(MsgProgramEnd);
                        break;
                }
            }
            else Console.WriteLine(MsgError);
        }
    }
}