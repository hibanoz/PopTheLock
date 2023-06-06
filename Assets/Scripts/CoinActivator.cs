using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinActivator : MonoBehaviour
{
    public  float _randomComparator = 0.2f;
    bool RandomValue
    {
        get { return (Random.value > _randomComparator); }
    }
    private int boostActivationCountDown = 4;

    [Header("Coins Type")]
    [SerializeField] private GameObject _normalCoin;
    [SerializeField] private GameObject _boostedCoin;

    // Coin Flip
    public void Activation()
    {

        if (boostActivationCountDown > 0) {
            boostActivationCountDown -= 1;
            _boostedCoin.SetActive(false);
            _normalCoin.SetActive(true);
        }

        else {
            if (RandomValue) {
                _boostedCoin.SetActive(false);
                _normalCoin.SetActive(true);
                _randomComparator += 0.1f;

            }
            else {
                _boostedCoin.SetActive(true);
                _normalCoin.SetActive(false);
                _randomComparator = 0.2f;
                boostActivationCountDown = 3;
            }
        }
           

    }
}
