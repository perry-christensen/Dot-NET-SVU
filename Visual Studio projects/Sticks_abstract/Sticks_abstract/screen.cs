using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sticks_abstract
{
    class screen : Program
    {
        static void Main(string[] args)
        {
            screen s = new screen();
            int menu_item = s.menu();
            s.initGame(menu_item);
        }
        
        
        public override void rules()
        {
            w("### WELCOME TO THE GAME OF STICKS ###");
            w("Here are the rules:");
            w("1)   Initially the game contains 15 sticks.");
            w("2)   Each player must remove 1-3 sticks in each move.");
            w("3)   If a player leaves only 1 stick left on the board, he has won.");
            w("");
            w("Press Enter to return to menu");
            r();
            menu();
        }

        public override int subMenu()
        {
            w("To play this game, you must state the difficulty level. Please select your level according to the options below");
            w("");
            w("");
            w("### DIFFICULTY MENU ###");
            w("1: looser");
            w("2: Easy");
            w("3: Medium");
            w("4: Impossible");
            w("");
            int choice = Int32.Parse(r());
            return choice;
            //diff = choice;
        }

        public override int menu()
        {
            w("### MENU ###");
            w("1: Human vs. Human");
            w("2: Computer vs. Human");
            w("3: rules");
            w("");
            int choice = Int32.Parse(r());
            return choice;
        }

        public override String playerName(int number)
        {
            String name = "";
            w("Player " + number + " please state your name:");
            name = r();
            w("Welcome to the game " + name);
            w("");
            return name;
        }

        public override void quitOrContinue()
        {
            w("Press Y to start new game or N to Exit");
            String val = r();
            if (val.Equals("Y"))
                initGame(menu());
            else if (val.Equals("N"))
                Environment.Exit(1);
            else
            {
                w("You need to give the correct input. Press Y to start new game or N to Exit");
                quitOrContinue();
            }
        }

        public override void w(String text)
        {
            Console.WriteLine(text);
        }

        public override String r()
        {
            return Console.ReadLine();
        }

    }
}
