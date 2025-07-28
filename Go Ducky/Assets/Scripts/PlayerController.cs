using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 targetPos;
    public float speed = 5f;

    void Update()
    {
        if(!StartGame.isGameStarted) return;
        
        speed = (float)Math.Log(0.8 * MoveBackground.gameDuration+1) + 5f;
        
#if UNITY_EDITOR
        if(Input.GetMouseButton(0))
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
#else
        if(Input.touchCount >0)
        {
            Touch touch= Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                targetPos = Camera.main.ScreenToWorldPoint(touch.position);
            }
        }
#endif
        float step = speed * Time.deltaTime;
        targetPos.y = Math.Clamp(targetPos.y, -3.1f, 1.68f);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, targetPos.y, transform.position.z), step);
        
    }
}
