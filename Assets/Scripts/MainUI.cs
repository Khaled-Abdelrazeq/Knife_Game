using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    [SerializeField] private Text healthText;
    [SerializeField] private Text count;
    [SerializeField] private Text ScoreText;
    [SerializeField] private Text tryText;

    private void Update()
    {
        healthText.text = Circle.instance.CircleHealth.ToString();
        count.text = GameManager.instance.count.ToString();
        ScoreText.text = GameManager.instance.score.ToString();
        tryText.text = GameManager.instance.tryNum.ToString();
    }

}
