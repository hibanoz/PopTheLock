using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private float _deltaMin = 20;
    [SerializeField] private float _deltaMax = 60;
    [SerializeField] private PlayerController _controller;
    [SerializeField] private GameManager _gameManager;
    public GameObject _coin;

    void Update(){
        if (_gameManager.GameStatus)
        {
            _coin.SetActive(true);
        }
    }

    public void NewCoinPosition(){
        


        if (_controller.RotDirection == PlayerController.Direction.Clockwise) {
            
            transform.eulerAngles = Vector3.forward * RotationCalculator(-1);
        }

        if (_controller.RotDirection == PlayerController.Direction.AntiClockwise)
        {

            transform.eulerAngles = Vector3.forward * RotationCalculator(1);
        }

       

    }


    float RotationCalculator (int moveDir){
        float coinAngle;
        float maxRotationAngle;
        float minRotationAngle;
        minRotationAngle = transform.eulerAngles.z + (_deltaMin* moveDir);
        maxRotationAngle = transform.eulerAngles.z + (_deltaMax* moveDir);
        coinAngle = Random.Range(minRotationAngle, maxRotationAngle);
        Debug.Log(coinAngle);
        return coinAngle;
   
    }
}
