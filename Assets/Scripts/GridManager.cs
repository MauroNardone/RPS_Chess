using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UIElements;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Tile _tile;  //Tile prefab
    private List<Tile> _tiles = new List<Tile> { };  //Generated tiles list
    [SerializeField] private RectTransform _canvas;  //Canvas where to generate tiles
    [SerializeField] private int _rows;  //Number of grid's rows
    [SerializeField] private int _columns; //Number of grid's columns
    [SerializeField] private float _offset = 265;
    private GameObject _board;  //Empty gameobject where to store all tiles

    void Start()
    {
        //Create empty gameobjects
        GameObject board = GenerateParent.canvasParent(_board, "Board", _canvas);

        //Generate tiles
        for (int col = 0; col < _columns; col++)
        {
            for (int row = 0; row < _rows; row++)
            {
                _tiles.Add(generateTile(_tile, board.GetComponent<RectTransform>(), col, row));
            }
        }
    }

    private Tile generateTile(Tile tile, RectTransform parent, int column, int row)
    {
        Tile newTile = Instantiate(tile, parent); //Instantiate a copy of the tile prefab
        newTile.getGridPosition(column, row);
        RectTransform tilePosition = newTile.GetComponent<RectTransform>(); //Get RectTransform component
        tilePosition.anchoredPosition = new((column * 75) - _offset, (row * 75) - _offset); //Set position in canvas
        return newTile;
    }
}