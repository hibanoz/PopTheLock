using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerp : MonoBehaviour
{

    [SerializeField] private Camera GameCam;
    [SerializeField] private Color _baseColor;
    [SerializeField] private Color _winColor;
    [SerializeField] private Color _loseColor;
    [SerializeField] private float _lerpValue;
    [SerializeField] private float _lerpSpeed=3;
    [SerializeField] private GameManager GameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.LevelWin) {
            GameCam.backgroundColor = Color.Lerp(_baseColor, _winColor, _lerpValue += _lerpSpeed * Time.deltaTime);
        }

        if (GameManager.LevelLose){
            GameCam.backgroundColor = Color.Lerp(_baseColor, _loseColor, _lerpValue += _lerpSpeed * Time.deltaTime);
        }

    }
}
