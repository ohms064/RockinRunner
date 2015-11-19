using UnityEngine;
using System.Collections;

public class Swapper : MonoBehaviour {
    public Manager manager;

    void OnTriggerEnter(Collider pista) {
        pista.GetComponent<Rigidbody>().position = manager.spawnPos;
    }
#if UNITY_EDITOR
    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(this.transform.position, this.transform.localScale);
    }
#endif
}
