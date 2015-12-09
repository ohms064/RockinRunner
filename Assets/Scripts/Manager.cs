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
    public Canvas botones, menuPausa;
    private float distancia;
    public float fin = 10.0f;
    [HideInInspector]
    public float recorrido;
    private bool anterior;
    private TableroScript tablero;

    void Awake() {
        menuPausa.enabled = false;
        velocidadEdif = Mathf.Clamp(velocidad * 0.5f + 0.027f, -1.0f, 0.0f);
        StartCoroutine(SubirDif());
        tablero = GetComponent<TableroScript>();
    }
    
   void Update() {
        velocidadEdif = Mathf.Clamp(velocidad * 0.5f + 0.027f, -1.0f, 0.0f);
        if(velocidad > -0.3f) {
            Perdiste();
        }
        if (pausa && !anterior) {
            StartCoroutine(Pausar());
        }
        anterior = pausa;
        distancia = pista.getDistancia();
        tablero.valorRef = velocidad;
        recorrido = distancia / fin;

        if(recorrido >= 1.0f) {
            Ganaste();
        }
    }

    void FixedUpdate() {
        
    }

    public void setPausa(bool p) {
        pausa = p;
    }

    public void ReturnMenu(){
        Application.LoadLevel("Menu");
    }

    private IEnumerator Pausar() {
        Time.timeScale = 0;
        botones.enabled = false;
        menuPausa.enabled = true;
        while (pausa) {
            yield return null;
        }
        botones.enabled = true;
        menuPausa.enabled = false;
        Time.timeScale = 1;
    }

    IEnumerator SubirDif() {
        yield return new WaitForSeconds(5.0f);
        while (true) {
            velocidad = Mathf.Clamp(velocidad * 1.05f, -2.0f, 0.0f);
            yield return new WaitForSeconds(1.8f);
        }
    }

    private void Ganaste() {
        Application.LoadLevel("Ganaste");
    }

    private void Perdiste() {
        Application.LoadLevel("Perdiste");
    }
}