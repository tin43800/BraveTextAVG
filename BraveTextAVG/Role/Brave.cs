using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraveTextAVG
{
    class Brave : IBiological
    {
        string name;             
        int speed;
        int level;
        int hp;             //now hp .
        int tmpHp;          //last time hp.
        int maxHp = 150;
        int sp;             //now sp.
        int tmpSp;          //last time sp.
        int maxSp = 100;
        int skill_consume = 20;
        int skill_damage;
        int attack_damage;
        int nowExp;
        int needExp;
        int money;

        public int Speed { get { return speed; } }
        public int Level { get { return level; } set { level = value; } }
        public int Hp
        { 
            get { return hp; } 
            set 
            {
                tmpHp = hp;
                hp = value; 
                if (hp > maxHp)
                    hp = maxHp;
                else if (hp < 0)
                    value = 0;       
            } 
        }
        public int Sp
        {
            get { return sp; }
            set
            {
                tmpSp = sp;
                sp = value;
                if (sp > maxSp)
                    sp = maxSp;
                else if (sp < 0)
                    value = 0;
            }
        }
        public string Name { get { return name; } set { name = value; } }
        public int TmpHp { get { return tmpHp; } }
        public int MaxHp { get { return maxHp; } }
        public int TmpSp { get { return tmpSp; } }
        public int MaxSp { get { return maxSp; } }
        public int Skill_Consume { get { return skill_consume; } }
        public int Skill_Damage { get { return skill_damage; } }
        public int Attack_Damage { get { return attack_damage; } }
        public int NowExp { get { return nowExp; } set { nowExp = value; } }
        public int NeedExp { get { return needExp; } }
        public int Money { get { return money; } set { money = value; } }
        private static Brave instance = null; //singleton
        public static Brave getInstance()
        {
            if (instance == null)
                instance = new Brave();
            return instance;
        }
        private Brave() 
        {
            name = "BRAVE";
            speed = 3;
            hp = maxHp;
            sp = maxSp;
            tmpHp = hp;
            tmpSp = sp;
            skill_damage = 30;
            attack_damage = 10;
            level = 1;
            nowExp = 0;
            needExp = 100;
        }

        public void LevelUp() 
        {
            level += 1;
            speed += 1;
            maxHp += 10;
            maxSp += 10;
            hp = maxHp;
            sp = maxSp;
            needExp += 50;
            nowExp = 0;
            skill_damage += 10;
            attack_damage += 10;
            ShowInfo();
        }
        public void ShowInfo() {
            Console.WriteLine("LEVLE:{0}\nHP:{1}/{6}\nSP:{7}/{8}\nATTACK:{2}\nSPEED:{3}\nMONEY:{4}\nNEXT LEVEL NEED EXP:{5}\n", level, hp, attack_damage, speed, money, needExp - nowExp, maxHp, sp, MaxSp);
        }
    }
}
