using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTile : MonoBehaviour
{
    public int TileType;
    public int mapX;
    public int mapY;
    public string tileName;
    [SerializeField] public GameObject cursor;
    [SerializeField] public GameObject BuildingSlot;
    [SerializeField] public GameObject EffectSlot;

    private void Start()
    {
        mapX = Mathf.RoundToInt(gameObject.transform.position.x);
        mapY = Mathf.RoundToInt(gameObject.transform.position.y);

        switch (TileType)
        {
            case 0:
                tileName = "Dirt";
                break;
            case 1:
                tileName = "Sandy Loam";
                break;
        }
    }

    public void OnMouseEnter()
    {
        cursor.transform.position = new Vector3(mapX, mapY, 1);
        cursor.GetComponent<TileDescription>().onUpdate = true;
    }

}
