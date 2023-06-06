using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public bool CanClick;
    public bool ShouldClick;
    public bool Boost;

    [SerializeField] private GameManager _gameManager;
    [SerializeField] private BoostManager _boostManager;

    void Start() {
        CanClick = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin" )
        {
            CanClick = true;
            ShouldClick = true;
            Boost = false;
            _boostManager.IsCurrentlyBoosted = false;
        }

        if (collision.gameObject.tag == "Booster")
        {
            CanClick = true;
            ShouldClick = true;
            Boost = true;
            _boostManager.IsCurrentlyBoosted = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Coin" || collision.gameObject.tag == "Booster") && ShouldClick)
        {
            CanClick = false;
            _gameManager.LoseGame();
        }
    }
}
