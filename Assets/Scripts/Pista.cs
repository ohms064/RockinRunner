using UnityEngine;
using System.Collections;

public class Pista : MonoBehaviour {
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
        rb.position += new Vector3(manager.velocidad, 0.0f, 0.0f);
    }
}
