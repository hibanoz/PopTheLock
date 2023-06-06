using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotator : MonoBehaviour
{

    [Header("Normal Angles")]
    [SerializeField] private float _deltaMin = 20;
    [SerializeField] private float _deltaMax = 60;

    [Header("Boosted Angles")]
    [SerializeField] private float _deltaMinBoost = 20;
    [SerializeField] private float _deltaMaxBoost = 60;

    [Header("Script References")]
    [SerializeField] private PlayerController _controller;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private CoinActivator _activator;
    [SerializeField] private BoostManager _boostManager;

    [Header("Starter Coin")]
    public GameObject _coin;

    // Activate the intial Coin
    void Update(){
        if (_gameManager.GameStarted){
            _coin.SetActive(true);
        }
    }
    
    // Set the new coin rotation
    public void NewCoinPosition(){
        if (_controller.RotDirection == PlayerController.Direction.Clockwise) {
            transform.eulerAngles = Vector3.forward * RotationCalculator(-1);
        }

        else {
             transform.eulerAngles = Vector3.forward * RotationCalculator(1);
        }
    }

    // Calculate the coin rotation
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
