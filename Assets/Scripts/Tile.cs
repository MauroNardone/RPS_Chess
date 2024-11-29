using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    private Button _button;

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

    private void OnTileClicked()
    {
        Debug.Log("Pressed");
    }
}