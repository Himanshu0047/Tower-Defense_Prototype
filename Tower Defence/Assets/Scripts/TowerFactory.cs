using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower tower;
    [SerializeField] int towerLimit = 3;
    float waypointHeight = 10f;
    Queue<Tower> towers = new Queue<Tower>();


    public void AddTower(Waypoint waypoint)
    {
        Vector3 towerPosition = new Vector3(waypoint.transform.position.x, waypoint.transform.position.y + waypointHeight, waypoint.transform.position.z);
        if (towers.Count < towerLimit)
        {
            // Place new tower
            var towerClone = Instantiate(tower, towerPosition, tower.transform.rotation, GameObject.Find("Towers").transform);
            waypoint.isPlaceable = false;
            towers.Enqueue(towerClone);
            towerClone.baseWaypoint = waypoint;
        }
        else
        {
            // Replace oldest tower
            var lastTower = towers.Dequeue();
            towers.Enqueue(lastTower);
            lastTower.transform.position = towerPosition;
            lastTower.baseWaypoint.isPlaceable = true;
            waypoint.isPlaceable = false;
            lastTower.baseWaypoint = waypoint;
        }
    }

}
