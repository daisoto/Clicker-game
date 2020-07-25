using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftController : MonoBehaviour
{
	public GameObject canvas;
    UIManager uIManager;
    AudioSource audioSource;
    Animator anim;
    bool isTouched;

    void OnMouseDown() // в случае попадания по подарку
    {
        if (Time.timeScale != 0 && !isTouched) // не работает если игра окончена или уже кликнут
        {
        	isTouched = true;
            anim.SetBool("isTaken", true);
            uIManager.AddTime();
            audioSource.Play();
            Destroy(gameObject, 0.5f);
        }
    }

    void Start()
    {
    	canvas = GameObject.Find("Canvas");
        uIManager = canvas.GetComponent<UIManager>();
        audioSource = GetComponent<AudioSource>(); 
        anim = GetComponent<Animator>();

        isTouched = false;
    }

    void Update()
    {
        
    }
}
