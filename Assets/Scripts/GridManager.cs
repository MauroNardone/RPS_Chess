using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private int _rows = 8;
    [SerializeField] private int _columns = 8;
    // private Vector3 GlobalGridPosition = new Vector3(11, 11, 0);

    private void Start()
    {
        // GetComponent<Transform>().position = GlobalGridPosition;
        generateGrid();
    }

    private void generateGrid()
    {
        for (int column = 1; column <= _columns; column++)
        {
            for (int row = 1; row <= _rows; row++)
            {
                Vector2 position = new Vector2(column, row);
                Tile newTile = Instantiate(_tilePrefab, position, Quaternion.identity);
                newTile.initialize(new Vector2Int(column, row));
            }
        }
    }
}