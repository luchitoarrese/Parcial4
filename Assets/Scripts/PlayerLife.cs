using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{

    [SerializeField] private float vida;
    [SerializeField] private float maximoVida;
    [SerializeField] private Barradevida barradevida;

    [SerializeField] private float bill;
    [SerializeField] private float maximoMoney;
    [SerializeField] private Money money;


    [SerializeField] private float target;
    [SerializeField] private float maximoCard;
    [SerializeField] private Card card;

    void Start()
    {
        vida = maximoVida;
        barradevida.InicializarBarraDeVida(vida);

        bill = maximoMoney;
        money.InicializarMoney(bill);

        target = maximoCard;
        card.InisializarCard(target);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
      if(other.CompareTag("CoinRed"))
        {
            TomarDaño(2);
        }

      if(other.CompareTag("CoindGreen"))
        {
            TomarMoney(2);
        }
      if(other.CompareTag("Target"))
        {
            TomarCard(2);
        }
    
    }

    public void TomarDaño(float daño) 
    {
        vida -= daño;
        barradevida.CambiarVidaActual(vida);
    
    }

    public void TomarMoney(float diner)
    {
        bill -= diner;
        money.CambiarMontoActual(bill);
    }
    public void TomarCard(float credit)
    {
        target -= credit;
        card.CambiarCardActual(target);
    }
}
