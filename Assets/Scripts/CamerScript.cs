using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerScript : MonoBehaviour
{
    [SerializeField] private Transform playerTrfm;
    [SerializeField] private Vector2 minMaxX = Vector2.zero;
    [SerializeField] private Vector2 minMaxY = Vector2.zero;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(Mathf.Clamp(playerTrfm.position.x, minMaxX.x, minMaxX.y),
                                              Mathf.Clamp(playerTrfm.position.y, minMaxY.x, minMaxY.y),
                                              -10);
    }
}
