using System.Data;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; // Solution to see emojis in the console.
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
        const string MsgDays = "Day {0}: {1}, you have trained for a total of {2} hours and gained {3} power points.";
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
        const string DiceOne = """
              ________
             /       /|
            /_______/ |
            |       | |
            |   o   | /
            |       |/
            '-------'
            """;
        const string DiceTwo = """
              ________
             /       /|
            /_______/ |
            | o     | |
            |       | /
            |     o |/
            '-------'
            """;
        const string DiceThree = """
              ________
             /       /|
            /_______/ |
            | o     | |
            |   o   | /
            |     o |/
            '-------'
            """;
        const string DiceFour = """
              ________
             /       /|
            /_______/ |
            | o   o | |
            |       | /
            | o   o |/
            '-------'
            """;
        const string DiceFive = """
              ________
             /       /|
            /_______/ |
            | o   o | |
            |   o   | /
            | o   o |/
            '-------'
            """;
        const string DiceSix = """
              ________
             /       /|
            /_______/ |
            | o   o | |
            | o   o | /
            | o   o |/
            '-------'
            """;

        //3
        const string MineHeader = "\t 0\t 1\t 2\t 3\t 4";
        const string Unexplored = "➖";
        const string Coin = "🪙";
        const string EmptySlot = "❌";
        const string EmptyInvisibleSlot = "Empty";
        const string CoinInvisibleSlot = "Coin";
        const string KeyToContinue = "Press any key to roll the dice again...";
        const string ChooseX = "Insert the X axis: ";
        const string ChooseY = "Insert the Y axis: ";
        const string MsgCoinFound = "You mined at [{0}, {1}] and found a coin which contained {2} bits! You now have {3} attempts.";
        const string MsgNotFound = "You mined at [{0}, {1}] and didn't find anything. You now have {2} attempts.";

        //4
        const string MsgInventoryContains = "Your inventory contains:\n";
        const string MsgEmptyInventory = "Your inventory is empty.";

        //5


        const string IronDagger = "Iron Dagger 🗡️";
        const string HealingPotion = "Healing Potion ⚗️";
        const string AncientKey = "Ancient Key 🗝️";
        const string Crossbow = "Crossbow 🏹";
        const string MetalShield = "Metal Shield 🛡️";
        const string MsgShop = "You chose to buy items. \nYou have {0} bits available.\nObject \t\t\t\t\tPrice (bits)\n";
        const string MsgSelectItem = "Select the item you wish to buy (1 - 5) (0 to exit):";
        const string MsgItemBought = "You have purchased: {0} for {1} bits. Bits remaining: {2}";
        const string MsgNotEnoughFunds = "You haven't got enough bits for this purchase.";

        //6
        const string MagicSpark = "Magic Spark 💫";
        const string Fireball = "Fireball 🔥";
        const string IceRay = "Ice Ray 🥏";
        const string ArcaneShield = "Arcane Shield ⚕️";
        const string Meteor = "Meteor ☄️";
        const string Explosion = "Pure Energy Explosion 💥";
        const string MinorCharm = "Minor Charm 🎭";
        const string AirStrike = "Air Strike 🍃";
        const string WaveOfLight = "Wave of Light ⚜️";
        const string StormOfWings = "Storm of Wings 🐦";
        const string Cataclysm = "Cataclysm 🌋";
        const string PortalOfChaos = "Portal of Chaos 🌀";
        const string ArcaneBlood = "Arcane Blood Pact 🩸";
        const string ElementalStorm = "Elemental Storm ⛈️";

        const string MsgAttacks = "Available attacs for level {0}: \n";

        //7
        const string MsgAncientFound = "You found an ancient scroll with encrypted messages!";
        const string MsgScrollIntro = "Scroll to decode: ";
        const string ScrollPartOne = "\"The 🐲 sleeps in the mountain of fire 🔥\"";
        const string ScrollPartTwo = "\"Ancient magic flows through the crystal caves\"";
        const string ScrollPartThree = "\"Spell: Ignis 5 🔥, Aqua 6 💧, Terra 3 🌍, Ventus 8 🌪️\"\n";
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
        const string MsgNull = "Value can't be empty. Try again!";
        const string MsgError = "Invalid option. Try again!";
        const string MsgProgramEnd = "Ending program.";


        const int WanderSkeletonHP = 3, ForestGoblinHP = 5, GreenSlimeHP = 10, EmberWolfHP = 11,
            GiantSpiderHP = 18, IronGolemHP = 15, LostNecromancerHP = 20, AncientDragonHP = 50;



        int power = 1, randomHours, op = -1, dice, totalHours = 0, wizardLevel = 1, randomMonster, attempts, yAxis, xAxis, bits,
            totalBits = 0, progress, stepOne = 0, stepTwo = 0, stepThree = 0;


        bool isOp, isValidSelection;

        string opString, wizardName, wizardTitle = TitleOne, vowels = "aeiouAEIOU", numbers = "1234567890";


        int[] healthpoints = { WanderSkeletonHP, ForestGoblinHP, GreenSlimeHP, EmberWolfHP,
        GiantSpiderHP, IronGolemHP, LostNecromancerHP, AncientDragonHP}, itemsPrice = { 30, 10, 50, 40, 20 };

        bool[] itemOnIndex = new bool[6];

        string[] monsters = {MonsterSkeleton, MonsterForestGoblin, MonsterGreenSlime, MonsterEmberWolf,
        MonsterGiantSpider, MonsterIronGolem, MonsterLostNecromancer, MonsterAncientDragon},
        userOutput = { Unexplored, Coin, EmptySlot },
        treasures = { EmptyInvisibleSlot, CoinInvisibleSlot },
        itemsForSale = { IronDagger, HealingPotion, AncientKey, Crossbow, MetalShield },
        inventory = new string[0],
        scrolls = { ScrollPartOne, ScrollPartTwo, ScrollPartThree },
        dices = { DiceOne, DiceTwo, DiceThree, DiceFour, DiceFive, DiceSix };
        string[][] levels = new string[5][];
        levels[0] = new string[] { MagicSpark };
        levels[1] = new string[] { Fireball, IceRay, ArcaneShield };
        levels[2] = new string[] { Meteor, Explosion, MinorCharm, AirStrike };
        levels[3] = new string[] { WaveOfLight, StormOfWings };
        levels[4] = new string[] { Cataclysm, PortalOfChaos, ArcaneBlood, ElementalStorm };

        do
        {
            Console.WriteLine(MsgInput);
            wizardName = Console.ReadLine()!; // The exclamation point is used to tell the System that it won't be null, and in case it's null, it will repeat.
            if (string.IsNullOrWhiteSpace(wizardName))
            {
                Console.WriteLine(MsgNull);
            }
        } while (string.IsNullOrWhiteSpace(wizardName));
        wizardName = wizardName.Substring(0, 1).ToUpper() + wizardName.Substring(1, wizardName.Length - 1).ToLower(); // This will properly capitalize the message, no matter how it's written.
        do
        {
            if (wizardName != "")
            {
                Console.WriteLine(MsgMenuName, wizardName, wizardTitle, wizardLevel);
            }
            else Console.WriteLine(MsgMenu);


            do
            {
                opString = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(opString))
                {
                    Console.WriteLine(MsgNull);
                    isValidSelection = false;
                }
                else
                {
                    isOp = Int32.TryParse(opString, out op);

                    if (isOp && op >= 0 && op < 8)
                    {
                        isValidSelection = true;
                    }
                    else
                    {
                        Console.WriteLine(MsgError);
                        isValidSelection = false;
                    }
                }
            } while (!isValidSelection);
            if (isValidSelection && op < 8 && op >= 0)
            {

                switch (op)
                {
                    case 1:


                        for (int day = 1; day <= 5; day++)
                        {
                            randomHours = rand.Next(0, 25);
                            power += rand.Next(1, 11);
                            totalHours += randomHours;
                            Console.Write(MsgDays, day, wizardName, totalHours, power);
                            Console.WriteLine();
                        }
                        if (power < 20)
                        {
                            Console.WriteLine(MsgLvlOne);
                            wizardTitle = TitleOne;
                        }
                        else if (power >= 20 && power < 30)
                        {
                            Console.WriteLine(MsgLvlTwo);
                            wizardTitle = TitleTwo;
                        }
                        else if (power >= 30 && power < 35)
                        {
                            Console.WriteLine(MsgLvlThree);
                            wizardTitle = TitleThree;
                        }
                        else if (power >= 35 && power < 40)
                        {
                            Console.WriteLine(MsgLvlFour);
                            wizardTitle = TitleFour;
                        }
                        else if (power >= 40)
                        {
                            Console.WriteLine(MsgLvlFive);
                            wizardTitle = TitleFive;
                            Console.WriteLine(TrainingComplete, wizardName, power, wizardTitle);
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
                            Console.WriteLine($"{dices[dice - 1]}");
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
                                Console.WriteLine(LvlUp, wizardLevel);

                                if (wizardLevel < 5)
                                {
                                    wizardLevel++; // Prevents wizard from leveling further than level 5. This will be redundant in chapter 6's mechanics.
                                }
                            }
                        }

                        healthpoints[randomMonster] = tempHP; // Variables to restore enemy's HP once it is defeated, so that if the player faces it again, it won't be at 0 HP.

                        break;


                    case 3:
                        attempts = 5;
                        string[,] mineFilled = new string[ROWS, COLS], mineUser = new string[ROWS, COLS];
                        Console.WriteLine(MineHeader);
                        for (int i = 0; i < mineFilled.GetLength(0); i++)
                        {
                            Console.Write(i);
                            for (int j = 0; j < mineFilled.GetLength(1); j++)
                            {
                                mineFilled[i, j] = treasures[rand.Next(0, treasures.Length)];
                                Console.Write($"\t{userOutput[0]}");
                            }
                            Console.WriteLine();
                        }

                        do
                        {
                            Console.Write($"{ChooseX} \n");
                            bool isAxis = Int32.TryParse(Console.ReadLine(), out xAxis);

                            if (isAxis && xAxis < ROWS && xAxis >= 0)
                            {
                                Console.Write($"{ChooseY} \n");
                                isAxis = Int32.TryParse(Console.ReadLine(), out yAxis);
                                if (isAxis && yAxis < COLS && yAxis >= 0)
                                {
                                    if (mineFilled[xAxis, yAxis] == treasures[1])
                                    {
                                        bits = rand.Next(5, 51);
                                        totalBits += bits;
                                        mineUser[xAxis, yAxis] = userOutput[1];
                                        attempts--;
                                        Console.WriteLine(MsgCoinFound, xAxis, yAxis, bits, attempts);
                                        mineFilled[xAxis, yAxis] = treasures[0]; // This line prevents the same spot from being exploited twice.
                                    }
                                    else if (mineFilled[xAxis, yAxis] == treasures[0])
                                    {
                                        mineUser[xAxis, yAxis] = userOutput[2];
                                        attempts--;
                                        Console.WriteLine(MsgNotFound, xAxis, yAxis, attempts);
                                    }
                                    Console.WriteLine(MineHeader);
                                    for (int i = 0; i < mineFilled.GetLength(0); i++)
                                    {
                                        Console.Write(i);
                                        for (int j = 0; j < mineFilled.GetLength(1); j++)
                                        {
                                            if (mineUser[i, j] == userOutput[1])
                                            {
                                                Console.Write($"\t{userOutput[1]} ");
                                            }
                                            else if (mineUser[i, j] == userOutput[2])
                                            {
                                                Console.Write($"\t{userOutput[2]} ");
                                            }
                                            else Console.Write($"\t{userOutput[0]} ");
                                        }
                                        Console.WriteLine();

                                    }
                                }
                                else Console.WriteLine(MsgError);
                            }
                            else Console.WriteLine(MsgError);
                        } while (attempts > 0);
                        break;


                    case 4:
                        if (inventory.Length == 0)
                        {
                            Console.WriteLine(MsgEmptyInventory);
                        }
                        else
                        {
                            Console.Write(MsgInventoryContains);

                            for (int i = 0; i < inventory.Length; i++)
                            {
                                Console.WriteLine($"{inventory[i]}"); //Adds the items bought in the shop to current inventory.
                            }
                        }
                        break;


                    case 5:
                        int itemBought;
                        bool isValid;


                        Console.WriteLine(MsgShop, totalBits);
                        for (int i = 0; i < itemsForSale.Length; i++)
                        {
                            Console.Write($"{itemsForSale[i]}     \t\t\t\t{itemsPrice[i]}\n");
                        }
                        Console.WriteLine(MsgSelectItem);
                        isValid = Int32.TryParse(Console.ReadLine(), out itemBought);
                        if (isValid && itemBought < 6 && itemBought > 0)
                        {
                            if (totalBits - itemsPrice[itemBought - 1] >= 0) // User can buy the item
                            {
                                totalBits = totalBits - itemsPrice[itemBought - 1];
                                string newItem = itemsForSale[itemBought - 1];
                                string[] tempInventory = new string[inventory.Length + 1]; //Create a new temporal array 
                                for (int i = 0; i < inventory.Length; i++)
                                {
                                    tempInventory[i] = inventory[i];
                                }
                                tempInventory[tempInventory.Length - 1] = newItem;
                                inventory = tempInventory;
                                Console.WriteLine(MsgItemBought, itemsForSale[itemBought - 1], itemsPrice[itemBought - 1], totalBits);
                            }
                            else Console.WriteLine(MsgNotEnoughFunds);
                        }
                        if (!isValid || itemBought < 1 || itemBought > 5)
                        {
                            Console.WriteLine(MsgError);
                        }
                        break;


                    case 6:

                        int maxLevelIndex = levels.Length - 1;
                        int targetIndex = wizardLevel - 1;

                        if (targetIndex > maxLevelIndex)
                        {
                            targetIndex = maxLevelIndex; //This would enable the wizard to see level 5's attacks even though they've gone further than level 5. This is now redundant, since max level is 5, but I'll keep it for possible updates.
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
                        Console.Write($"{ScrollPartOne}\n{ScrollPartTwo}\n{ScrollPartThree}\n{MsgScrollIntro}\n{MsgAction}");
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
                                    foreach (char character in ScrollPartTwo)
                                    {
                                        if (vowels.Contains(character))
                                        {
                                            counter++;
                                        }
                                    }
                                    Console.WriteLine(MsgCounted, counter);
                                    break;
                                case 3:
                                    stepThree = 1;
                                    string extractedNumbers = "";
                                    foreach (char caracter in ScrollPartThree)
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
                        Console.WriteLine(MsgProgramEnd);
                        break;
                }
            }
            else Console.WriteLine(MsgError);
        } while (op != 0);
    }
}