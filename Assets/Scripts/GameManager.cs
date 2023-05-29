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
    [SerializeField] private Animation _animation;
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

        if (Input.GetKeyDown("space") && LevelComplete){
            ReloadScene();
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
        _animation.Play("LoseAnimation");
    }

    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void YouWin() {
        _spawner._coin.SetActive(false);
        PlayerController._rotationSpeed = 0;
        _animation.Play("Level Complete");
        LevelComplete = true;
        LevelWin = true;
    }

    public void ScoreUpdate(){
        _myScore -= 1;
        _myScoretext.text = _myScore.ToString();
    }
}
