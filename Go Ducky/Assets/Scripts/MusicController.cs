using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class MusicController : MonoBehaviour
{
    public AudioListener audioListener;

    public Sprite MusicOn, MusicOff;
    private Image buttonImage;


    void Awake()
    {
        buttonImage = GetComponent<Image>();
        if(PlayerPrefs.GetString("music") == "off")
        {
            buttonImage.sprite = MusicOff;
            audioListener.enabled = false;
        }
    }

    public void ToggleMusic()
    {
        audioListener.enabled = !audioListener.enabled;
        string musicInfo = audioListener.enabled ? "on" : "off";
        PlayerPrefs.SetString("music", musicInfo);

        if(audioListener.enabled)
        {
            buttonImage.sprite = MusicOn;
        }
        else
        {
            buttonImage.sprite = MusicOff;
        }
    }
}
