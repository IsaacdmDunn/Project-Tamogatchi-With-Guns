using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuildingRule : ScriptableObject
{
    [SerializeField] public string description = "This building can be placed anywhere";
    [SerializeField] public int[] allowedTileTypes;
    [SerializeField] public bool allTypesAllowed = false;
    [SerializeField] public List<int> tilesAllowed = new List<int>();
    [SerializeField] public bool allTilesAllowed = false;

    [SerializeField] public MapSystem map;

    public virtual void Rule() { }
    
}
