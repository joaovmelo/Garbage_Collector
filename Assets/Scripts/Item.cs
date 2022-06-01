using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    private SpriteRenderer sr;
    private CircleCollider2D circle;

    public AudioSource playAudio;
    public GameObject collected;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            sr.enabled = false;
            circle.enabled = false;
            collected.SetActive(true);

            playAudio.Play();
            GameController.instance.UpdateScore();

            Destroy(gameObject, 0.5f);
        }
    }
}
