using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingSystem : MonoBehaviour
{
    [SerializeField] public GameObject SelectedBuilding;
    [SerializeField] List<GameObject> buildingTypes = new List<GameObject>();
    [SerializeField] public PlayerController player;
    [SerializeField] public BuildingRule ActiveRule;
    [SerializeField] public BuildingRule[] Rules;


    [SerializeField] public Text SelectedBuildingTxt;
    [SerializeField] public Text SelectedBuildingCostTxt;
    [SerializeField] public Text SelectedBuildingDescriptionTxt;
    [SerializeField] public Image SelectedBuildingIcon;
    [SerializeField] public GameObject SelectedBuildingUI;

    // Start is called before the first frame update
    void Start()
    {
        foreach (BuildingRule rule in Rules)
        {
            rule.map = player.map;
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
        ActiveRule.Rule();

        SelectedBuildingUI.SetActive(true);
        SelectedBuildingTxt.text = SelectedBuilding.name;
        SelectedBuildingDescriptionTxt.text = ActiveRule.description;
        SelectedBuildingCostTxt.text = "5 Potassium";
        SelectedBuildingIcon.sprite = SelectedBuilding.GetComponent<SpriteRenderer>().sprite;
    }
}
