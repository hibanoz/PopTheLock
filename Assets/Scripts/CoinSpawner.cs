using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    private float _minRotationAngle = 0;
    private float _maxRotationAngle = 360;
    [SerializeField] private float Delta = 45;
    private float _coinAngle;

    // Start is called before the first frame update
    void Start()
    {
        NewCoinPosition();
    }

    public void NewCoinPosition()
    {
        _minRotationAngle = transform.eulerAngles.z - Delta;
        _minRotationAngle = transform.eulerAngles.z + Delta;
        //print(_minRotationAngle + " , " + _minRotationAngle) ;
        _coinAngle = Random.Range(_minRotationAngle, _maxRotationAngle);
        transform.eulerAngles = Vector3.forward * _coinAngle;
    }

}
