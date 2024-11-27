using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using System.Net.Http.Headers;

public class Tile : MonoBehaviour
{
    public Vector2Int GridPosition { get; set; }
    private bool IsOccupied { get; set; }
    private Vector2 TileSize { get; set; }
    private Vector2 DefaultTileSize { get; set; }
    //private bool OnMouseDownIsHappening = false;

    public void initialize(Vector2Int position)
    {
        GridPosition = position;
        IsOccupied = false;
        GetComponent<SpriteRenderer>().color = (position.x + position.y) % 2 == 0 ? Color.black : Color.white;
        DefaultTileSize = GetComponent<SpriteRenderer>().size;
        TileSize = DefaultTileSize;
    }

    public ChessPosition GetChessPosition(Vector2Int gridPosition)
    {
        return ChessPosition.FromVector(gridPosition);
    }

    private void OnMouseDown()
    {
        //OnMouseDownIsHappening = true;
        Debug.Log($"Tile clicked at position: {GridPosition}");
        Debug.Log($"Chess position at: {GetChessPosition(GridPosition)}");
        TileSize = DefaultTileSize;
    }

    private void OnMouseUp()
    {
        TileSize = new Vector2(1, 1);
    }

    private void OnMouseEnter()
    {
        TileSize = new Vector2(1, 1);
    }

    private void OnMouseExit()
    {
        TileSize = DefaultTileSize;
    }

    void Update()
    {
        GetComponent<SpriteRenderer>().size = TileSize;
    }
}

public class ChessPosition
{
    public char Row { get; set; }

    public int Column { get; set; }

    public ChessPosition(char row, int column)
    {
        if (row < 'A' || row > 'H')
            throw new ArgumentException("Row must be between A and H.");
        if (column < 1 || column > 8)
            throw new ArgumentException("Column must be between 1 and 8.");

        Column = column;
        Row = row;
    }
    public override string ToString()
    {
        return $"{Row}{Column}";
    }

    private static char IntToString(int number)
    {
        Dictionary<int, char> NumberToLetterMap = new Dictionary<int, char>
        {
            { 1, 'A' },
            { 2, 'B' },
            { 3, 'C' },
            { 4, 'D' },
            { 5, 'E' },
            { 6, 'F' },
            { 7, 'G' },
            { 8, 'H' }
        };
        return NumberToLetterMap[number];
    }

    public static ChessPosition FromVector(Vector2Int gridPosition)
    {
        return new ChessPosition(IntToString(gridPosition.x), gridPosition.y);
    }
}