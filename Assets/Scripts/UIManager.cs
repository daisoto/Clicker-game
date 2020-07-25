using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

	public GameObject exitButton, scores, timeLeft, addTime, gameOver, pointsBar, spawn;
	public int scoreNum;

	SpawnManager spawnManager;
	Vector2 localScale;
	Transform thisTransform;
	Text scoresText, timeLeftText;
	int timeLeftInt, timer;
	Image pointsBarImage;
	float currentTime;

	public void FillBar()
	{
        pointsBarImage.fillAmount += 0.2f; // заполняем полосу, всего 5 раз
	}

	public void ExitGame()
	{
		Application.Quit();
	}

	public void RestartGame()
	{
		SceneManager.LoadScene(0);
	}

	public void AddTime()
	{
		GameObject add = Instantiate(addTime, thisTransform);
		timeLeftInt += 3;
		Destroy(add, 0.7f);
	}

	void EndGameCheck()
	{
		if (timeLeftInt <= 0 || scoreNum <= 0)
        {
        	Time.timeScale = 0;
            gameOver.SetActive(true);
        }
	}
 
	void CheckFilled()
	{
		if (pointsBarImage.fillAmount == 1)
		{
            spawnManager.SpawnGift();
            pointsBarImage.fillAmount = 0;
		}
	}
    
    void Start()
    {
        scoresText = scores.GetComponent<Text>();
        timeLeftText = timeLeft.GetComponent<Text>();
        pointsBarImage = pointsBar.GetComponent<Image>(); 
        spawnManager = spawn.GetComponent<SpawnManager>();

        thisTransform = transform;
        Time.timeScale = 1;
        currentTime = 0f;
        scoreNum = 10;
    	timeLeftInt = 30;
    	timer = 1;
    }

    void Update()
    {
    	CheckFilled();

    	currentTime += Time.deltaTime;

        if (currentTime > timer) 
        {
        	timer += 1;
            timeLeftInt -= 1;
        }

        EndGameCheck();

        if (scoreNum < 999)
            scoresText.text = "SCORE: " + scoreNum.ToString();
        else
            scoresText.text = "SCORE: 999";

        if (timeLeftInt < 99)
            timeLeftText.text = timeLeftInt.ToString();
        else
            timeLeftText.text = "99";
    }
}
