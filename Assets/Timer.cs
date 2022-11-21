using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    float currentTime;
    public float startingTime = 20000f;
    public string LevelName;
    [SerializeField]
    public int LevelIndex;

    [SerializeField] Text countdownText;
    void Start()
    {
        currentTime = startingTime;
    }
  
    void FixedUpdate()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            SceneManager.LoadScene(LevelName);
        }
        Debug.Log(currentTime);
    }
}

