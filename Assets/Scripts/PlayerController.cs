using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private int _rotationAngle = 1;
    [SerializeField] private float _speedUpRatio;
    [SerializeField] private GameManager GameManager;

    public PlayerCollision Collision;
    public CoinSpawner Spawner;
    public float _rotationSpeed;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){

        if (GameManager.GameStatus){
            Rotate();
        }

        if (Input.GetKeyDown("space") && !GameManager.LevelComplete) {

            if (!GameManager.GameStatus){
                GameManager.StartGame();
                return;
            }

            else if (Collision.CanClick){
                _rotationAngle = _rotationAngle * -1;
                GameManager.ScoreUpdate();
                Spawner.NewCoinPosition();
                _rotationSpeed = _rotationSpeed * (1 + _speedUpRatio);
                return;
            }

            else{
                GameManager.LoseGame();
            }
        } 
    }
    public void Rotate(){
        transform.RotateAround(transform.position, transform.forward, Time.deltaTime* _rotationSpeed * _rotationAngle);
    }

}
