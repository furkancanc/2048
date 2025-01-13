using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private TMP_Text _text;
    private string format = "";
    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    public void UpdateTimer(TimeSpan gameTime)
    {
        format = gameTime.Hours > 0 ? @"h\:mm\:ss" : "mm\\:ss";
        _text.text = gameTime.ToString(format);
    }
}
