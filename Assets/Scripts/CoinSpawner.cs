using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private float _deltaMin = 20;
    [SerializeField] private float _deltaMax = 60;
    [SerializeField] private float _deltaMinBoost = 20;
    [SerializeField] private float _deltaMaxBoost = 60;
    [SerializeField] private PlayerController _controller;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private CoinActivator _activator;
    [SerializeField] private BoostManager _boostManager;
    public GameObject _coin;

     void Start(){
        if (_gameManager.GameStatus)
        {
            _activator.Activation();
        }
    }
    void Update(){
        if (_gameManager.GameStatus){
            _coin.SetActive(true);
        }
    }
    public void NewCoinPosition(){
        if (_controller.RotDirection == PlayerController.Direction.Clockwise) {
            transform.eulerAngles = Vector3.forward * RotationCalculator(-1);
        }

        else {
             transform.eulerAngles = Vector3.forward * RotationCalculator(1);
        }
    }

    float RotationCalculator(int moveDir)
    {
        float coinAngle;
        float maxRotationAngle;
        float minRotationAngle;
          if (!_boostManager.IsCurrentlyBoosted){
              minRotationAngle = transform.eulerAngles.z + (_deltaMin * moveDir);
              maxRotationAngle = transform.eulerAngles.z + (_deltaMax * moveDir);
        }

          else {
              minRotationAngle = transform.eulerAngles.z + (_deltaMinBoost * moveDir);
              maxRotationAngle = transform.eulerAngles.z + (_deltaMaxBoost * moveDir);
        }
        coinAngle = Random.Range(minRotationAngle, maxRotationAngle);
        return coinAngle;
    }
}
