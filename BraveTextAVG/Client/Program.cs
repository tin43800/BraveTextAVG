using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraveTextAVG
{
    class Program
    {
        static void Main(string[] args)
        {
            Brave brave = Brave.getInstance();
            Context context = new Context();
            StateManager.State state;
            Console.WriteLine("---------------------------");
            Console.WriteLine("WELLCOM TO 《 BRAVE AVG 》!");
            Console.WriteLine("I'AM " + brave.Name+" ! ");
            showHelp();
            ConsoleKeyInfo input;
            //Console.ReadKey(true);
            state = StateManager.State.WAITING;
            do
            {
                
                state = context.updateState();
                input = Console.ReadKey(true);
                if (state == StateManager.State.WAITING)
                {
                    if (input.Key == ConsoleKey.W)
                        state = StateManager.State.PLAYER_MOVE_FORWARD;
                    else if (input.Key == ConsoleKey.S)
                        state = StateManager.State.PLAYER_MOVE_BACK;
                    else if (input.Key == ConsoleKey.A)
                        state = StateManager.State.PLAYER_MOVE_LEFT;
                    else if (input.Key == ConsoleKey.D)
                        state = StateManager.State.PLAYER_MOVE_RIGHT;
                    else if (input.Key == ConsoleKey.Q)
                        state = StateManager.State.PLAYER_FIGHT;
                    else if (input.Key == ConsoleKey.H)
                        showHelp();
                    /*else if (input.Key == ConsoleKey.E)
                        state = StateManager.State.PLAYER_USEITEM;*/
                    else if (input.Key == ConsoleKey.I)
                        state = StateManager.State.PLAYER_INFO;
                    if(state !=StateManager.State.WAITING)
                    context.request(state);            
                }
                /*if (state == StateManager.State.FIGHT) 
                {
                
                }*/

               /* if (input.Key != ConsoleKey.Escape)
                    Console.WriteLine("\n");*/
            }   while (input.Key != ConsoleKey.Escape);
        }
        public static void showHelp()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("W S A D : MOVE\nQ : FIGHT\nE:USE ITEM\nI:SHOW INFO\nH : HELP");
            Console.WriteLine("---------------------------"); 
        }
    }
}
