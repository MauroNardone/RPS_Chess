using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Tile _tilePrefab; // Assign your Tile prefab here
    [SerializeField] private int _gridWidth = 8;
    [SerializeField] private int _gridHeight = 8;

    private void Start()
    {
        generateGrid();
    }

    private void generateGrid()
    {
        for (int x = 0; x < _gridWidth; x++)
        {
            for (int y = 0; y < _gridHeight; y++)
            {
                Vector2 position = new Vector2(x, y);
                Tile newTile = Instantiate(_tilePrefab, position, Quaternion.identity);
                newTile.initialize(new Vector2Int(x, y));
            }
        }
    }
}