using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StopNode : Node
{
    Transform target;
    NavMeshAgent agent;
    float stoppingDistance = 0f;


    public StopNode(NavMeshAgent _agent, Transform _target, float _stoppingDistance)
    {
        agent = _agent;
        target = _target;
        stoppingDistance = _stoppingDistance;
    }

    public override NodeState Evaluate()
    {
        Vector3 prev = agent.destination;
        //if at target return sucess
        if (agent.remainingDistance < stoppingDistance)
        {
            //stop and turn to target
            agent.SetDestination(agent.transform.position);
            agent.updateRotation = false;
            return NodeState.success;

        }
        //agent.updateRotation = true;
        //agent.SetDestination(prev);
        return NodeState.failure;

    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }
}
