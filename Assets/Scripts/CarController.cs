using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {
    private Rigidbody rb;
    [Range(1.0f, 100.0f)]
    public float velocidad = 10.0f, velocidadRot = 10.0f;
    public Manager manager;
    private Vector3 direccion, posicion;
    private Quaternion origRot;
	// Use this for initialization
	void Awake () {
        rb = this.GetComponent<Rigidbody>();
        direccion = rb.rotation.eulerAngles;
        posicion = this.transform.position;
        origRot = rb.rotation;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if(Input.GetAxis("Horizontal") < 0.7f && Input.GetAxis("Horizontal") > -0.7f) {
            rb.rotation = Quaternion.Slerp(rb.rotation, origRot, Time.time * 0.1f);
            direccion = rb.rotation.eulerAngles;
        }
        else {
            direccion.y += Input.GetAxis("Horizontal") * Time.deltaTime * velocidadRot;
            posicion.z -= Input.GetAxis("Horizontal") * Time.deltaTime;

            direccion.y = Mathf.Clamp(direccion.y, 80.0f, 100.0f);
            posicion.z = Mathf.Clamp(posicion.z, -2.0f, 2.0f);

            //rb.MoveRotation(Quaternion.Euler(direccion * Time.deltaTime) * rb.rotation);
            rb.rotation = Quaternion.Euler(direccion);
            rb.position = posicion;
        }
    }
}
