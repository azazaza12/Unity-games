using UnityEngine;
using UnityEngine.UI;

public class SetBestScore : MonoBehaviour
{
    void Awake()
    {
        GetComponent<Text>().text = "Record: " + PlayerPrefs.GetInt("score");
    }
}
