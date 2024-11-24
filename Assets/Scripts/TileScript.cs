using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector2Int gridPosition { get; set; } // The position on the grid
    private bool _isOccupied { get; set; } // To track if a piece is on this tile

    public void initialize(Vector2Int position)
    {
        gridPosition = position;
        _isOccupied = false;
    }

    private void OnMouseDown()
    {
        Debug.Log($"Tile clicked at position: {gridPosition}");
        // Add selection logic here
    }
}