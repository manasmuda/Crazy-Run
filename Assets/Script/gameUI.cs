using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameUI : MonoBehaviour {

    public Text pauseText, scoreText,levelText;
    public CanvasGroup levelImage,nextLevelImage;
    public static bool gameActiveState = false;
    public GameObject StartButton, RestartButton, QuitButton, PauseButton;
    public Button NextLevelButton;
    public string nextlevelName;
    public int boundaryScore;

    // Use this for initialization
    void Start () {
        RestartButton.SetActive(false);
        PauseButton.SetActive(false);
        NextLevelButton.onClick.AddListener(startNextLevel);
        hide(nextLevelImage);
        Input.multiTouchEnabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            gameActiveStateSwitch();
        }
        updateScore();
    }

    public void startNextLevel()
    {
        SceneManager.LoadScene(nextlevelName);
    }

    public void gameActiveStateSwitch()
    {
        if(gameActiveState)
        {
            gameActiveState = false;
            pauseText.text = "Return";
            RestartButton.SetActive(true);
            QuitButton.SetActive(true);
        }
        else if (!gameActiveState)
        {
            gameActiveState = true;
            pauseText.text = "Pause";
            RestartButton.SetActive(false);
            QuitButton.SetActive(false);
        }
    }

    public void gameStart()
    {
        StartButton.SetActive(false);
        QuitButton.SetActive(false);
        gameActiveState = true;
        PauseButton.SetActive(true);
        hide(nextLevelImage);
        hide(levelImage);
    }

    public void gameEnd()
    {
        StartButton.SetActive(false);
        RestartButton.SetActive(true);
        QuitButton.SetActive(true);
        gameActiveState = false;
        PauseButton.SetActive(false);
        if (((int)(GameObject.FindWithTag("Player").transform.position.z - 18) / 10) >= boundaryScore)
        {
            show(nextLevelImage);
        }
    }

    public void gameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameQuit()
    {
        Application.Quit();
    }

    public void updateScore()
    {
        scoreText.text = "Score:" + ((int)(GameObject.FindWithTag("Player").transform.position.z - 18) / 10);
    }
    public void hide(CanvasGroup x)
    {
        x.alpha = 0;
        x.blocksRaycasts = false;
    }

    public void show(CanvasGroup x)
    {
        x.alpha = 1;
        x.blocksRaycasts = true;
    }
}
