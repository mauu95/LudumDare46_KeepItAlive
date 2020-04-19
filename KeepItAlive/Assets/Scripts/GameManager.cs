using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public bool isPlaying;
    private float highScore = 0;
    private float currentScore = 0;


    void Start() {
        if (!instance) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update() {
        if (isPlaying) {
            currentScore += Time.deltaTime;
            UIManager.instance.SetScore(currentScore);
        }
    }

    public void StartGameButtonPressed() {
        SceneManager.LoadScene("Intro");
        UIManager.instance.GoToIntro();
    }

    public void IntroFinished() {
        currentScore = 0;
        SceneManager.LoadScene("GameScene");
        UIManager.instance.GoToGame();
        isPlaying = true;
        AudioManager.instance.PlayMusic();
    }

    public void EndGame() {
        isPlaying = false;
        AudioManager.instance.StopMusic();
        if (currentScore > highScore) {
            highScore = currentScore;
            UIManager.instance.SetHighscore(highScore);
        }
        SceneManager.LoadScene("MainMenu");
        UIManager.instance.GoToMainMenu();

    }
}
