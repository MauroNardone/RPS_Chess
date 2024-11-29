using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    private Button _button;
    private Vector2 _position;
    private string _stringPosition;

    void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnTileClicked);
        ColorBlock colorBlock = _button.colors;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void getGridPosition(int columns, int rows)
    {
        _position = new(columns, rows);
        _stringPosition = new($"{_position}");
    }

    private void OnTileClicked()
    {
        Debug.Log($"Pressed {_position}");
    }
}