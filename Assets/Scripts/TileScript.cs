using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class Tile : MonoBehaviour
{
    public Vector2Int GridPosition { get; set; }
    private bool IsOccupied { get; set; }
    private Vector2 TileSize = new Vector2(1, 1);


    public void initialize(Vector2Int position)
    {
        GridPosition = position;
        IsOccupied = false;
        GetComponent<SpriteRenderer>().color = (position.x + position.y) % 2 == 0 ? Color.black : Color.white;
        GetComponent<SpriteRenderer>().size = TileSize;
    }

    public ChessPosition GetChessPosition(Vector2Int gridPosition)
    {
        return ChessPosition.FromVector(gridPosition);
    }

    private void OnMouseDown()
    {
        Debug.Log($"Tile clicked at position: {GridPosition}");
        Debug.Log($"Chess position at: {GetChessPosition(GridPosition)}");
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
