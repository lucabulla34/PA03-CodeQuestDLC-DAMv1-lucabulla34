public class Program
{
    public static void Main()
    {
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
        const string MsgInput = "Hi! Input your wizard's name: ";
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
        const string MsgInvalidOption = "Invalid option. Try again!";
        const string MsgProgramEnd = "Ending program.";

        Console.WriteLine(MsgInput);
        int poder = 1, randomHours, menu, totalHours = 0, wizardLevel = 1;
        bool end = false, isMenu;
        string wizardName = Console.ReadLine(), wizardTitle = "", capitalizedName;

        capitalizedName = wizardName.Substring(0, 1).ToUpper() + wizardName.Substring(1, wizardName.Length - 1).ToLower(); // Capitalitza correctament el nom, s'escrigui com s'escrigui

        while (!end)
        {
            Console.WriteLine(MsgMenu);
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
                            Console.Write(MsgDays, day, capitalizedName, totalHours, poder);
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
                        Console.WriteLine(TrainingComplete, wizardName, wizardLevel, wizardTitle);
                        break;


                    case 2:

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