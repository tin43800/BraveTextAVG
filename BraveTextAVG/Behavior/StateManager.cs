using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraveTextAVG
{
   
    class StateManager
    {
        private delegate void Callback();
        Brave brave = Brave.getInstance();
        Monster monster = Monster.getInstance();
        Random random = new Random();
        bool autoFight = false;
        int sleepTime = 250;
        public StateManager() 
        {
            AddState();
        }
        public enum State                   //GAME STATE.
        { 
            //-------PLAYER BEHAVIOR
            DONOTHING,                      //just do nothing.
            WAITING,                        //waiting for player attach.
            SUFFERED,                       //Suffer the monster.

            //WALK
            PLAYER_MOVE_FORWARD,            //player move forward.
            PLAYER_MOVE_BACK,               //player move back.
            PLAYER_MOVE_LEFT,               //player move left.
            PLAYER_MOVE_RIGHT,              //player move right.

            //FIGHT
            PLAYER_AUTOFIGHT,               //auto fight.
            PLAYER_FIGHT,                   //player wait fight state
            PLAYER_ATTACK,                  //player attack.
            PLAYER_USESKILL,                //player use skill.
            PLAYER_USEITEM,                 //Player use item.
            PLAYER_HURT,                    //player hurt.
            PLAYER_DIE,                     //player die.
            PLAYER_INFO,

            //-------MOSTER BEHAVIOR
            MONSTER_ATTACK,                 //monster attack.
            MONSTER_USESKILL,               //monster use skill
            MONSTER_HURT,                   //monster hurt.
            MONSTER_DIE,                    //monster die.

            //ACCOUNT
            GAME_ACCOUNT,
            NPC_MEET,
            PLAYER_LEVELUP                 //player level up.
        }
        public State state = State.WAITING;

        Dictionary<State, Callback> stateDic = new Dictionary<State, Callback>();

        public void AddState()
        {
            stateDic.Add(State.DONOTHING, DoNothing);
            stateDic.Add(State.WAITING, Waiting);
            stateDic.Add(State.SUFFERED, Suffered);
            stateDic.Add(State.PLAYER_MOVE_FORWARD, Player_Move_Forward);
            stateDic.Add(State.PLAYER_MOVE_BACK, Player_Move_Back);
            stateDic.Add(State.PLAYER_MOVE_LEFT, Player_Move_Left);
            stateDic.Add(State.PLAYER_MOVE_RIGHT, Player_Move_Right);
            stateDic.Add(State.PLAYER_AUTOFIGHT, Player_AutoFight);
            stateDic.Add(State.PLAYER_FIGHT, Player_Fight);
            stateDic.Add(State.PLAYER_ATTACK, Player_Attack);
            stateDic.Add(State.PLAYER_USESKILL, Player_UseSkill);
            stateDic.Add(State.PLAYER_USEITEM, Player_UseItem);
            stateDic.Add(State.PLAYER_HURT, Player_Hurt);
            stateDic.Add(State.PLAYER_DIE, Player_Die);
            stateDic.Add(State.PLAYER_LEVELUP, Player_LevelUp);
            stateDic.Add(State.PLAYER_INFO, Player_Info);
            stateDic.Add(State.MONSTER_ATTACK, Monster_Attack);
            stateDic.Add(State.MONSTER_USESKILL, DoNothing);
            stateDic.Add(State.MONSTER_HURT, Monster_Hurt);
            stateDic.Add(State.MONSTER_DIE, Monster_Die);
            stateDic.Add(State.GAME_ACCOUNT, Game_Account);
            stateDic.Add(State.NPC_MEET, Npc_Meet);
        }
        public void changeState(State state){
            this.state = state;
            stateDic[state].Invoke();
        }
        private bool Special(int special = 7) //random behavior such as attack or suffered monstwer
        { 
            int value=random.Next(1,10);
            if (value >= special)
                return true;
            return false;
        }
        //DEBUG : If function not set , I will know ~
        private void DoNothing()
        {  
            Console.WriteLine("FUNCTION NO SET!");
        }
        private void Waiting()
        {
            Console.WriteLine("WAITING....\n");
        }
        private void Suffered() {
            Console.WriteLine("SUFFERED MONSTER!....\n");
            Console.WriteLine("START BATTLE!....\n");
            changeState(State.PLAYER_FIGHT);
        }
        private void Player_Move_Forward() 
        {
            int distance = brave.Speed;
            Console.WriteLine("BRAVE MOVE TO {0} : {1} ...\n", "FORWARD", distance);
            if (Special())
                changeState(State.SUFFERED);
            else
                changeState(State.WAITING);
        }
        private void Player_Move_Back()
        {
            int distance = brave.Speed;
            Console.WriteLine("BRAVE MOVE TO {0} : {1} ...\n", "BACK", distance);
            if (Special())
                changeState(State.SUFFERED);
            else
                changeState(State.WAITING);
        }
        private void Player_Move_Left()
        {
            int distance = brave.Speed;
            Console.WriteLine("BRAVE MOVE TO {0} : {1} ...\n", "LEFT", distance);
            if (Special())
                changeState(State.SUFFERED);
            else
                changeState(State.WAITING);
        }
        private void Player_Move_Right()
        {
            int distance = brave.Speed;
            Console.WriteLine("BRAVE MOVE TO {0} : {1} ...\n", "RIGHT", distance);
            if (Special())
                changeState(State.SUFFERED);
            else
                changeState(State.WAITING);
        }
        private void Player_AutoFight() 
        {
            autoFight = true;
            sleepTime = 1;
            changeState(State.PLAYER_ATTACK);
        }
        private void Player_Fight() 
        {
            ConsoleKeyInfo input;
            Console.WriteLine("---------------------------------------\n");
            Console.WriteLine("BRAVE HP:{0}/{1} SP:{2}/{3}\n", brave.Hp, brave.MaxHp, brave.Sp, brave.MaxSp);
            Console.WriteLine("MONSTER HP:{0}/{1}", monster.Hp, monster.MaxHp);
            Console.WriteLine("\n1:ATTACK\n2:SKILL\n3:ITEM\n4:AUTOFIGHT\n");
            Console.WriteLine("---------------------------------------");
            do
            {
                input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.D1)
                    changeState(State.PLAYER_ATTACK);
                if (input.Key == ConsoleKey.D2)
                    changeState(State.PLAYER_USESKILL);
                if (input.Key == ConsoleKey.D3)
                    changeState(State.PLAYER_USEITEM);
                if (input.Key == ConsoleKey.D4)
                    changeState(State.PLAYER_AUTOFIGHT);
                if (input.Key == ConsoleKey.L) // CHEAT MODE --- LEVEL UP
                    changeState(State.PLAYER_LEVELUP);

            } while (state == State.PLAYER_FIGHT);
        }
        private void Player_Attack()
        {
            monster.Hp -= brave.Attack_Damage;
            Console.WriteLine("PLAYER ATTACK {0} DAMAGE....\n",brave.Attack_Damage);
            System.Threading.Thread.Sleep(sleepTime);
            changeState(State.MONSTER_HURT);
        }
        private void Player_UseSkill()
        {
            if (brave.Sp < brave.Skill_Consume)
            {
                Console.WriteLine("NO ENOUGN SP !...");
                changeState(State.PLAYER_FIGHT);
                return;
            }
            Console.WriteLine("PLAYER USE SKILL!!! {0} DAMAGE....\n",brave.Skill_Damage);
            brave.Sp -= brave.Skill_Consume;
            Console.WriteLine("PLAYER SP {0} ---> {1} ....\n", brave.TmpSp, brave.Sp);
            System.Threading.Thread.Sleep(sleepTime);
            monster.Hp -= brave.Skill_Damage;


            changeState(State.MONSTER_HURT);
        }
        private void Player_UseItem()
        {
            Console.WriteLine("PLAYER USE ITEM....");
            brave.Hp += 100;
            Console.WriteLine("HP:{0} --> HP:{1}\n", brave.TmpHp, brave.Hp);
            
            changeState(State.MONSTER_ATTACK);
        }
        private void Player_Hurt()
        {
            Console.WriteLine("PLAYER HP  : {0} ---> {1}  ....\n",brave.TmpHp,brave.Hp);
            System.Threading.Thread.Sleep(sleepTime);
            if (brave.Hp <= 0)
                changeState(State.PLAYER_DIE);
            else if (!autoFight)
                changeState(State.PLAYER_FIGHT);
            else
                changeState(State.PLAYER_ATTACK);
        }
        private void Player_Die()
        {
            autoFight = false;
            sleepTime = 250;
            Console.WriteLine("PLAYER DIE....\n");
        }

        private void Player_LevelUp()
        {
            Console.WriteLine("PLAYER Level UP!....\n");
            brave.LevelUp();
            changeState(State.NPC_MEET);
        }
        private void Player_Info()
        {
            brave.ShowInfo();
            changeState(State.WAITING);
        }
        private void Monster_Attack()
        {
            if (Special(9))
            {
                brave.Hp -= monster.Skill_Damage;
                Console.WriteLine("MONSTER USE SKILL!!! {0} DAMAGE....\n", monster.Skill_Damage);
            }
            else
            {
                brave.Hp -= monster.Attack_Damage;
                Console.WriteLine("MONSTER ATTACK {0} DAMAGE....\n", monster.Attack_Damage);
            }
            System.Threading.Thread.Sleep(sleepTime);
            changeState(State.PLAYER_HURT);
        }
        private void Monster_Hurt() 
        {
            Console.WriteLine("MONSTER HP : {0} ---> {1} ....\n",monster.TmpHp,monster.Hp);
            System.Threading.Thread.Sleep(sleepTime);
            if (monster.Hp <= 0)
                changeState(State.MONSTER_DIE);
            else
                changeState(State.MONSTER_ATTACK);
        }
        private void Monster_Die()
        {
            autoFight = false;
            sleepTime = 250;
            Console.WriteLine("MONSTER DIE....\n");
            Console.WriteLine("WIN !!....\n");
            changeState(State.GAME_ACCOUNT);
        }
        private void Game_Account()
        {
            int tmpExp = brave.NowExp;
            int tmpMoney = brave.Money;
            brave.NowExp += monster.Exp;
            brave.Money += monster.Money;
            Console.WriteLine("BRAVE EXP {0} ---> {1}....\n",tmpExp,brave.NowExp);
            Console.WriteLine("BRAVE MONEY {0}z ---> {1}z ....\n", tmpMoney, brave.Money);
            if (brave.NowExp >= brave.NeedExp)
                changeState(State.PLAYER_LEVELUP);
            else
                changeState(State.WAITING);
            monster.reset();
        }
        private void Npc_Meet() 
        {
            Console.WriteLine("------------------------------------\n");
            Console.WriteLine("WEAPON STORE.\nMONEY:{0}\n",brave.Money);
            NPC weaponSolder = new NPC();
            Console.WriteLine("------------------------------------\n");
            changeState(State.WAITING);
        }
        public State getState()
        {
            return state;
        }
    }
}
 