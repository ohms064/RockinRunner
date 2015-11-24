using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {
    [Range(-1.0f, 0.0f)]
    public float velocidad;
    public Transform lastTrack;
    public GameObject carro;
    [HideInInspector]
    public Vector3 spawnPos;
    // Use this for initialization
    void Awake() {
        spawnPos = lastTrack.position;
    }

    public void switchTracks(Transform tr) {
        lastTrack = tr;
        spawnPos = lastTrack.position;
    }
}