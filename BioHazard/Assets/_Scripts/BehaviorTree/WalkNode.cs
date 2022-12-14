using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkNode : Node
{
    Transform target;
    NavMeshAgent agent;
    float stoppingDistance = 0f;


    public WalkNode(NavMeshAgent _agent, Transform _target, float _stoppingDistance)
    {
        agent = _agent;
        target = _target;
        stoppingDistance = _stoppingDistance;
    }

    public override NodeState Evaluate()
    {
        //walk to target 
        agent.SetDestination(target.position);
        //if at target return sucess
        if (agent.remainingDistance < stoppingDistance)
        {
            return NodeState.failure;
            
        }
        return NodeState.success;
        
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }
}
