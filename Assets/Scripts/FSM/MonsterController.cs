using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.AI;
using UnityEngine;
using static MonsterFSM;

namespace Assets.Scripts.FSM
{
    public class MonsterController : MonoBehaviour
    {
        
        public NavMeshAgent navMeshAgent;

        [Header("몬스터의 상태")]
        public IMonsterState monsterState;
        public Transform[] points; 
        public int current_idx = 0;
        [Header("플레이어")]
        public Transform player;   
        [Header("정찰 범위")]
        public float range = 3.0f;

        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            Transition(new PatrolState(this));
        }

        private void Update()
        {
            monsterState?.Stay();
        }

        public void Transition(IMonsterState newState)
        {
            monsterState?.Exit();
            monsterState = newState;
            monsterState.Enter();
        }
    }
}
