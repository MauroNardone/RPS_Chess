using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UIElements;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Tile _tile;  //Tile prefab
    private List<Tile> _tiles = new List<Tile> { };  //Generated tiles list
    private List<Tile> _movementTiles = new List<Tile> { }; //Generated movement tiles list
    [SerializeField] private RectTransform _canvas;  //Canvas where to generate tiles
    [SerializeField] private int _rows;  //Number of grid's rows
    [SerializeField] private int _columns; //Number of grid's columns
    [SerializeField] private float _offset = 265;
    private GameObject _board;  //Empty gameobject where to store all tiles
    private GameObject _movementBoard; //Empty gameobject where to store all movement tiles

    void Start()
    {
        //Create empty gameobjects
        GameObject board = GenerateParent.canvasParent(_board, "Board", _canvas);
        GameObject movementBoard = GenerateParent.canvasParent(_movementBoard, "MovementBoard", _canvas);

        //Generate tiles
        for (int col = 0; col < _columns; col++)
        {
            for (int row = 0; row < _rows; row++)
            {
                _tiles.Add(generateTile(_tile, board.GetComponent<RectTransform>(), col, row, movementBoard));
            }
        }
        //Generate moving tiles
        for (int col = 0; col < _columns; col++)
        {
            for (int row = 0; row < _rows; row++)
            {
                _movementTiles.Add(generateTile(_tile, movementBoard.GetComponent<RectTransform>(), col, row, movementBoard));
            }
        }
        movementBoard.SetActive(false); //Deactivate movementBoard
    }

    private Tile generateTile(Tile tile, RectTransform parent, int column, int row, GameObject movementBoard)
    {
        Tile newTile = Instantiate(tile, parent); //Instantiate a copy of the tile prefab
        RectTransform tilePosition = newTile.GetComponent<RectTransform>(); //Get RectTransform component
        tilePosition.anchoredPosition = new((column * 75) - _offset, (row * 75) - _offset); //Set position in canvas
        Tile tileScript = newTile.GetComponent<Tile>(); //Get tile.cs component
        tileScript.getMovingBoard(movementBoard); //Assign movementBoard gameobject to tile
        return newTile;
    }
}