using UnityEngine;
using TMPro; 

public class TimeTracker : MonoBehaviour
{
    private TextMeshProUGUI timeText; 
    private float timeElapsed; 

    private void Awake()
    {
        timeText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        timeElapsed = 0f; 
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        
        int minutes = Mathf.FloorToInt(timeElapsed / 60f);
        int seconds = Mathf.FloorToInt(timeElapsed % 60f);
        
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

