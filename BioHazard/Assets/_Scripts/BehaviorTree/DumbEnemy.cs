using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DumbEnemy : MonoBehaviour
{

    public WalkNode walkNode= null;
    public Node topNode = null;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] GameObject targetCharacter;
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
        walkNode = new WalkNode(agent, targetCharacter.transform); //targets player for now
        topNode = new Selector(new List<Node> { walkNode });
    }
}
