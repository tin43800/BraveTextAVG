using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Nagahama Megumi
namespace BraveTextAVG
{
    class Monster : IBiological
    {
        string[] names = { "SLIME", "GOBLIN", "RAT", "ORC", "GHOST", "ROBBER", "DRAGON" };
        string name;
        Random random = new Random();
        //Dictionary<string, int> monsterDic;
        int hp;
        int tmpHp;
        int maxHp = 100;
        int attack_damage;
        int skill_damage;
        int exp;
        int money;
        public int Hp 
        {
            get { return hp; } 
            set 
            {
                tmpHp = hp;
                hp = value;
                if (hp <= 0)
                    hp = 0;
            } 
        }
        public int TmpHp { get { return tmpHp; } }
        public int MaxHp { get { return maxHp; } }
        public int Attack_Damage { get { return attack_damage; } }
        public int Skill_Damage { get { return skill_damage; } }
        public int Exp { get { return exp; } set { exp = value; } }
        public int Money { get { return money; } set { money = value; } }
        private static Monster instance = null; //singleton
        public static Monster getInstance()
        {
            if (instance == null)
                instance = new Monster();
            return instance;
        }
        private void MonsterAdd()
        {

        }
        private Monster() 
        {
            name = names[random.Next(0, names.Length)];
            hp = maxHp;
            tmpHp = hp;
            attack_damage = 5;
            skill_damage = 10;
            exp = 20;
            money = 5;
        }

        public void reset()
        {
            maxHp += 5;
            hp = maxHp;
        }
    }
}
