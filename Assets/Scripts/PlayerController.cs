using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speedUpRatio;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private float _boostRatio = 1;

    public PlayerCollision Collision;
    public CoinSpawner Spawner;
    public float RotationSpeed;
    public Direction RotDirection;
    public AnimationCurve BoostCurve;

    private void Start()
    {
        Boosted();
        

    }
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
                Collision.ShouldClick = false;
                Collision.CanClick = false;
                EnumSwitcher();
                _gameManager.ScoreUpdate();
                Spawner.NewCoinPosition();
                RotationSpeed *= (1 + _speedUpRatio);
                
                return;
            }

            else {
                _gameManager.LoseGame();
            }

            
        }
    }
    private void Rotate(){
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

    IEnumerator Boosted() {
        float time = 0;
        float LerpSpeed = 1;

        while (time < 1){
            _boostRatio = Mathf.Lerp(2f, 1f, BoostCurve.Evaluate(time));
            time += Time.deltaTime * LerpSpeed;
            Debug.Log(_boostRatio);
            Debug.Log(time);
            yield return null;

           
        }


    }
}
