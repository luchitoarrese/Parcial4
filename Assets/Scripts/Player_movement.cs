using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{

    private float axisX;
    [Range(0, 10)] public float speed;
    private Rigidbody2D rb;
    [Range(0, 10)] public float jumpforce;
    [SerializeField] private bool canjump;
    private Animator an;
    public GameObject gm;
    public AudioClip sonidoSalto;
    public AudioClip coger;
    private AudioSource sonidoJugador;
    public AudioClip Golpe;
    public AudioClip Life;
    public AudioClip Tarjeta;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
        sonidoJugador = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        axisX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(axisX * speed, rb.velocity.y);
        if(axisX != 0 && canjump== true)
        {
            an.SetBool("Run", true);
        }
        else 
        {
            an.SetBool("Run", false);
        }

        if (axisX > 0) transform.localScale = new Vector2(1, 1);
        else if (axisX < 0) transform.localScale = new Vector2(-1, 1);

        if (Input.GetKeyDown(KeyCode.W) && canjump == true)
        {
            rb.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
            an.SetBool("Jump", true);
            canjump = false;
            sonidoJugador.PlayOneShot(sonidoSalto, 1.0f);
        }

        if(canjump== true && Input.GetKeyDown(KeyCode.Space))
        {
            an.SetBool("Atack", true);
            
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Floor"))
        {
            canjump = true;
            an.SetBool("Jump", false);
        }
        if(collider.CompareTag("CoindGreen"))
        {
            sonidoJugador.PlayOneShot(coger, 1.0f);
        }
        if(collider.CompareTag("CoinRed"))
        {
            sonidoJugador.PlayOneShot(Life, 1.0f);
        }
        if(collider.CompareTag("Target"))
        {
            sonidoJugador.PlayOneShot(Tarjeta, 1.0f);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Floor"))
        {
            canjump = false;
            an.SetBool("Jump", true );
        }

    }

    public void PlayerAtack()
    {
        gm.SetActive(true);
        sonidoJugador.PlayOneShot(Golpe, 1.0f);
    }
    public void Tired() 
    {
        an.SetBool("Atack", false );
      gm.SetActive(false);
    }
}