using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rules/SmallRoot")]
public class SmallRootPlacement : BuildingRule
{
    int id;
    // Start is called before the first frame update
    public override void Rule()
    {
        allTypesAllowed = true;
        for (int y = 1; y < map.mapY-1; y++)
        {
            for (int x = 1; x < map.mapX-1; x++)
            {
                
                id = (y * map.mapY) +x;
                Debug.Log(map.MapTiles.Count);
                if (map.MapTiles[id].GetComponent<GameTile>().BuildingSlot != null)
                {
                    if (map.MapTiles[id].GetComponent<GameTile>().BuildingSlot.name == "Seed")
                    {
                        tilesAllowed.Add(id - map.mapX - 1); //stores map id in tiles allowed
                    }
                }
                foreach (int tileType in allowedTileTypes)
                {
                    
                }
                
                
            }
        }
    }

    
}
