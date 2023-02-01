using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] GameObject buildingManager;
    [SerializeField] MapSystem map;
    [SerializeField] BuildingSystem buildingSystem;


    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int y = Mathf.RoundToInt(transform.position.x);
            int x = Mathf.RoundToInt(transform.position.y);
            int id = (y * map.mapY) + x;
            if (map.MapTiles[id].GetComponent<GameTile>().BuildingSlot == null)
            {
                GameObject newBuidling = Instantiate(buildingSystem.SelectedBuilding, new Vector3(y, x, 0), Quaternion.identity, buildingManager.transform);
                newBuidling.name = $"{buildingSystem.SelectedBuilding.name}: X{x}Y{y}";

                map.MapTiles[id].GetComponent<GameTile>().BuildingSlot = newBuidling;
            }

           
        }
    }

    
}
