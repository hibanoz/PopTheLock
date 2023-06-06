using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Speed Controllers")]
    public float RotationSpeed;
    public float _speedMax = 170;
    private float _speedUpRatio = 0.05f;
    private float _currentSpeed;

    [Header("Game Controllers")]
    [SerializeField] private BoostManager _boostManager;
    [SerializeField] private PlayerCollision _collision;
    [SerializeField] private CoinRotator _spawner;
    [SerializeField] private CoinActivator _activator;
    [SerializeField] private GameManager _gameManager;
    public Direction RotDirection;

    [Header("Juice")]
    [SerializeField] private ParticleSystem _correctFX;


    void Update(){
        //Start rotation when the game status is 
        if (_gameManager.GameStarted){
            Rotate();
        }

        //Gameplay Controls & Inputs
        if (Input.GetKeyDown("space") && !_gameManager.LevelComplete) {

            if (!_gameManager.GameStarted){
                _gameManager.StartGame();
                return;
            }

            else if (_collision.CanClick) {
                CorrectAction();     
                return;
            }

            else {
                if (!_gameManager.TestMode) {
                    _gameManager.LoseGame();
                }
            }   
        }

        //Just to display the current speed
        _currentSpeed = RotationSpeed * _boostManager.BoostRatio;
    }


    private void Rotate(){
        int _rotationAngle = 1;
        transform.RotateAround(transform.position, transform.forward, Time.deltaTime* RotationSpeed * _rotationAngle * (int)RotDirection * _boostManager.BoostRatio);
    }


    //Set the rotation direction 
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

    //Correct Click Behaviour
    private void CorrectAction()
    {
        _collision.ShouldClick = false;
        _collision.CanClick = false;
        EnumSwitcher();
        _gameManager.ScoreUpdate();
        _activator.Activation();
       

        if (RotationSpeed < _speedMax) {
            RotationSpeed *= (1 + _speedUpRatio);
        }

        
        if (_collision.BoostEnabler) {
            _boostManager.IsBoosted = true;
        }
            

        _correctFX.Play();
        _spawner.NewCoinPosition();
    }
}
