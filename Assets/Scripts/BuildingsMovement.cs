using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]
public class BuildingsMovement : MonoBehaviour {
    public Manager manager;
    private Rigidbody rb;
    // Use this for initialization
    void Awake () {
        rb = this.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate() {
        rb.position += new Vector3(manager.velocidadEdif, 0.0f, 0.0f);
    }
}
