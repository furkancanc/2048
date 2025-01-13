using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    private TMP_Text _text;
    private Animator _animator;
    void Start()
    {
        _text = GetComponent<TMP_Text>();
        _animator = GetComponent<Animator>();
    }

    public void UpdateScore(int score)
    {
        _text.text = score.ToString();
        _animator.SetTrigger("ScoreUpdated");
    }
}
