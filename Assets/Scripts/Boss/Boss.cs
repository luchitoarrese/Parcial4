using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : DrestoyList
{
    public float enemyspeed;
    public Vector2 Finalpos;
    private Vector2 Startpos, target;
    public bool isGoing=true;
    public float timer;
    public bool Shooter=false;
    private Animator am;
    public GameObject bulletprefab;
    public float speedbullet;
    public Transform spawnpos;
    private AudioSource sonidoEnemigo;
    public AudioClip disparo;
    public int recarga=3;
    public bool remach=false;

    void Start()
    {

        Startpos = transform.position;
        target = Finalpos;
        am = GetComponent<Animator>();
        sonidoEnemigo = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGoing==true)
        {
            am.SetBool("Going", true);
        transform.position = Vector2.MoveTowards(transform.position, target, enemyspeed * Time.deltaTime);

        if ((Vector2)transform.position == Finalpos)
        {
            target = Startpos;
            transform.localScale = new Vector2(1, 1);
        }
        else if ((Vector2)transform.position == Startpos)
        {
            target = Finalpos;
            transform.localScale = new Vector2(-1, 1);
        }

         }


        if(isGoing==false && recarga > 0) 
        {
            am.SetBool("Going", false);
            am.SetBool("BShoot", true);
         Shooter = true;
        }

        if(recarga==0)
        { 
            
            am.SetBool("Recarga", true);
        }
   
    }


    public void OnTriggerEnter2D(Collider2D other)
    { 
      if(other.CompareTag("Player"))
        {
            isGoing = false;
        }
      if(other.CompareTag("Area"))
        {
            am.SetBool("Dead", true);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {  
            
            isGoing = true;
            am.SetBool("BShoot", false);
        
        
        }
    }

    public void BossShoot()
    {
        sonidoEnemigo.PlayOneShot(disparo, 1.0f);
        GameObject bullet = Instantiate(bulletprefab, new Vector2(spawnpos.position.x, spawnpos.position.y + 0.3f), transform.rotation);
        recarga -= 1;

        
    }

    public void Recarga()
    {
        recarga += 3;
        am.SetBool("Recarga",false);
    }

    public void Muerte()
    {
        Drop();
        Destroy(this.gameObject);
    }
}
