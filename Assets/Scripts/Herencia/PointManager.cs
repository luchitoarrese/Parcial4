using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{

    public static PointManager instance;

    [SerializeField] private float cantidadPuntos;

    private void Awake()
    {
        if(PointManager.instance == null)
        {
            PointManager.instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    

    public void SumarPuntos(float puntos)
    {
        cantidadPuntos += puntos;
    }
}
