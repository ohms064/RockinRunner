using UnityEngine;
using System.Collections;

public class Limit : MonoBehaviour {
    public Manager manager;
    public Transform spawnPoint;

    void OnTriggerEnter(Collider pista) {
        //Destroy(pista.gameObject);
        pista.transform.position = spawnPoint.position;
    }

#if UNITY_EDITOR
    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(this.transform.position, this.transform.localScale);
    }
#endif
}
