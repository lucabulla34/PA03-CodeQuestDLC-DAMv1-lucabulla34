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

        const string MsgInvalidOption = "Invalid option. Try again!";
        const string MsgProgramEnd = "Ending program.";

        Console.WriteLine(MsgInput);
        int poder = 1, randomHours = 0, menu = 0;
        string wizardName = Console.ReadLine(), wizardLevel, capitalizedName;
        bool end = false, isMenu;

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
            } else Console.WriteLine(MsgInvalidOption);
        }
    }
}