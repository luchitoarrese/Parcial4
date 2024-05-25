using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrestoyList : MonoBehaviour
{

   private enum Aligment { Fum, Road, Boss};
   [SerializeField] private Aligment Personaje;
    public  bool choco;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(Personaje)
        {
            case Aligment.Fum:
                Debug.Log("Suelta el cigarro");  break;
            case Aligment.Road:
                Debug.Log("Suelta las ruedas"); break;
            case Aligment.Boss:
                Debug.Log("Suelta las balas"); break;
        } 
    }

    public void Drop()
    {
        switch (Personaje)
        {
            case Aligment.Fum:
                Debug.Log("Suelta el cigarro"); break;
            case Aligment.Road:
                Debug.Log("Suelta las ruedas"); break;
            case Aligment.Boss:
                Debug.Log("Suelta las balas"); break;
        }
    }
}
