using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour {
   
    public Manager manager;
    public Transform camara;
    private Vector3 direccion, posicion;
    private Quaternion origRot;
    private Rigidbody rb;
    private float velocidad, velocidadRot;
    private float tiempo;
    private bool giro, golpeIzquierda, golpeDerecha;
    private Animator animator;
    private Vector3 camaraOrig;

    // Use this for initialization
    void Awake () {
        rb = this.GetComponent<Rigidbody>();
        direccion = rb.rotation.eulerAngles;
        posicion = this.transform.position;
        origRot = rb.rotation;
        tiempo = 0.0f;
        animator = GetComponent<Animator>();
        camaraOrig = camara.position;
    }

    void Start() {
        giro = true;
    }
    //cambio
    // Update is called once per frame
    void FixedUpdate () {
        velocidad = manager.velocidad * -10.0f;
        velocidadRot = velocidad * 5.0f;

        #if UNITY_EDITOR
                if (!giro || (Input.GetAxis("Horizontal") < 0.1f && Input.GetAxis("Horizontal") > -0.1f)) {
                    giro = false;
                    rb.rotation = Quaternion.Lerp(rb.rotation, origRot, ( 1.0f - manager.velocidad) * (Time.time - tiempo));
                    direccion = rb.rotation.eulerAngles;
                    if (rb.rotation.Equals(origRot)) {
                        giro = true;
                    }
                }
                else if(giro) {
                    direccion.y += Input.GetAxis("Horizontal") * Time.deltaTime * velocidadRot;
                    posicion.z -= Input.GetAxis("Horizontal") * Time.deltaTime * velocidad;

                    direccion.y = Mathf.Clamp(direccion.y, 80.0f, 100.0f);
                    posicion.z = Mathf.Clamp(posicion.z, -2.0f, 2.0f);

                    //rb.MoveRotation(Quaternion.Euler(direccion * Time.deltaTime) * rb.rotation);
                    rb.rotation = Quaternion.Euler(direccion);
                    rb.position = posicion;
                    tiempo = Time.time;

                }
                golpeIzquierda = Input.GetKey(KeyCode.Q) ;
                if (golpeIzquierda)
                {
                    //animator.SetInteger("Status", 1);
                    //GameObject.Find("punch_0").GetComponent<SpriteRenderer>().enabled = true;
                    //GameObject.Find("punch_1").GetComponent<SpriteRenderer>().enabled = true;
                }
                else
                {
                    //animator2.SetInteger("Status", 0);
                    //GameObject.Find("punch_0").GetComponent<SpriteRenderer>().enabled = false;
                    //GameObject.Find("punch_1").GetComponent<SpriteRenderer>().enabled = false;        
                }
        #endif
        /*
        #if UNITY_ANDROID
                if (!giro || (Input.acceleration.x < 0.1f && Input.acceleration.x > -0.1f)) {
                    giro = false;
                    rb.rotation = Quaternion.Lerp(rb.rotation, origRot, ( 1.0f - manager.velocidad) * (Time.time - tiempo));
                    direccion = rb.rotation.eulerAngles;
                    if (rb.rotation.Equals(origRot)) {
                        giro = true;
                    }
                }
                    direccion.y += Input.acceleration.x * Time.deltaTime * velocidadRot;
                    posicion.z -= Input.acceleration.x * Time.deltaTime * velocidad;

                    direccion.y = Mathf.Clamp(direccion.y, 80.0f, 100.0f);
                    posicion.z = Mathf.Clamp(posicion.z, -2.0f, 2.0f);

                    rb.rotation = Quaternion.Euler(direccion);
                    rb.position = posicion;
                    tiempo = Time.time;
        #endif
        */
        camara.position = new Vector3(camara.position.x, camara.position.y, posicion.z);
    }

    IEnumerator Shake() {
        float duration = Mathf.Clamp01(-manager.velocidad);
        float magnitude = -manager.velocidad / 2;
        float elapsed = 0.0f;

        while (elapsed < duration) {

            elapsed += Time.deltaTime;

            float percentComplete = elapsed / duration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float z = Random.value * 2.0f - 1.0f;

            z *= magnitude * damper;


            camara.position = new Vector3(camara.position.x, camara.position.y, camara.position.z + z);

            yield return null;
        }
    }

    void OnTriggerEnter(Collider c) {
        StartCoroutine(Shake());
        manager.velocidad *= 0.8f;
    }
}
