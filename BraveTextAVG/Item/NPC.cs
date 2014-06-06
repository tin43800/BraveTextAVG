using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraveTextAVG
{
    class NPC
    {
        WeaponGenerate wg = new WeaponGenerate();
        Dictionary<int, string> weapons = new Dictionary<int, string>();
        List<int> dollars = null;
        public NPC() 
        {
            for (int i = 1; i < 5; i++)
            {
                string weapon = wg.Name;
                int dollar = wg.Dollar;
                if (!weapons.ContainsKey(dollar))
                    weapons.Add(dollar, weapon);         

            }
            dollars = weapons.Keys.ToList();
            dollars.Sort();
            int n = 1;
            foreach (int dollar in dollars)
            {               
                Console.WriteLine(n + ".${0} {1}", dollar, weapons[dollar]);
                n++;
            }
        }

    }
}
