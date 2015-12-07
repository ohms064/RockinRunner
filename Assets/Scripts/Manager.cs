using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Manager : MonoBehaviour {
    [Range(-2.0f, 0.0f)]
    public float velocidad;
    public TextOffset pista;
    public GameObject carro;
    [HideInInspector]
    public float velocidadEdif;
    public GameObject[] dificultad;
    public bool pausa;
    public Canvas botones;
    public int distancia;
    private bool anterior;
    private float retorna;

    void Awake() {
        velocidadEdif = Mathf.Clamp(velocidad * 0.5f + 0.027f, -1.0f, 0.0f);
        StartCoroutine(SubirDif());
    }
    
   void Update() {
        velocidadEdif = Mathf.Clamp(velocidad * 0.5f + 0.027f, -1.0f, 0.0f);
        if ((pausa ^ anterior) && pausa) {
            StartCoroutine(Pausar());
        }
        anterior = pausa;
        distancia = pista.getDistancia();
    }

    public void setPausa(bool p) {
        pausa = p;
    }

    IEnumerator Pausar() {
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
            yield return new WaitForSeconds(2.0f);
            while (velocidad > -2.0f) {
                print("Distancia: " + distancia);
                if (distancia % 5 == 0) {
                    print("Subió la dificultad");
                    velocidad *= 1.5f;
                }
                yield return new WaitForSeconds(2.0f);
            }
        }
    }
}