using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool GameStatus;
    public bool LevelComplete;
    public bool LevelWin;
    public bool LevelLose;

    [SerializeField] private PlayerController PlayerController;
    [SerializeField] private PlayerCollision PlayerCollision;
    [SerializeField] private CoinSpawner _spawner;
    [SerializeField] private GameObject _startText;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private Animation _winAnimation;
    [SerializeField] private int _targetScore;
    [SerializeField] private TMPro.TextMeshProUGUI _myScoretext;


    private int _myScore;


    // Start is called before the first frame update
    void Start()
    {
       GameStatus = false;
       _myScore = _targetScore;
       _myScoretext.text = _targetScore.ToString();
    }

    // Update is called once per frame
    void Update(){
        if (GameStatus && _myScore == 0 && !LevelComplete){
            YouWin();
        }
    }

   public void StartGame(){
        GameStatus = true;
        _startText.SetActive(false);
        PlayerCollision.CanClick = false;
        _spawner.NewCoinPosition();
    }

    public void LoseGame(){
        GameStatus = false;
        //_losePanel.SetActive(true);
        LevelComplete = true;
        LevelLose = true;
    }

    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void YouWin() {
        PlayerController._rotationSpeed = 0;
        _winAnimation.Play("Level Complete");
        LevelComplete = true;
        LevelWin = true;
    }

    public void ScoreUpdate(){
        _myScore -= 1;
        _myScoretext.text = _myScore.ToString();
    }
}
