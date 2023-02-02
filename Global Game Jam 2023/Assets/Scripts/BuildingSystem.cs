using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    [SerializeField] public GameObject SelectedBuilding;
    [SerializeField] List<GameObject> buildingTypes = new List<GameObject>();
    [SerializeField] PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void selectBuilding(int id)
    {
        SelectedBuilding = buildingTypes[id];
    }
}
