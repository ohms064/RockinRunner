using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {
    [Range(-1.0f, 0.0f)]
    public float velocidad;
    public GameObject carro;
    [HideInInspector]
    public float velocidadEdif, velocidadBanqueta;
    public GameObject[] dificultad;

    void Awake() {
        velocidadEdif = Mathf.Clamp(velocidad * 0.5f + 0.027f, -1.0f, 0.0f);
        velocidadBanqueta = 0.0f;
    }
    
   void Update() {
        velocidadEdif = Mathf.Clamp(velocidad * 0.5f + 0.027f, -1.0f, 0.0f);
    }
}