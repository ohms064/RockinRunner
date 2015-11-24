using UnityEngine;
using System.Collections;

public class Swapper : MonoBehaviour {
    public Manager manager;
    [HideInInspector] public int count;

    void OnTriggerEnter(Collider pista) {
        pista.GetComponent<Rigidbody>().position = manager.spawnPos;
        count++;
    }

    void OnTriggerExit(Collider pista) {
        manager.switchTracks(pista.transform);
    }

#if UNITY_EDITOR
    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(this.transform.position, this.transform.localScale);
    }
#endif
}
