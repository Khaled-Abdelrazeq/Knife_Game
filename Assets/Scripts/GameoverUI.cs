using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameoverUI : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text bestScoreText;

    void Update()
    {
        scoreText.text = GameManager.instance.score.ToString();
        bestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
    }

    public void onRestartButtonClicked()
    {
        GameManager.instance.ResetVars();
        Camera.main.GetComponent<Animator>().SetBool("Gameover", false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void onQuitButtonClicked()
    {
        GameManager.instance.ResetVars();
        Application.Quit();        
    }

    
}
