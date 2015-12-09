using UnityEngine;
using System.Collections;

public class Limit : MonoBehaviour {
    public Manager manager;
    public Transform spawnPoint;

    void OnTriggerEnter(Collider pista) {
        if(pista.tag == "Edificio")
            pista.transform.position = spawnPoint.position;
        
    }

#if UNITY_EDITOR
    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(this.transform.position, this.transform.localScale);
        Gizmos.color = Color.green;
        Gizmos.DrawCube(spawnPoint.transform.position, this.transform.localScale);
    }
#endif
}
