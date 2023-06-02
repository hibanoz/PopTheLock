using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speedUpRatio;
    [SerializeField] private GameManager _gameManager;

    public PlayerCollision Collision;
    public CoinSpawner Spawner;
    public float RotationSpeed;
    public Direction RotDirection;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){

        if (_gameManager.GameStatus){
            Rotate();
        }

        if (Input.GetKeyDown("space") && !_gameManager.LevelComplete) {

            if (!_gameManager.GameStatus){
                _gameManager.StartGame();
                return;
            }

            else if (Collision.CanClick){
                EnumSwitcher();
                _gameManager.ScoreUpdate();
                Spawner.NewCoinPosition();
                RotationSpeed *= (1 + _speedUpRatio);
                return;
            }

            else{
                _gameManager.LoseGame();
            }
        } 
    }
    void Rotate(){
        int _rotationAngle = 1;
        transform.RotateAround(transform.position, transform.forward, Time.deltaTime* RotationSpeed * _rotationAngle * (int)RotDirection);
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
}
