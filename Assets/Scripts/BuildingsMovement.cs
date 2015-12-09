using UnityEngine;
using System.Collections;

public class BuildingsMovement : MonoBehaviour {
    public Manager manager;
    // Use this for initialization
    void Awake () {
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate() {
        this.transform.position += new Vector3(manager.velocidadEdif, 0.0f, 0.0f);
    }
}
