using UnityEngine;
using System.Collections;

public class BuildingSpawner : MonoBehaviour {
    public GameObject[] buldings;
    public Manager manager;
    // Use this for initialization
    void Start () {
        StartCoroutine(Spawn());
	}
	
    private IEnumerator Spawn() {
        while (true) {
            yield return new WaitForSeconds(1);
        }
    }

	// Update is called once per frame
	void Update () {
	
	}

#if UNITY_EDITOR
    void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(this.transform.position, this.transform.localScale);
    }
#endif
}
