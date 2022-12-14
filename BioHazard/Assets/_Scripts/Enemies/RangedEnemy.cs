using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedEnemy : MonoBehaviour
{
    public WalkNode walkNode = null;
    public StopNode stopNode = null;
    public AimNode aimNode = null;
    public Sequence shootSqncNode = null;
    public Node topNode = null;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] GameObject targetCharacter;
    [SerializeField] EnemyAttackRanged gun;
    public float stoppingDistance = 0;
    // Start is called before the first frame update
    void Start()
    {
        ConstructBT();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        topNode.Evaluate();
    }
    void ConstructBT()
    {
        stopNode = new StopNode(agent, targetCharacter.transform, stoppingDistance); //targets player for now
        walkNode = new WalkNode(agent, targetCharacter.transform, stoppingDistance); //targets player for now
        aimNode = new AimNode(this.gameObject.transform, targetCharacter.transform, gun);
        shootSqncNode = new Sequence(new List<Node> { stopNode , aimNode});
        topNode = new Selector(new List<Node> { shootSqncNode, walkNode  });
    }
}
