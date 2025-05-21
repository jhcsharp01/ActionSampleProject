using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MonsterFSM;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.FSM
{
    public class PatrolState : IMonsterState
    {
        private MonsterController monsterController;

        public PatrolState(MonsterController monsterController)
        {
            this.monsterController = monsterController;
        }

        public void Enter()
        {
            NextPoint();
        }

        public void Exit()
        {
           
        }

        public void Stay()
        {
            float distance = Vector3.Distance(monsterController.transform.position, monsterController.player.position);

            if(distance < monsterController.range)
            {
                monsterController.Transition(new ChaseState(monsterController));
                return;
            }
            

            if(monsterController.navMeshAgent.pathPending && monsterController.navMeshAgent.remainingDistance < 0.5f)
            {
                NextPoint();
            }    
        }

        private void NextPoint()
        {
            if (monsterController.points.Length == 0)
                return;

            monsterController.navMeshAgent.destination = monsterController.points[monsterController.current_idx].position;
            monsterController.current_idx = (monsterController.current_idx + 1) % monsterController.points.Length;
        }
    }
}
