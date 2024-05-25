using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Money : MonoBehaviour
{

    private Slider sld;

    void Start()
    {
        sld = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambiarMontoMaximo(float montoMaximo) 
    {
      sld.maxValue = montoMaximo;
    }
    public void CambiarMontoActual(float cantidadMonto) 
    {
     sld.value = cantidadMonto;
    }

    public void InicializarMoney(float cantidadMonto)
    {
      CambiarMontoMaximo(cantidadMonto);
      CambiarMontoActual(cantidadMonto);
    }
}
