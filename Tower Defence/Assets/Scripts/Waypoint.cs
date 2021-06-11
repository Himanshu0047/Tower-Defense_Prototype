using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    const int gridSize = 10;
    Vector2Int gridPos;
    public bool isExplored = false;
    public bool isPlaceable = true;
    public Waypoint exploredFrom;

    

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(Mathf.RoundToInt(transform.position.x / gridSize),
                              Mathf.RoundToInt(transform.position.z / gridSize));
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    private void OnMouseDown()
    {
        if(isPlaceable)
        {
            FindObjectOfType<TowerFactory>().AddTower(this);
        }
        else
        {
            Debug.Log("Can't place the tower here");
        }
    }

}
