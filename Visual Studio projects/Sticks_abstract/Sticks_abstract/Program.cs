using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sticks_abstract
{
    public abstract class Program
    {
        private int sticks = 15;
        private int opt = 0;
        private int diff = 1;
        private String p1 = "", p2 = "", player = "";
        private bool isP1 = true;
        private bool twoPlayer = false;
        private Random rand = new Random();
        
        public abstract void rules();

        public abstract int menu();

        public abstract int subMenu();

        public abstract String playerName(int number);
        
        public abstract void quitOrContinue();

        public abstract void w(String text);

        public abstract String r();
        
        
        
        public void initGame(int choice)
        {
            switch (choice)
            {
                case 1:
                    twoPlayer = true;
                    p1 = playerName(1);
                    p2 = playerName(2);
                    player = p1;
                    play();
                    break;
                case 2:
                    p2 = playerName(2);
                    p1 = "Computer";
                    player = p1;
                    diff = subMenu();
                    computer();
                    break;
                case 3: 
                    rules();
                    break;
                default: 
                    rules();
                    break;
            }
        }
        
        private void computer()      //hard
        {
            switch (diff)
            {
                case 1:
                    looser();
                    break;
                case 2: 
                    easy();
                    break;
                case 3: 
                    medium();
                    break;
                default: 
                    hard();
                    break;
            }
            togglePlayer();
        }

        private void looser()
        {
            opt = (sticks + 1) % 4 + 1;
            decrementStick(opt);       //If computer always start, then the computer will always win
            compUpdate();
        }
        
        private void easy()
        {
            opt = 1;
            decrementStick(opt);       //If computer always start, then the computer will always win
            compUpdate();
        }

        private void medium()
        {
            if (sticks <= 3)
                opt = rand.Next(1, sticks);
            else
                opt = rand.Next(1, 3);
            decrementStick(opt);       //If computer always start, then the computer will always win
            compUpdate();
        }
        
        private void hard()
        {
            opt = (sticks - 1) % 4;
            decrementStick(opt);       //If computer always start, then the computer will always win
            compUpdate();
        }

        private void compUpdate()
        {
            w(removed());
            togglePlayer();
            play();
        }

        private void togglePlayer()
        {
            if (isP1)
            {
                player = p2;
                isP1 = false;
            }
            else
            {
                player = p1;
                isP1 = true;
            }
        }

        private bool isGameWon()
        {
            if (sticks == 1)
                return true;
            else
                return false;
        }

        private void resetGame()
        {
            togglePlayer();
            w(player + " won the game!");
            sticks = 15;
            isP1 = true;
            twoPlayer = false;
            player = "";
            diff = 1;
            opt = 0;
            quitOrContinue();
        }
        
        private void play()
        {
            if (isGameWon())
                resetGame();
            else
            {
                w(player + " there are now " + sticks + " on the board. How many do you wish to remove?");
                if (isP1 && !twoPlayer)
                    computer();
                else
                    humanPlayer();
            }
        }

        private void humanPlayer()
        {
            while (!validate(r()))
            {
                w("You must enter a number between 1 and 3. The number should be at least 1 less than the residual number of sticks. Please try again");
            }
            w(removed());
            decrementStick(opt);
            togglePlayer();
            play();
        }

        private void decrementStick(int opt)
        {
            sticks -= opt;
        }

        private bool validate(String input)
        {
            try
            {
                opt = Int32.Parse(input);
            }
            catch (Exception)
            {
                return false; 
            }
            if (opt < 1 || opt > 3 || opt > (sticks - 1))
                return false;
            else
                return true;
        }

        private String removed()
        {
            return player + ", you removed " + opt + " sticks from the board.";
        }     
    }
}
