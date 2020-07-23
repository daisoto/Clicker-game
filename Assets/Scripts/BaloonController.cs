using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonController : MonoBehaviour
{
    public GameObject scores;

    Rigidbody2D rb;
    float speed;
    Color color;
    Transform thisTransform;
    Vector3 currentAngle;

    void GetColor()
    {
        float r = UnityEngine.Random.Range(0f, 1f);
        float g = UnityEngine.Random.Range(0f, 1f);
        float b = UnityEngine.Random.Range(0f, 1f);
        float a = UnityEngine.Random.Range(0f, 1f);

        return Color(r, g, b, a);
    }

    void OnMouseClck()
    {

    }

    void Start()
    {
        GetComponent<SpriteRenderer>().color = GetColor();
    }

    void Update()
    {
        if(Mathf.Abs((thisTransform.eulerAngles - targetAngle).magnitude) < 2f)
    		if (targetAngle.z == 20) 
    			targetAngle = new Vector3(0, 0, 340);
    		else
    			targetAngle = new Vector3(0, 0, 20); 

    	currentAngle = new Vector3(0, 0, Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime * 5));

        thisTransform.eulerAngles = currentAngle; 
    }
}
