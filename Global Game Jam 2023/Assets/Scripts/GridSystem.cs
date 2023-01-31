using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    [SerializeField] List<GameObject> grid = new List<GameObject>();
    [SerializeField] List<Sprite> tileSprites = new List<Sprite>();
    [SerializeField] int mapX;
    [SerializeField] int mapY;
    GameTile tempTile = new GameTile();

    // Start is called before the first frame update
    void Start()
    {   
        int id = 0;
        for (int x = 0; x < mapX; x++)
        {
            for (int y = 0; y < mapY; x++)
            {
                int typeSelector = Random.RandomRange(0, 1);
                
                tempTile.TileType = typeSelector;
                tempTile.mapX = x;
                tempTile.mapY = y;
                grid.Add(new GameObject());
                grid[id].AddComponent<GameTile>();
                grid[id].AddComponent<SpriteRenderer>();

                grid[id].GetComponent<GameTile>().mapX = tempTile.mapX;
                grid[id].GetComponent<GameTile>().mapY = tempTile.mapY;
                grid[id].GetComponent<GameTile>().TileType = tempTile.TileType;

                grid[id].GetComponent<SpriteRenderer>().sprite = tileSprites[typeSelector];


                grid[id].transform.position = new Vector3(tempTile.mapX, tempTile.mapY, 0);
                Instantiate(grid[id]);






                int tilePicked = Random.RandomRange(0, 1);



            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
