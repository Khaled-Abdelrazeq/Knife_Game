using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject knifePrefab;
    [SerializeField] private Transform spawnPointKnife;

    [SerializeField] private GameObject CirclePrefab;
    [SerializeField] private Transform spawnPointCircle;

    [SerializeField] private GameObject gameoverPanel;
    [SerializeField] private GameObject explosionPrefab;

    //Count of knifs
    public int count = 0;
    //Player Score
    public int score = 0;
    //Player tries
    public int tryNum = 3;

    public int bestScore;

    public bool isPlayed = true;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        score = PlayerPrefs.GetInt("Score", 0);

    }

    private void Update()
    {
        if (isPlayed)
        {

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                Instantiate(knifePrefab, spawnPointKnife.position, Quaternion.identity);
            }

            if (count >= Circle.instance.CircleHealth)
            {
                // Destroy circle and create another one
                StartCoroutine(initiateCircleCoroutine());
            }
        }
    }

    IEnumerator initiateCircleCoroutine()
    {
        if (Circle.instance.gameObject != null)
        {
            isPlayed = false;
            Destroy(Circle.instance.gameObject);
            Instantiate(explosionPrefab, spawnPointCircle.position, Quaternion.identity);

            // Empty vars            
            count = 0;

            score++;
            PlayerPrefs.SetInt("Score", score);

            bestScore = PlayerPrefs.GetInt("BestScore", 0);
            if(score>= bestScore)
            {
                PlayerPrefs.SetInt("BestScore", score);
            }

            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            int speed = PlayerPrefs.GetInt("Speed", 100);
            int rand = Random.Range(10, 20);
            int randDirection = Random.Range(0, 2) == 0 ? -1 : 1;
            
            PlayerPrefs.SetInt("Speed", (speed + rand) * randDirection);
            isPlayed = true;
        }
    }

    public void Fail()
    {
        isPlayed = false;
        gameoverPanel.SetActive(true);
        Camera.main.GetComponent<Animator>().SetBool("Gameover", true);
        StartCoroutine(waitUntilShowGameoverPanel());
    }

    IEnumerator waitUntilShowGameoverPanel()
    {
        yield return new WaitForSeconds(.5f);
        gameoverPanel.GetComponent<Animator>().SetBool("GameoverPanel", true);
    }

    public void ResetVars()
    {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("Speed", 100);
    }

}
