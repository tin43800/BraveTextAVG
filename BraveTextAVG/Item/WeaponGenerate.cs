using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraveTextAVG
{
    class WeaponGenerate
    {
        public enum Title
        {                                  //atk      Probability
            LEGACY = 0,      //initial       +0           0%
            BASE = 5,        //base weapon   +3          58% 
            GOOD = 10,        //              +5          33%
            EXPERT = 20,     //              +10          5%
            MASTER = 30,     //              +20          3%
            LEGENDARY = 50,  //              +30          1%
        }
        Title title = Title.LEGACY;
        public enum Property
        {                                //Probability
            NONE = 0,        // NO               60%
            WATER = 5,       // Water            10%
            FLAME = 5,       // Flame            10%
            THUNDER = 5,     // Thunder          10%
            LIGHT = 10,      // Light             5%
            DARK = 10,       // Dark              5%
        }
        Property property = Property.NONE;
        Random random = new Random();
        string name;
        public string Name 
        {
            get
            {
                string title;
                string property;
                title = RandTitle();
                property = RandProperty();
                if (property == "NONE")
                    name = title + " SWORD.";
                else
                    name = title + " OF " + property + " SWORD.";
                return name;
            } 
        }
        int dollar = 0;
        public int Dollar
        {
            get
            {
                dollar = 10*((int)title + (int)property);
                return dollar;
            }
        }
        int value;
        public string RandTitle() 
        {
            value = random.Next(1, 101); //1~100
            if (value <= 58)
                title = Title.BASE;
            else if (value > 58 && value <= 91)
                title = Title.GOOD;
            else if (value > 91 && value <= 96)
                title = Title.EXPERT;
            else if (value > 96 && value <= 99)
                title = Title.MASTER;
            else
                title = Title.LEGENDARY;
            return title.ToString();
        }
        public string RandProperty()
        {
            value = random.Next(1, 101); //1~100
            if (value <= 60)
                property = Property.NONE;
            else if (value > 60 && value <= 70)
                property = Property.WATER;
            else if (value > 70 && value <= 80)
                property = Property.FLAME;
            else if (value > 80 && value <= 90)
                property = Property.THUNDER;
            else if (value > 90 && value <= 95)
                property = Property.LIGHT;
            else
                property = Property.DARK;
            return property.ToString();
        }
    }
}
