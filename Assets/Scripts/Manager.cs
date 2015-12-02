using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {
    [Range(-1.0f, 0.0f)]
    public float velocidad;
    public GameObject carro;
    [HideInInspector]
    public float velocidadEdif, velocidadBanqueta, tiempoEdif;
    public GameObject[] obstaculos;
    
    void Awake() {
        velocidadEdif = velocidad * 0.5f + 0.027f;
        tiempoEdif = 5.0f / velocidadEdif;
        velocidadBanqueta = 0.0f;
        tiempoEdif = 0.0f;
    }
    
   void Update() {
        velocidadEdif = velocidad * 0.5f + 0.027f;
        tiempoEdif = 5.0f / velocidadEdif;
    }
}