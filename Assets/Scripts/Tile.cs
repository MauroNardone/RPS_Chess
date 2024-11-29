using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    private string _gridPosition; // Store the grid position, e.g., "C2"
    private Button _button;  // Reference to the Button component

    void Awake()
    {
        // Get the Button component and set up the click listener
        _button = GetComponent<Button>();
        if (_button != null)
        {
            _button.onClick.AddListener(OnTileClicked);
        }
        else
        {
            Debug.LogError("Button component is missing on this Tile!");
        }
    }

    // Initialize the tile with its grid position
    public void Initialize(string gridPosition)
    {
        _gridPosition = gridPosition;
        gameObject.name = $"Tile {_gridPosition}";  // Optionally set the GameObject name
    }

    // Called when the tile is clicked
    private void OnTileClicked()
    {
        Debug.Log($"Tile clicked at position: {_gridPosition}");
    }
}