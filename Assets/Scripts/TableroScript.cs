using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TableroScript : MonoBehaviour {

	public RectTransform acelerometro;
	[HideInInspector]
	public float valorRef;
    private float anterior;

	private const float anguloMaximo = -190.0f;
	private const float anguloMinimo = 20.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	public void Update () {
        if(anterior != valorRef) {
            StartCoroutine(RotacionImagenes(acelerometro, anguloMinimo, anguloMaximo, 0f, -2f, anterior, valorRef));
        }
        anterior = valorRef;
	}
	
	public IEnumerator RotacionImagenes(RectTransform img , float gradMin, float gradMax, float velMin, float velMax, float actual, float valor){
        float tiempo = Time.time;
        float aux = 0.0f;
        float angulo = 0.0f;
        while(aux != valor) {
            angulo = getAngulo(gradMin, gradMax, velMin, velMax, Mathf.Lerp(actual, valor, Time.time - tiempo));
            img.localEulerAngles = new Vector3(img.localEulerAngles.x, img.localEulerAngles.y, angulo);
            yield return new WaitForFixedUpdate();
        }
	}


	private float pendiente(float gradMin, float gradMax, float velMin, float velMax){
		return (gradMax - gradMin)/(velMax - velMin);
	}

	public float getAngulo(float gradMin, float gradMax, float velMin, float velMax, float valVelocidad){
		//La posicion inicial de la flecha debe ser 0°
		return (pendiente (gradMin, gradMax, velMin, velMax) * (valVelocidad-velMin)) + gradMin;
	}
}
