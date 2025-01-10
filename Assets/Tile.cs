using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Tile : MonoBehaviour
{
    private int _value = 2;
    
    [SerializeField] private TMP_Text text;

    private Vector3 _startPos;
    private Vector3 _endPos;
    private bool _isAnimating;
    private float _count;

    [SerializeField] private TileSettings tileSettings;
    public void SetValue(int value)
    {
        _value = value;
        text.text = value.ToString();
    }

    private void Update()
    {
        if (!_isAnimating) return;
        _count += Time.deltaTime;

        float t = _count / tileSettings.AnimationTime;
        t = tileSettings.AnimationCurve.Evaluate(t);
        
        Vector3 newPos = Vector3.Lerp(_startPos, _endPos, t);

        transform.position = newPos;
        if (_count >= tileSettings.AnimationTime)
        {
            _isAnimating = false;
        }
    }

    public void SetPosition(Vector3 newPosition, bool instant)
    {
        if (instant)
        {
            transform.position = newPosition;
            return;
        }
        
        _startPos = transform.position;
        _endPos = newPosition;
        _count = 0;
        _isAnimating = true;
    }
}
