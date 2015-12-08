using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnerController : MonoBehaviour {
    public Manager manager;
    public Spawner[] hijos;
    

    // Use this for initialization
    void Awake () {
    }
	
    void Start() {
        StartCoroutine(createObstacles());
    }
	// Update is called once per frame
	void Update () {
	}
    
    public IEnumerator createObstacles() {
        SpawnerController script = this.GetComponent<SpawnerController>();
        for (int i = 0; i < manager.dificultad.Length; i++) {
            yield return new WaitForSeconds(3);
            hijos[Random.Range(0, hijos.Length)].Spawn(manager.dificultad[i]);
        }
        script.enabled = false;
    }
}
