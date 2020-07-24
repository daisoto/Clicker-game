using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

	public GameObject exitButton, scores, timeLeft, addTime, stripe, gameOver;
	public int scoreNum = 10;
	public float stripeScores = 0;

	Vector2 localScale;
	Transform stripeTransform;
	Text scoresText, timeLeftText;
	int timeLeftInt = 30000;
	float timer = 1000f;

	void ExitGame()
	{
		Application.Quit();
	}

	void Restart()
	{
		SceneManager.LoadScene(0);
	}

	void AddTime()
	{
		GameObject temp = Instantiate(addTime);
		timeLeftInt += 1000;
		Destroy(temp, 1f);
	}

	void EndGameCheck()
	{
		if (timeLeftInt <= 0 || scoreNum <= 0)
        {
        	Time.timeScale = 0;
            gameOver.SetActive(true);
        }
	}
    
    void Start()
    {
        scoresText = scores.GetComponent<Text>();
        timeLeftText = timeLeft.GetComponent<Text>();
    }

    void Update()
    {
        if (Time.time > timer) 
        {
        	timer += 1000f;
            timeLeftInt -= 1000;
        }

        EndGameCheck();

        scoresText.text = "SCORE: " + scoreNum.ToString();
        timeLeftText.text = (timeLeftInt / 1000).ToString();
    }
}
