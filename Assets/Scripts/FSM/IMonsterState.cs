using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.FSM
{
    public interface IMonsterState
    {
        void Enter();
        void Stay();
        void Exit();

    }
}
