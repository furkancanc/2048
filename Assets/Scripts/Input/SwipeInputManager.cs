using System;
using UnityEngine;

public class SwipeInputManager : IInputManager
{
    private bool _isSwiping = false;
    private Vector3 _startPosition;
    private const int MinSwipeDistance = 100;
    public InputResult GetInput()
    {
        InputResult result = new InputResult();

        if (!_isSwiping)
        {
            if (Input.GetMouseButton(0))
            {
                _isSwiping = true;
                _startPosition = Input.mousePosition;
            }
        }
        else
        {
            if (!Input.GetMouseButton(0))
            {
                _isSwiping = false;
                Vector3 delta = Input.mousePosition - _startPosition;
                if (delta.magnitude >= MinSwipeDistance)
                {
                    if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
                    {
                        result.XInput = Math.Sign(delta.x);
                    }
                    else
                    {
                        result.YInput = Math.Sign(delta.y);
                    }
                }
            }
        }

        return result;
    }
}