using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("God Mode")]
    public bool TestMode;

    [Header("Game Status")]
    public bool GameStarted;
    public bool LevelComplete;
    public bool LevelWin;
    public bool LevelLose;
    public bool IsLastPop;


    [Header("Script References")]
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PlayerCollision _playerCollision;
    [SerializeField] private CoinRotator _spawner;
    [SerializeField] private GameObject _coinSpawner;
    [SerializeField] private AudioManager _audioManager;

    [Header("UI References")]
    [SerializeField] private GameObject _startText;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private Animation _animation;
    [SerializeField] private TMPro.TextMeshProUGUI _myScoretext;
    [SerializeField] private TMPro.TextMeshProUGUI _levelNumberText;

    private int _levelNumber;
    private int _targetScore=1;
    private int _myScore;

    void Start()
    {
        LoadScore();
        //Setting the Level Number
        _levelNumber = _targetScore;
        _levelNumberText.text = "LEVEL " + _levelNumber.ToString();
  
        //Setting the Target Score
        _myScore = _targetScore;
        _myScoretext.text = _targetScore.ToString();

        GameStarted = false;
    }


    void Update(){
        if (GameStarted && _myScore == 0 && !LevelComplete){
            YouWin();
        }

        if (Input.GetKeyDown("space") && LevelComplete){
            ReloadScene();
        }
        LastPopChecker();
    }
    public void StartGame(){
        GameStarted = true;
        _startText.SetActive(false);
        _playerCollision.CanClick = false;
        _spawner.NewCoinPosition();
        _coinSpawner.SetActive(true);
    }

    public void LoseGame(){
        _audioManager.PlayLoseSound();
        GameStarted = false;
        LevelComplete = true;
        LevelLose = true;
        _animation.Play("LoseAnimation");
    }

     void YouWin() {
        _audioManager.PlayWinSound();
        _coinSpawner.SetActive(false);
        _playerController.RotationSpeed = 0;
        _animation.Play("Level Complete");
        LevelComplete = true;
        LevelWin = true;
        _targetScore++;
        SaveScore();
    }

    void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ScoreUpdate(){
        _myScore -= 1;
        _myScoretext.text = _myScore.ToString();
    }


    //Save and Load Level/TargetScore
    void SaveScore() {
        PlayerPrefs.SetInt("myLevel", _targetScore);
    }

    public void LoadScore() {
        int loadedScore = PlayerPrefs.GetInt("myLevel");
        if (loadedScore == 0) {
            loadedScore = 1;
        }
        _targetScore = loadedScore;
    }

    public void LastPopChecker() {
        if (_myScore == 1) IsLastPop=true;

    }
}
