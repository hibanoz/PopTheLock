using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [Header("Collision Detector")]
    public bool CanClick;
    public bool ShouldClick;
    public bool BoostEnabler;

    [Header("Status References")]
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private BoostManager _boostManager;

    void Start() {
        //Just to not  have a you lose on first click
        CanClick = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin" )
        {
            CanClick = true;
            ShouldClick = true;
            BoostEnabler = false;
            _boostManager.IsCurrentlyBoosted = false;
        }

        if (collision.gameObject.tag == "Booster")
        {
            CanClick = true;
            ShouldClick = true;
            BoostEnabler = true;
            _boostManager.IsCurrentlyBoosted = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Coin" || collision.gameObject.tag == "Booster") && ShouldClick)
        {
            CanClick = false;
            if (!_gameManager.TestMode) {
                _gameManager.LoseGame();
            }

        }
    }
}
