using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerp : MonoBehaviour
{
    [Header("Lerp Colors")]
    [SerializeField] private Color _baseColor;
    [SerializeField] private Color _winColor;
    [SerializeField] private Color _loseColor;

    [Header("Lerp Values")]
    float _lerpValue;
    [SerializeField] private float _lerpSpeed=3;

    [SerializeField] private Camera GameCam;
    [SerializeField] private GameManager GameManager;


    void Update(){
        if (GameManager.LevelWin) {
            GameCam.backgroundColor = Color.Lerp(_baseColor, _winColor, _lerpValue += _lerpSpeed * Time.deltaTime);
        }

        if (GameManager.LevelLose){
            GameCam.backgroundColor = Color.Lerp(_baseColor, _loseColor, _lerpValue += _lerpSpeed * Time.deltaTime);
        }

    }
}
