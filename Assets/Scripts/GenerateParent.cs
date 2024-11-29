using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GenerateParent : MonoBehaviour
{
    public static RectTransform canvasParent(GameObject gameObject, string name, RectTransform canvas)
    {
        gameObject = new GameObject($"{name}");
        gameObject.transform.SetParent(canvas);
        RectTransform boardTransform = gameObject.AddComponent<RectTransform>();
        boardTransform.anchoredPosition = new(0, 0);
        boardTransform.localScale = new(1, 1, 1);
        return boardTransform;
    }
}