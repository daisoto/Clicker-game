using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BaloonController : MonoBehaviour
{
    public GameObject particles;
    public float speed;

    GameObject canvas;
    UIController uIController;
    Rigidbody2D rb;
    Color color;
    Transform thisTransform;
    string scoreString;
    int points;

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

    void Move()
    {
        rb.velocity = new Vector2(speed, 0);
    }

    void OnMouseDown()
    {
        Instantiate(particles);
        uIController.scoreNum += points;
        Destroy(gameObject);
    }

    void Start()
    {
    	canvas = GameObject.Find("Canvas");
        rb = GetComponent<Rigidbody2D>();
        uIController = canvas.GetComponent<UIController>();
        thisTransform = transform;

        GetComponent<SpriteRenderer>().color = GetColor();
        SetSize();
    }

    void Update()
    {
        Move();
    }
}