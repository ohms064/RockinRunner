using UnityEngine;
using System.Collections;

public class FanSpawner : MonoBehaviour {
    public delegate void RespawnFunc(Collider type);
    public delegate void SpawnFunc(GameObject type);
    public bool invertir = false;
    public RespawnFunc Respawn;
    public SpawnFunc Spawn;

    // Use this for initialization
    void Awake () {
        if (invertir) {
            Respawn = new RespawnFunc(SpawnCollider1);
            Spawn = new SpawnFunc(SpawnObject1);
        }
        else {
            Respawn = new RespawnFunc(SpawnCollider2);
            Spawn = new SpawnFunc(SpawnObject2);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SpawnObject1(GameObject type) {
        type.transform.localScale = new Vector3(-Mathf.Abs(type.transform.localScale.x), type.transform.localScale.y, type.transform.localScale.z);
        type.transform.position = this.transform.position;
        type.GetComponent<FanBehaviour>().enabled = true;
    }
    public void SpawnObject2(GameObject type) {
        type.transform.localScale = new Vector3(Mathf.Abs(type.transform.localScale.x), type.transform.localScale.y, type.transform.localScale.z);
        type.transform.position = this.transform.position;
        type.GetComponent<FanBehaviour>().enabled = true;
    }
    public void SpawnCollider1(Collider type) {
        type.transform.position = this.transform.position;
        type.transform.localScale = new Vector3(-Mathf.Abs(type.transform.localScale.x), type.transform.localScale.y, type.transform.localScale.z);
    }
    public void SpawnCollider2(Collider type) {
        type.transform.position = this.transform.position;
        type.transform.localScale = new Vector3(Mathf.Abs(type.transform.localScale.x), type.transform.localScale.y, type.transform.localScale.z);
    }

#if UNITY_EDITOR
    void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(this.transform.position, this.transform.localScale);
    }
#endif
}
