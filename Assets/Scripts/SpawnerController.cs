using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnerController : MonoBehaviour {
    private string[] nivel;
    private int estado;
    public Spawner[] hijos;
    public Queue<GameObject> objetos;
    public GameObject type;

    // Use this for initialization
    void Awake () {
        nivel = new string[6] { "1", "2", "3", "1 2", "1 3","2 3"};
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void StateMachine() {
        estado = Random.Range(0, 5);
        foreach (string item in nivel[estado].Split(' ')) {
            hijos[int.Parse(item)].InstanceObject(objetos.Dequeue());
        }
        if(estado == 1) {

        }
    }
}
