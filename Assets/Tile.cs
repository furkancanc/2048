using System;
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

    private Tile _mergeTile;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

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
            if (_mergeTile != null)
            {
                _animator.SetTrigger("Merge");
                SetValue(_value + _mergeTile._value);
                Destroy(_mergeTile.gameObject);
                _mergeTile = null;
            }
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
        if (_mergeTile != null)
        {
            _mergeTile.SetPosition(newPosition, false);
        }
    }

    public bool Merge(Tile otherTile)
    {
        if (this._value != otherTile._value) return false;
        if (_mergeTile != null || otherTile._mergeTile != null) return false;
        _mergeTile = otherTile;

        return true;
    }

    public int GetValue()
    {
        return _value;
    }
}