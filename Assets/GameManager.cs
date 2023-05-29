using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerController PlayerController;

    public bool GameStatus;
    [SerializeField] private GameObject _startText;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private Animation _winAnimation;
    [SerializeField] private int _targetScore;
    [SerializeField] private TMPro.TextMeshProUGUI _myScoretext;
    private int _myScore = 0;
   

    // Start is called before the first frame update
    void Start()
    {
       GameStatus = false;
       _myScore = 0;
    }

    // Update is called once per frame
    void Update(){

        if (Input.GetKeyDown("space")){
               StartGame();
               }

    if (GameStatus && _myScore == _targetScore){
            YouWin();
            GameStatus = false;
        }
    }

   public void StartGame(){
       GameStatus = true;
        _startText.SetActive(false);
       
    }

    public void LoseGame()
    {
        GameStatus = false;
        _losePanel.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void YouWin() {
        PlayerController._rotationSpeed = 0;
        _winAnimation.Play("Level Complete");

    }

    public void ScoreUpdate()
    {
        _myScore += 1;
        _myScoretext.text = _myScore.ToString();
    }
}
