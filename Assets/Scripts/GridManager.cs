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
    private GameObject _board;

    void Start()
    {
        _board = new GameObject("Board");
        _board.transform.SetParent(_canvas);
        RectTransform boardTransform = _board.AddComponent<RectTransform>();
        boardTransform.anchoredPosition = new(0, 0);
        boardTransform.localScale = new(1, 1, 1);
        for (int col = 0; col < _columns; col++)
        {
            for (int row = 0; row < _rows; row++)
            {
                _tiles.Add(generateTile(_tile, boardTransform, col, row));
            }
        }
    }

    private Tile generateTile(Tile tile, RectTransform parent, int column, int row)
    {
        Tile newTile = Instantiate(tile, parent);
        RectTransform tilePosition = newTile.GetComponent<RectTransform>();
        tilePosition.anchoredPosition = new((column * 75) - _offset, (row * 75) - _offset);
        return newTile;
    }
}