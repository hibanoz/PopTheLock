using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinActivator : MonoBehaviour
{
    float _randomComparator = 0.2f;
    bool RandomValue
    {
        get { return (Random.value > _randomComparator); }
    }

    [SerializeField] private GameObject _normalCoin;
    [SerializeField] private GameObject _boostedCoin;



    public void Activation()
    {
        if (RandomValue)
        {
            _boostedCoin.SetActive(false);
            _normalCoin.SetActive(true);
            _randomComparator += 0.1f;

        }
        else
        {
            _boostedCoin.SetActive(true);
            _normalCoin.SetActive(false);
            _randomComparator = 0.2f;
        }

    }
}
