using UnityEngine;
using System.Collections;

public class MapaDistancia : MonoBehaviour {

    public RectTransform player, meta;
    private Manager manager;
    private float y, inicio;
	// Use this for initialization
	void Start () {
        inicio = player.localPosition.y;
        manager = this.GetComponent<Manager>();
	}
	
	// Update is called once per frame
	void Update () {
        y = Mathf.Lerp(inicio, meta.localPosition.y, manager.recorrido);
        player.localPosition = new Vector3(player.localPosition.x, y, player.localPosition.z);
	}
}
