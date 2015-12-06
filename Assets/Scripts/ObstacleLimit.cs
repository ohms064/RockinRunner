using UnityEngine;
using System.Collections;

public class ObstacleLimit : MonoBehaviour {
    public Spawner[] spawnPoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider obstaculo) {
        spawnPoint[Random.Range(0, spawnPoint.Length)].Spawn(obstaculo);
    }
#if UNITY_EDITOR
    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(this.transform.position, this.transform.localScale);
    }
#endif
}
