using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Manager : MonoBehaviour {
    [Range(-2.0f, 0.0f)]
    public float velocidad;
    public TextOffset pista;
    public Transform carro;
    [HideInInspector]
    public float velocidadEdif;
    public GameObject[] dificultad;
    public GameObject[] fans;
    public bool pausa;
    public Canvas botones;
    private float distancia;
    public float fin = 10.0f;
    [HideInInspector]
    public float recorrido;
    private bool anterior;
    private float retorna;
    private TableroScript tablero;

    void Awake() {
        velocidadEdif = Mathf.Clamp(velocidad * 0.5f + 0.027f, -1.0f, 0.0f);
        StartCoroutine(SubirDif());
        tablero = GetComponent<TableroScript>();
    }
    
   void Update() {
        velocidadEdif = Mathf.Clamp(velocidad * 0.5f + 0.027f, -1.0f, 0.0f);
        if (pausa && !anterior) {
            StartCoroutine(Pausar());
        }
        anterior = pausa;
        distancia = pista.getDistancia();
        tablero.valorRef = velocidad;
        recorrido = distancia / fin;
    }

    void FixedUpdate() {
        
    }

    public void setPausa(bool p) {
        pausa = p;
    }

    private IEnumerator Pausar() {
        retorna = velocidad;
        velocidad = 0.0f;
        botones.enabled = false;
        while (pausa) {
            yield return null;
        }
        botones.enabled = true;
        velocidad = retorna;
    }

    IEnumerator SubirDif() {
        while (true) {
            yield return new WaitForSeconds(5.0f);
            while (velocidad > -2.0f) {
                velocidad = Mathf.Clamp(velocidad * 1.05f, -2.0f, 0.0f);
                yield return new WaitForSeconds(1.0f);
            }
        }
    }
}