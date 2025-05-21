using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.FSM
{
    public class ChaseState : IMonsterState
    {
        private MonsterController monsterController;

        public ChaseState(MonsterController monsterController)
        {
            this.monsterController = monsterController;
        }

        public void Enter()
        {
        }

        public void Exit()
        {
        
        }

        public void Stay()
        {
            float distance = Vector3.Distance(monsterController.transform.position, monsterController.player.position);

            if (distance < monsterController.range)
            {
                monsterController.Transition(new PatrolState(monsterController));
                return;
            }

            monsterController.navMeshAgent.destination = monsterController.player.position;
        }
    }
}
