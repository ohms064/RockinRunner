using UnityEngine;
using System.Collections;

public delegate void MovementFunc(float n);
public enum TipoMovimiento {
    moverEnX, moverEnY, moverEnMinX, moverEnMinY
}
public class TextOffset : MonoBehaviour {
    public Manager manager;
    public TipoMovimiento direccion = TipoMovimiento.moverEnX;
    private Vector2 uvOffset;
    private Renderer render;
    private MovementFunc movimiento;
    
    private void sumX(float n) {
        uvOffset.x += n;
    }

    private void sumY(float n) {
        uvOffset.y += n;
    }
    private void resX(float n) {
        uvOffset.x -= n;
    }

    private void resY(float n) {
        uvOffset.y -= n;
    }



    // Use this for initialization
    void Awake () {
        render = this.GetComponent<Renderer>();
        switch (direccion) {
            case TipoMovimiento.moverEnX:
                movimiento = new MovementFunc(sumX);
                break;
            case TipoMovimiento.moverEnY:
                movimiento = new MovementFunc(sumY);
                break;
            case TipoMovimiento.moverEnMinX:
                movimiento = new MovementFunc(resX);
                break;
            case TipoMovimiento.moverEnMinY:
                movimiento = new MovementFunc(resY);
                break;
        }
	}
	
	// Update is called once per frame
	void LateUpdate () {
        movimiento(manager.velocidad * Time.deltaTime);
        if (render.enabled) {
            render.material.SetTextureOffset("_MainTex", uvOffset);
        }
	}
}
