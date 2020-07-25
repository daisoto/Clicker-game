using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public GameObject balloon, gift, leftPlace, rightPlace;
    public Sprite giftSprite1, giftSprite2, giftSprite3, giftSprite4;

	float balloonSpawnTime, currentTime;
	Transform leftPlaceTransform, rightPlaceTransform;
	int where;
    SpriteRenderer giftSpriteRenderer;

    public void SpawnGift()
    {
        float x = UnityEngine.Random.Range(leftPlaceTransform.position.x + 2.1f, 
                                           rightPlaceTransform.position.x - 2.1f); // порождение в разных горизонтальных точках 
        float y = UnityEngine.Random.Range(-3f, 3f); // порождение в разных вертикальных точках 

        int numSprite = UnityEngine.Random.Range(0, 4);

        GameObject g = Instantiate(gift);
        g.transform.position = new Vector3(x, y, 1);
        giftSpriteRenderer = g.GetComponent<SpriteRenderer>();

        switch (numSprite)
        {
            case 0:
                giftSpriteRenderer.sprite = giftSprite1;
                break;
            case 1:
                giftSpriteRenderer.sprite = giftSprite2;
                break;
            case 2:
                giftSpriteRenderer.sprite = giftSprite3;
                break;
            case 3:
                giftSpriteRenderer.sprite = giftSprite4;
                break;
        }
    }

	Vector2 GetSpeed(int move) // move - направление движения (1 - вправо, -1 - влево)
	{
		int speed = UnityEngine.Random.Range(4, 8);
		return new Vector2 (move * speed, 0);
	}

	void SpawnBalloon(Transform placeT, Transform deathZone, int m)
	{
		GameObject bal = Instantiate(balloon, placeT); // создаем шарик в нужном месте
		bal.name = "Balloon";
		bal.GetComponent<Rigidbody2D>().velocity = GetSpeed(m); // задаем скорость
		bal.GetComponent<BalloonController>().deathZone = deathZone; // отмечаем конечное место

		float y = UnityEngine.Random.Range(-3f, 3f); // порождение в разных вертикальных точках 

		bal.transform.position = new Vector3(placeT.position.x, y, 1);
	}

    void Start()
    {
    	leftPlaceTransform = leftPlace.transform;
    	rightPlaceTransform = rightPlace.transform;

    	currentTime = 0;
    	balloonSpawnTime = UnityEngine.Random.Range(0.5f, 1.5f);
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= balloonSpawnTime) // создаем новый шарик в случайное время
        {
        	where = UnityEngine.Random.Range(0, 2);
        	if (where == 0)
        	    SpawnBalloon(leftPlaceTransform, rightPlaceTransform, 1);
        	else
        	    SpawnBalloon(rightPlaceTransform, leftPlaceTransform, -1);

        	currentTime = 0; // обнуляем таймер
        	balloonSpawnTime = UnityEngine.Random.Range(0.6f, 1.5f); // назначаем новое случайное время
        } 
    }
}
