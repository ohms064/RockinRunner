using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {
    public Manager manager;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        this.transform.Translate(new Vector3(manager.velocidad * Time.deltaTime * 20.0f, 0.0f, 0.0f));
	}
}
