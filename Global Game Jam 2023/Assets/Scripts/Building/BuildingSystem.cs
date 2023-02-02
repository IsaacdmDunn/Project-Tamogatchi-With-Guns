using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    [SerializeField] public GameObject SelectedBuilding;
    [SerializeField] List<GameObject> buildingTypes = new List<GameObject>();
    [SerializeField] PlayerController player;
    [SerializeField] public BuildingRule ActiveRule;
    [SerializeField] public BuildingRule[] Rules;
    // Start is called before the first frame update
    void Start()
    {
        foreach (SeedPlacement rule in Rules)
        {
            rule.Rule();
        }
       //    Rules = Resources.LoadAll<BuildingRule>("Assets/Rules");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void selectBuilding(int id)
    {
        SelectedBuilding = buildingTypes[id];
        ActiveRule = Rules[id];
        Debug.Log(ActiveRule.tilesAllowed[0]);
    }
}
