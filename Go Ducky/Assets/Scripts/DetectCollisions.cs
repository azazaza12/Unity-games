using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public Color deathColor;
    private SpriteRenderer _spriterenderer;
    public GameObject explosion, panelLose;
    private AudioSource _audioLose;
    void Awake()
    {
        _spriterenderer = GetComponent<SpriteRenderer>();
        _audioLose = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Knife"))
        {
            StartGame.isGameStarted = false;
            Destroy(collision.gameObject.transform.parent.gameObject);
            _spriterenderer.color = deathColor;

            ContactPoint2D contactPoint2D = collision.contacts[0];
            Vector2 _pos = contactPoint2D.point;
            GameObject newobj = Instantiate(explosion, _pos, Quaternion.identity);
            Destroy(newobj, 3f);
            _audioLose.Play();
            panelLose.SetActive(true);

        }
    }
}
