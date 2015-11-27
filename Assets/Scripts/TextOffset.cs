using UnityEngine;
using System.Collections;

public class TextOffset : MonoBehaviour {
    public Manager manager;
    private Vector2 uvOffset;
    private Renderer render;
	// Use this for initialization
	void Start () {
        render = this.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        uvOffset.y += (manager.velocidad * Time.deltaTime);
        if (render.enabled) {
            render.materials[0].SetTextureOffset("_MainTex", uvOffset);
        }
	}
}
