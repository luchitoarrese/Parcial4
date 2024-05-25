using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadsScript : DrestoyList
{
    public float enemyspeed;
    public Vector2 Finalpos;
    private Vector2 Startpos, target;



    void Start()
    {
        Startpos = transform.position;
        target = Finalpos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, enemyspeed*Time.deltaTime); 

        if((Vector2)transform.position == Finalpos)
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

    private void OnTriggerEnter2D(Collider2D other) 
    {
     if(other.CompareTag("Area"))
        {
            Drop();
        }
  
    }
}
