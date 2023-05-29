using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    private float _minRotationAngle = 0;
    private float _maxRotationAngle = 360;
    private float _coinAngle;

    [SerializeField] private float Delta = 45;
    [SerializeField] private GameObject _coin;

    // Start is called before the first frame update
    void Start()
    {
        //NewCoinPosition();
    }

    public void NewCoinPosition()
    {
        _coin.SetActive(true);
        _minRotationAngle = transform.eulerAngles.z - Delta;
        _minRotationAngle = transform.eulerAngles.z + Delta;
        _coinAngle = Random.Range(_minRotationAngle, _maxRotationAngle);
        transform.eulerAngles = Vector3.forward * _coinAngle;
    }

}
