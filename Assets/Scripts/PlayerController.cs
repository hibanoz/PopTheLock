using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Speed Controllers")]
    public float RotationSpeed;
    [SerializeField] private float _speedUpRatio;
    private float _currentSpeed;

    [Header("Game Controllers")]
    [SerializeField] private BoostManager _boostManager;
    [SerializeField] private PlayerCollision _collision;
    [SerializeField] private CoinSpawner _spawner;
    [SerializeField] private CoinActivator _activator;
    public Direction RotDirection;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private ParticleSystem _correctFX;

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

            else if (_collision.CanClick) {
                CorrectAction();     
                return;
            }

            else {
                _gameManager.LoseGame();
            }

            
        }

        _currentSpeed = RotationSpeed * _boostManager.BoostRatio;


    }
    private void Rotate(){
        int _rotationAngle = 1;
        transform.RotateAround(transform.position, transform.forward, Time.deltaTime* RotationSpeed * _rotationAngle * (int)RotDirection * _boostManager.BoostRatio);
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

    private void CorrectAction()
    {
        _collision.ShouldClick = false;
        _collision.CanClick = false;
        EnumSwitcher();
        _gameManager.ScoreUpdate();
        _activator.Activation();
        RotationSpeed *= (1 + _speedUpRatio);
        if (_collision.Boost) {
            _boostManager.IsBoosted = true;
        }
        _correctFX.Play();
        _spawner.NewCoinPosition();
    }
}
