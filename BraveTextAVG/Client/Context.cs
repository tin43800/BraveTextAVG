using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraveTextAVG
{
    class Context
    {
        StateManager stateManger;
        public Context() 
        {
            stateManger = new StateManager();
        }
        public void request(StateManager.State state)
        {
            stateManger.changeState(state);
        }
        public StateManager.State updateState()
        {
            return stateManger.getState();
        }
    }
}
