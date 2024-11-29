using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UIElements;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Tile _tile;  // Tile prefab
    private List<Tile> _tiles = new List<Tile>();  // Generated tiles list
    [SerializeField] private RectTransform _canvas;  // Canvas where to generate tiles
    [SerializeField] private int _rows;  // Number of grid's rows
    [SerializeField] private int _columns; // Number of grid's columns
    [SerializeField] private float _offset = 265;
    [SerializeField] private GameObject _board;  // Empty GameObject to store all tiles

    void Start()
    {
        // Create empty GameObject for board
        GameObject board = GenerateParent.canvasParent(_board, "Board", _canvas);

        // Generate tiles
        for (int col = 0; col < _columns; col++)
        {
            for (int row = 0; row < _rows; row++)
            {
                _tiles.Add(GenerateTile(_tile, board.GetComponent<RectTransform>(), col, row));
            }
        }
    }

    private Tile GenerateTile(Tile tile, RectTransform parent, int column, int row)
    {
        // Instantiate a copy of the tile prefab
        Tile newTile = Instantiate(tile, parent);

        // Calculate grid position
        char columnLetter = (char)('A' + column);  // Convert column index to letter
        string gridPosition = $"{columnLetter}{row + 1}";  // Combine column and row

        // Initialize the tile with its grid position
        newTile.Initialize(gridPosition);

        // Set position in the canvas
        RectTransform tilePosition = newTile.GetComponent<RectTransform>();
        tilePosition.anchoredPosition = new Vector2((column * 75) - _offset, (row * 75) - _offset);

        return newTile;
    }
}