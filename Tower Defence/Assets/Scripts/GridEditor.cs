using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Waypoint))]
public class GridEditor : MonoBehaviour
{
    public GameObject textMesh;
    Waypoint waypoint;
    TextMesh label;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(waypoint.GetGridPos().x * gridSize, 0f, waypoint.GetGridPos().y * gridSize);
    }

    void UpdateLabel()
    {
        label = textMesh.GetComponent<TextMesh>();
        label.text = waypoint.GetGridPos().y + ", " + waypoint.GetGridPos().x;
        gameObject.name = label.text;
    }

}
