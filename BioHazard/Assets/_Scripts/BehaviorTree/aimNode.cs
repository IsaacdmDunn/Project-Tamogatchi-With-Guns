using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimNode : Node
{
    Transform target;
    Transform agent;
    
    float stoppingDistance = 0f;
    EnemyAttackRanged allowFire;


    public AimNode(Transform _agent, Transform _target, EnemyAttackRanged _allowFire)
    {
        agent = _agent;
        target = _target;
        allowFire = _allowFire;
    }

    public override NodeState Evaluate()
    {
        //rotate towards player
        //agent.Rotate(0, target.transform.rotation.y, 0);
        // Vector3 targetDirection = target.position - allowFire.gameObject.transform.position;
        // Vector3 newDirection = Vector3.RotateTowards(allowFire.gameObject.transform.eulerAngles, targetDirection, 5*Time.deltaTime, 0.0f);
        //agent.transform.LookAt(target);

        Vector3 lookPos = target.position - agent.transform.position;
        lookPos.y = 0;
        agent.transform.rotation = Quaternion.LookRotation(lookPos);

        allowFire.transform.LookAt(target);
        //allowFire.BulletOrigin.LookAt(target);
        //allowFire.BulletOrigin.Rotate(new Vector3( 0,0,1));
        //allowFire.transform.rotation *= Quaternion.FromToRotation(Vector3.left, Vector3.forward);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        //agent.rotation = Quaternion.LookRotation(newDirectionagent);
        //allowFire.gameObject.transform.rotation = Quaternion.LookRotation(newDirection);
        //agent.rotation = Quaternion.LookRotation(newDirectionagent);

        //if aiming at target then success
        //RaycastHit hit;
        allowFire.fireMode = true;
        //if (Physics.Raycast(agent.position, agent.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, 1<<7))
        //{
        //    allowFire.fireMode = false;
        //    Debug.Log("adnwodja");
        //    return NodeState.success;

        //}
        return NodeState.failure;

    }
}
