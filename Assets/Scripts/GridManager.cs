using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Tile _tile;
    private List<Tile> _tiles = new List<Tile> { };
    [SerializeField] private RectTransform _canvas;
    [SerializeField] private int _rows;
    [SerializeField] private int _columns;
    [SerializeField] private float _offset = 265;

    // Start is called before the first frame update
    void Start()
    {
        //generateGrid(_tile, _canvas);
        for (int col = 0; col < _columns; col++)
        {
            for (int row = 0; row < _rows; row++)
            {
                _tiles.Add(generateTile(_tile, _canvas, col, row));
            }
        }
    }

    private Tile generateTile(Tile tile, RectTransform canvas, int column, int row)
    {
        Tile newTile = Instantiate(tile, canvas);
        RectTransform tilePosition = newTile.GetComponent<RectTransform>();
        tilePosition.anchoredPosition = new((column * 75) - _offset, (row * 75) - _offset);
        return newTile;
    }
}