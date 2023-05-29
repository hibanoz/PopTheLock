using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    private float _minRotationAngle = 0;
    private float _maxRotationAngle = 360;
    private float _coinAngle;

    [SerializeField] private float _deltaMin = 20;
    [SerializeField] private float _deltaMax = 60;
    [SerializeField] private PlayerController Controller;
    [SerializeField] private GameManager GameManager;
    public GameObject _coin;

    // Start is called before the first frame update
    void Start()
    {
        //NewCoinPosition();
    }

    void Update()
    {
        if (GameManager.GameStatus)
        {
            _coin.SetActive(true);
        }
    }

    public void NewCoinPosition()
    {

        if (Controller._direction == PlayerController.Direction.Clockwise)
        {
            _minRotationAngle = transform.eulerAngles.z - _deltaMin;
            _maxRotationAngle = transform.eulerAngles.z - _deltaMax;
            _coinAngle = Random.Range(_minRotationAngle, _maxRotationAngle);
            transform.eulerAngles = Vector3.forward * _coinAngle;
            Debug.Log("ActualPosition : " + transform.eulerAngles.z + "NearestAngle : " + _minRotationAngle + "FurtherstAngle : " + _maxRotationAngle);
        }

        if (Controller._direction == PlayerController.Direction.AntiClockwise)
        {
            _minRotationAngle = transform.eulerAngles.z + _deltaMin;
            _maxRotationAngle = transform.eulerAngles.z + _deltaMax;
            _coinAngle = Random.Range(_minRotationAngle, _maxRotationAngle);
            transform.eulerAngles = Vector3.forward * _coinAngle;
            Debug.Log("ActualPosition : "+ transform.eulerAngles.z + "NearestAngle : " +_minRotationAngle + "FurtherstAngle : " + _maxRotationAngle);
        }

    }

}
