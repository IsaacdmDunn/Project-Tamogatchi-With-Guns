using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BaseTreeNode : MonoBehaviour
{
    [SerializeField] GameObject StickPrefab;
    [SerializeField] GameObject LeafPrefab;
    [SerializeField] float scaleDrop =0.2f;
    [SerializeField] int treeDepth = 0;
    [SerializeField] List<Transform> nodes;
    [SerializeField] int nodeCount =0;
    [SerializeField] bool baseNode = false;
    //add somthing for angle and node placement


    // Start is called before the first frame update
    void Start()
    {
        if (baseNode)
        {
            GenerateTree();
        }
        
    }

    void ReduceDepth(float _scaleDrop, int _depth)
    {
        treeDepth = _depth;
        scaleDrop = _scaleDrop;
        GenerateTree();
    }

    void GenerateTree()
    {
        if (treeDepth <= 0)
        {
            
            for (int i = 0; i < nodeCount; i++)
            {
                GameObject Leaf = Instantiate(LeafPrefab, nodes[i].transform.position, nodes[i].transform.rotation);
                Leaf.transform.parent = gameObject.transform;
            }
        }
        else if(treeDepth > 0)
        {
            //make new stick
            for (int i = 0; i < nodeCount; i++)
            {
                GameObject Stick = Instantiate(StickPrefab, nodes[i].transform.position, nodes[i].transform.rotation, this.transform);
                Stick.transform.localScale -= new Vector3 ( scaleDrop, scaleDrop, scaleDrop );
                Stick.GetComponent<BaseTreeNode>().ReduceDepth(scaleDrop + (scaleDrop * scaleDrop), treeDepth-1);
            }
        }
        this.nodes.Clear();
    }
}
