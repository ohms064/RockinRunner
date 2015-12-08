using UnityEngine;
using System.Collections;

public class FanSpawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Spawn(GameObject type) {
        type.transform.position = this.transform.position;
        type.GetComponent<FanBehavior>().enabled = true;
    }
    public void Spawn(Collider type) {
        type.transform.position = this.transform.position;
    }
#if UNITY_EDITOR
    void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(this.transform.position, this.transform.localScale);
    }
#endif
}
