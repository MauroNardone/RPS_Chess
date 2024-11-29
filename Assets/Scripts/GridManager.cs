using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UIElements;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Tile _tile;
    private List<Tile> _tiles = new List<Tile> { };
    private List<Tile> _movementTiles = new List<Tile> { };
    [SerializeField] private RectTransform _canvas;
    [SerializeField] private int _rows;
    [SerializeField] private int _columns;
    [SerializeField] private float _offset = 265;
    private GameObject _board;
    private GameObject _movementBoard;

    void Start()
    {
        GameObject board = GenerateParent.canvasParent(_board, "Board", _canvas);
        for (int col = 0; col < _columns; col++)
        {
            for (int row = 0; row < _rows; row++)
            {
                _tiles.Add(generateTile(_tile, board.GetComponent<RectTransform>(), col, row));
            }
        }
        GameObject movementBoard = GenerateParent.canvasParent(_movementBoard, "MovementBoard", _canvas);
        for (int col = 0; col < _columns; col++)
        {
            for (int row = 0; row < _rows; row++)
            {
                _movementTiles.Add(generateTile(_tile, movementBoard.GetComponent<RectTransform>(), col, row));
            }
        }
        movementBoard.SetActive(false);
    }

    private Tile generateTile(Tile tile, RectTransform parent, int column, int row)
    {
        Tile newTile = Instantiate(tile, parent);
        RectTransform tilePosition = newTile.GetComponent<RectTransform>();
        tilePosition.anchoredPosition = new((column * 75) - _offset, (row * 75) - _offset);
        return newTile;
    }
}