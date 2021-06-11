using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    [SerializeField] Waypoint start, end;
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    Vector2Int[] directions = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };
    bool isRunning = true;

    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            LoadBlocks();
            PathFind();
            CreatePath();
        }
        return path;
    }

    void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach(Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if(grid.ContainsKey(gridPos))
            {
                Debug.Log("Overlapping grid found " + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);
            }
        }
    }

    void ExploreNeighbours(Waypoint searchCentre)
    {
        if(isRunning == false)
        {
            return;
        }
        foreach(Vector2Int direction in directions)
        {
            Vector2Int pos = searchCentre.GetGridPos() + direction;
            if(grid.ContainsKey(pos))
            {
                Waypoint neighbour = grid[pos];
                if (neighbour.isExplored == false && queue.Contains(neighbour) == false)
                {
                    queue.Enqueue(neighbour);
                    neighbour.exploredFrom = searchCentre;
                }
            }

        }
    }

    void PathFind()
    {
        queue.Enqueue(start);
        while(queue.Count > 0)
        {
            var searchCentre = queue.Dequeue();
            if(searchCentre == end)
            {
                isRunning = false;
            }
            ExploreNeighbours(searchCentre);
            searchCentre.isExplored = true;
        }
    }

    void CreatePath()
    {
        path.Add(end);
        end.isPlaceable = false;
        Waypoint previous = end.exploredFrom;
        while(previous != start)
        {
            path.Add(previous);
            previous.isPlaceable = false;
            previous = previous.exploredFrom;
        }
        path.Add(start);
        start.isPlaceable = false;
        path.Reverse();
    }

}
