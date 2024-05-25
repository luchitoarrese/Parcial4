using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{

    private Slider sl;

    void Start()
    {
        sl = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambiarCardMaximo(float cardMaximo)
    {
        sl.maxValue = cardMaximo;
    }

    public void CambiarCardActual(float cantidadCard)
    {
        sl.value = cantidadCard;
    }

    public void InisializarCard(float cantidadCard) 
    {
      CambiarCardMaximo(cantidadCard);
      CambiarCardActual(cantidadCard);
    }
}
