using UnityEngine;

public class RotateCircle : MonoBehaviour
{
    private int rotateSpeed = 100;

    private void Awake()
    {
        if (GameManager.instance != null)
        {
            if (GameManager.instance.isPlayed)
                rotateSpeed = PlayerPrefs.GetInt("Speed", 100);
        }
    }

    void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * rotateSpeed);
    }

    
}
