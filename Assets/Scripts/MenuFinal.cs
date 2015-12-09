using UnityEngine;
using System.Collections;

public class MenuFinal : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GotoBegin() {
        Application.LoadLevel("Menu");
    }
    public void GotoGame() {
        Application.LoadLevel("Principal");
    }
    public void Exit() {
        Application.Quit();
    }
}
