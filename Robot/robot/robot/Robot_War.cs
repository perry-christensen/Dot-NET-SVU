using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace robot
{
    public class Robot_War
    {
        Robot r1 = new Robot(), r2 = new Robot();
        public Robot_War()
        {

        }

        public String play(Robot r1, Robot r2, int rounds)
        {
            this.r1 = r1;
            this.r2 = r2;
            String output = "";
            int currentRound = 0;
            while (!GameFinished(currentRound, rounds))
            {
                output += Round(currentRound);
                currentRound++;
            }
            output += Winner();
            return output;
        }

        public bool GameFinished(int currentRound, int rounds)
        {
            if (currentRound == rounds || r1.Liv == -1 || r2.Liv == -1)
                return true;
            else
                return false;
        }

        public String Winner()
        {
            return r1.Liv < r2.Liv ? "" + r2.Name + " is the winner! " + r2.Name + " has " + r2.Liv + " left, whereas " + r1.Name + " has " + r1.Liv + "!<br />" : r2.Liv < r1.Liv ? "" + r1.Name + " is the winner!" + r1.Name + " has " + r1.Liv + " left, whereas " + r2.Name + " has " + r2.Liv + "!<br />" : "It is a tie! " + r1.Name + " has " + r1.Liv + " left and " + r2.Name + " has " + r2.Liv + " left!<br />";
        }

        public String Round(int currentRound)
        {
            String text = "";
            if (r1.Skjold_Vaaben[currentRound % r1.Skjold_Vaaben.Length][1] != r2.Skjold_Vaaben[currentRound % r2.Skjold_Vaaben.Length][0])
            {
                r2.Liv -= 1;
                text += r1.Name + " Made a successful strike at " + r2.Name + ". " + r2.Name + " now has " + r2.Liv + " left!<br />";
            }
            else
            {
                text += r2.Name + "'s shield matches " + r1.Name + "'s weapon. " + r2.Name + "'s life count has not been decreased!<br />";
            }
            if (r2.Skjold_Vaaben[currentRound % r2.Skjold_Vaaben.Length][1] != r1.Skjold_Vaaben[currentRound % r1.Skjold_Vaaben.Length][0])
            {
                r1.Liv -= 1;
                text += r2.Name + " Made a successful strike at " + r1.Name + ". " + r1.Name + " now has " + r1.Liv + " left!<br />";
            }
            else
            {
                text += r1.Name + "'s shield matches " + r2.Name + "'s weapon. " + r1.Name + "'s life count has not been decreased!<br />";
            }
            return text;
        }
    }
}