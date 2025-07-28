using System;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private float speed = 3f;
    private float ResetPosition;
    private float width;
    public static double gameDuration;
    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
        ResetPosition = -(width-0.2f);
        
    }

    void Update()
    {
        if(!StartGame.isGameStarted) 
        {
            gameDuration = 0f; 
            return;
        }
        gameDuration += Time.deltaTime;
        speed = (float)Math.Log(0.05 * gameDuration + 1) + 3f;
        
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if(transform.position.x < ResetPosition )
        {
            transform.position += new Vector3( (width -0.2f) * 2, 0, 0);
        }
    }
}
