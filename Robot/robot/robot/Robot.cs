using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace robot
{
    public class Robot
    {
        String name = "";
        int liv = 0;
        int tab = 0;
        int sejre = 0;
        int uafgjorte = 0;
        int[][] skjold_vaaben;

        public Robot()
        {

        }

        public int Liv 
        { 
            get
            {
                return liv;
            }
            set
            {
                liv = value;
            }
        }

        public int Tab
        {
            get
            {
                return tab;
            }
            set
            {
                tab = value;
            }
        }

        public int Sejre
        {
            get
            {
                return sejre;
            }
            set
            {
                sejre = value;
            }
        }

        public int Uafgjorte
        {
            get
            {
                return uafgjorte;
            }
            set
            {
                uafgjorte = value;
            }
        }

        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int[][] Skjold_Vaaben
        {
            get
            {
                return skjold_vaaben;
            }
            set
            {
                skjold_vaaben = value;
            }
        }
    }
}