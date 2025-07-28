using System;
using UnityEngine;

public class MoveKnife : MonoBehaviour
{
    
    public float speed = 5f;
        void Update()
    {
        if(!StartGame.isGameStarted) return;
        speed = (float)Math.Log(0.1*MoveBackground.gameDuration + 1)+3;
       
        transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);


        if(transform.position.x <= -7f)
        {
            Destroy(gameObject);
        }
    }
}
