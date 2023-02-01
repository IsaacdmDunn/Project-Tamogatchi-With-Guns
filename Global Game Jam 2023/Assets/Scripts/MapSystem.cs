using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSystem : MonoBehaviour
{
    public IDictionary<int, GameObject> MapTiles = new Dictionary<int, GameObject>();
    public IDictionary<int, GameObject> BuildingTiles = new Dictionary<int, GameObject>();
    public IDictionary<int, GameObject> EffectTiles = new Dictionary<int, GameObject>();
    [SerializeField] List<Sprite> tileSprites;
    [SerializeField] int mapX = 20;
    [SerializeField] int mapY = 20;
    public GameObject prefabTile;
    GameObject MapTile;
    // Start is called before the first frame update
    void Start()
    {
        int id = 0;
        for (int x = 0; x < mapX; x++)
        {
            for (int y = 0; y < mapY; y++)
            {
                int typeSelector = Random.Range(0, 2);

                MapTile = Instantiate(prefabTile, new Vector3(x, y, 0), Quaternion.identity, gameObject.transform);


                MapTiles.Add(id, transform.GetChild(id).gameObject);
                BuildingTiles.Add(id, transform.GetChild(id).gameObject);
                MapTiles[id].GetComponent<GameTile>().TileType = typeSelector;
                MapTiles[id].GetComponent<SpriteRenderer>().sprite = tileSprites[typeSelector];

                Debug.Log(BuildingTiles[id]);
                id++;
            }
        }

        

    }
}
