using UnityEngine;
using System.Collections;

public class FanSpawnerController : MonoBehaviour {
    public Manager manager;
    public FanSpawner[] hijos;

    // Use this for initialization
    void Start () {
        StartCoroutine(createFans());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public IEnumerator createFans() {
        FanSpawnerController script = this.GetComponent<FanSpawnerController>();
        for (int i = 0; i < manager.fans.Length; i++) {
            yield return new WaitForSeconds(3);
            hijos[Random.Range(0, hijos.Length)].Spawn(manager.fans[i]);
        }
        script.enabled = false;
    }
}
