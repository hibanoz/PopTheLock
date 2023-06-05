using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Speed Controllers")]
    public float RotationSpeed;
    [SerializeField] private float _speedUpRatio;
    private float _currentSpeed;

    [Header("Boost Controllers")]
    [SerializeField] private float _boostRatio = 1;    
    [SerializeField] private bool _boosted = true;
    [SerializeField] private AnimationCurve BoostCurve;


    [Header("Game Controllers")]
    [SerializeField] private PlayerCollision Collision;
    [SerializeField] private CoinSpawner Spawner;
    public Direction RotDirection;
    [SerializeField] private GameManager _gameManager;

    void Update(){
        //////Start Game
        if (_gameManager.GameStatus){
            Rotate();
        }

        //////Gameplay Controls
        if (Input.GetKeyDown("space") && !_gameManager.LevelComplete) {

            if (!_gameManager.GameStatus){
                _gameManager.StartGame();
                return;
            }

            else if (Collision.CanClick){
                Collision.ShouldClick = false;
                Collision.CanClick = false;
                EnumSwitcher();
                _gameManager.ScoreUpdate();
                Spawner.NewCoinPosition();
                RotationSpeed *= (1 + _speedUpRatio);
                _boosted = true;
                return;
            }

            else {
                _gameManager.LoseGame();
            }

            
        }

        if (_boosted)
        {
            StartCoroutine(Boosted());
        }

        _currentSpeed = Time.deltaTime * RotationSpeed * (int)RotDirection * _boostRatio;


    }
    private void Rotate(){
        int _rotationAngle = 1;
        transform.RotateAround(transform.position, transform.forward, Time.deltaTime* RotationSpeed * _rotationAngle * (int)RotDirection * _boostRatio);
    }

    public enum Direction{
        Clockwise =-1, AntiClockwise =1
    }

    private void EnumSwitcher(){

           switch (RotDirection)
            {
            case Direction.Clockwise:

                RotDirection = Direction.AntiClockwise;
                    break;
                
            case Direction.AntiClockwise:
                    RotDirection = Direction.Clockwise;
                    break;
               }
    }

    IEnumerator Boosted() {
        float time = 0;
        float LerpSpeed = 1f;

        while (time < 1){
            _boostRatio = Mathf.Lerp(3f, 1f, BoostCurve.Evaluate(time));
            time += Time.deltaTime * LerpSpeed;
            yield return null;
        }
        if (time >= 1) {
            _boosted = false;
            _boostRatio = 1;
            time = 0;
        }
    }
}
