using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Game Status")]
    public bool GameStatus;
    public bool LevelComplete;
    public bool LevelWin;
    public bool LevelLose;

    [Header("Script References")]
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PlayerCollision _playerCollision;
    [SerializeField] private CoinSpawner _spawner;
    [SerializeField] private GameObject _coinSpawner;

    [Header("UI References")]
    [SerializeField] private GameObject _startText;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private Animation _animation;
    [SerializeField] private TMPro.TextMeshProUGUI _myScoretext;
    [SerializeField] private TMPro.TextMeshProUGUI _levelNumberText;

    [Header("Score & Level Setting")]
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

        GameStatus = false;
    }

    // Update is called once per frame
    void Update(){
        if (GameStatus && _myScore == 0 && !LevelComplete){
            YouWin();
        }

        if (Input.GetKeyDown("space") && LevelComplete){
            ReloadScene();
        }
    }
    public void StartGame(){
        GameStatus = true;
        _startText.SetActive(false);
        _playerCollision.CanClick = false;
        _spawner.NewCoinPosition();
        _coinSpawner.SetActive(true);
    }

    public void LoseGame(){
        GameStatus = false;
        LevelComplete = true;
        LevelLose = true;
        _animation.Play("LoseAnimation");
    }

    void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

     void YouWin() {
        _coinSpawner.SetActive(false);
        _playerController.RotationSpeed = 0;
        _animation.Play("Level Complete");
        LevelComplete = true;
        LevelWin = true;
        _targetScore++;
        SaveScore();
    }

    public void ScoreUpdate(){
        _myScore -= 1;
        _myScoretext.text = _myScore.ToString();
    }

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
}
