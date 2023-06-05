using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public bool CanClick;
    public bool ShouldClick;
    [SerializeField] private GameManager _gameManager;

    void Start() {
        CanClick = true;
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            CanClick = true;
            ShouldClick = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin" && ShouldClick)
        {
            CanClick = false;
            _gameManager.LoseGame();
        }
    }
}
