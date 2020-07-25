using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BalloonController : MonoBehaviour
{
    public Transform deathZone;
    public float speed;

    GameObject canvas;
    UIManager uIManager;
    Animator anim;
    Color color;
    Transform thisTransform;
    string scoreString;
    int points;
    bool isTouched;
    AudioSource audioSource;

    Color GetColor() 
    {
        float r = UnityEngine.Random.Range(0f, 1f);
        float g = UnityEngine.Random.Range(0f, 1f);
        float b = UnityEngine.Random.Range(0f, 1f);

        return new Color(r, g, b);
    }

    void SetSize()
    {
    	float size = UnityEngine.Random.Range(0.2f, 0.4f);
    	thisTransform.localScale = new Vector2(size, size);
    	points = (int)Math.Round(0.4f / size, 0); // очки за шарик зависят от его размера
    }

    void OnMouseDown() // в случае попадания по шарику
    {
        if (Time.timeScale != 0 && !isTouched) // не работает если игра окончена или уже кликнут
        {
            isTouched = true;
            anim.SetBool("isPopped", true);
            uIManager.scoreNum += points;
            uIManager.FillBar();
            audioSource.Play();
            Destroy(gameObject, 0.5f);
        }
    }

    void EndCheck()
    {
        if (Math.Abs(thisTransform.position.x - deathZone.position.x) <= 1) // попал ли за противоположный край
        {
            uIManager.scoreNum -= points;
            Destroy(gameObject);
        }
    }

    void Start()
    {
    	canvas = GameObject.Find("Canvas");
        thisTransform = transform;
        SetSize();
        isTouched = false;

        uIManager = canvas.GetComponent<UIManager>();
        anim = GetComponent<Animator>();
        Color color = GetColor(); 
        GetComponent<SpriteRenderer>().color = color; // задаем цвет шарику
        audioSource = GetComponent<AudioSource>();        
    }

    void Update()
    {
        EndCheck();
    }
}