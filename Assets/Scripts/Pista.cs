using UnityEngine;
using System.Collections;

public class Pista : MonoBehaviour {
    public Manager manager;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate() {
        this.GetComponent<Rigidbody>().position += new Vector3(manager.velocidad, 0.0f, 0.0f);
    }
}
