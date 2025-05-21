using System;
using Google.GData.Extensions;
using UnityEngine;
using UnityEngine.AI; //�׺���̼� ����


//MonsterFSM �ڵ� ���
//1. �̵� ��� : Navmesh Agent
//2. ���� ��ȯ ���(FSM) : Patrol <--> Chase
//3. ������ : �÷��̾�
//4. �߰� ���� : Patrol�� �ʿ��� �̵� ���


public class MonsterFSM : MonoBehaviour
{
    //1. ���� ǥ��(Enum)
    public enum MonsterState { Patrol, Chase }

    //2. �ʵ� ����
    [Header("������ ����")]
    public MonsterState State;
    public Transform[] points; //���� ��ġ
    int current_idx = 0;
    [Header("�÷��̾�")]
    public Transform player;   //�÷��̾�
    [Header("���� ����")]
    public float range = 3.0f; //���� ����
    private NavMeshAgent navMeshAgent;

    //3. �⺻ ���� ���
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        State = MonsterState.Patrol;
        NextPoint();
    }

    //4. ���� ���� ����
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        switch(State)
        {
            case MonsterState.Patrol:
                if (distance >= range)
                {
                    //5. ���¿� �´� ������ �Լ��� ���� ����
                    Patrol();
                }
                else
                {
                    //6. ���¸� ��ȯ�� �ڵ� ���
                    State = MonsterState.Chase;
                }
                break;
            case MonsterState.Chase:
                if (distance <= range)
                {
                    Chase();
                }
                else
                {
                    State = MonsterState.Patrol;
                    NextPoint();
                }
                break;
        }
    }

    private void Chase()
    {
        navMeshAgent.destination = player.position; 
    }

    private void Patrol()
    {
        //��ο� ���� ����� �Ϸ�� ���°�, ���������� ���� �Ÿ��� �ſ� �����ٸ�?
        //���� �������� �̵��ض�.
        //navMeshAgent.pathPending : �׺�޽ð� ��ο� ���� ����� ���� ���� ��� true

        if(!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
        {
            NextPoint();
        }
    }

    private void NextPoint()
    {
        if (points.Length == 0)
                return;

        navMeshAgent.destination = points[current_idx].position;
        current_idx = (current_idx + 1) % points.Length;
    }
}
