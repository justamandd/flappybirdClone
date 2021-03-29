using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    public Transform gameOver;


    [SerializeField]
    Text scoreView;

    [SerializeField]
    float jump;

    [SerializeField]
    int score;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            rb.velocity = Vector2.up * jump;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AddScore"))
        {
            score++;
            scoreView.text = score.ToString();
        }

        if (collision.CompareTag("Pipe"))
        {
            enabled = false;
            gameOver.gameObject.SetActive(true);
            Invoke("Pause", 0);
        }
    }

    void Pause()
    {
        Time.timeScale = 0;
    }
}
