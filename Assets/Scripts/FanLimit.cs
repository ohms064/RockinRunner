using UnityEngine;
using System.Collections;

public class FanLimit : MonoBehaviour {
    public FanSpawner[] spawnPoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider fan) {
        if(fan.tag == "Fan")
            spawnPoint[Random.Range(0, spawnPoint.Length)].Respawn(fan);
    }
#if UNITY_EDITOR
    void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(this.transform.position, this.transform.localScale);
    }
#endif
}
