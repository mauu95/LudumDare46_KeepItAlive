using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {
    public static UIManager instance;
    public GameObject MainMenuPanel;
    public GameObject IntroPanel;
    public GameObject GamePanel;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public IntroTextChanger textChanger;

    void Start() {
        if (!instance) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (instance != this)
            Destroy(gameObject);
    }

    public void GoToIntro() {
        MainMenuPanel.SetActive(false);
        IntroPanel.SetActive(true);
        textChanger.Reset();
    }

    public void GoToGame() {
        IntroPanel.SetActive(false);
        GamePanel.SetActive(true);
    }

    public void GoToMainMenu() {
        GamePanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

    public void SetScore(float score) {
        scoreText.text = "Score: " + Mathf.Floor(score);
    }

    public void SetHighscore(float score) {
        highscoreText.text = "Highscore: " + Mathf.Floor(score);
    }

}
