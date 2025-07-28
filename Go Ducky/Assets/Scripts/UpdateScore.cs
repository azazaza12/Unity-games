using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    public Text scoreText;
    private short score = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Knife"))
        {
            score++;
            scoreText.text = "Score: " + score;

            if(PlayerPrefs.GetInt("score") < score)
            {
                PlayerPrefs.SetInt("score", score);
            }
        }
    }
}
