using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {
    [Range(-1.0f, 0.0f)]
    public float velocidad;
    public GameObject carro;
    [HideInInspector]
    public Vector3 spawnPos;
    // Use this for initialization
    public GameObject[] obstaculos;
}