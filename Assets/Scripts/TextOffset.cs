using UnityEngine;
using System.Collections;


public class TextOffset : MonoBehaviour {
    private delegate void MovementFunc(float n);
    public delegate int Distance();
    public enum TipoMovimiento {
        moverEnX, moverEnY, moverEnMinX, moverEnMinY
    }

    public Manager manager;
    public TipoMovimiento direccion = TipoMovimiento.moverEnX;
    private Vector2 uvOffset;
    private Renderer render;
    private MovementFunc movimiento;
    public Distance getDistancia;


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

    public int getX() {
        return Mathf.Abs((int)uvOffset.x);
    }
    public int getY() {
        return Mathf.Abs((int)uvOffset.y);
    }

    // Use this for initialization
    void Awake () {
        render = this.GetComponent<Renderer>();
        switch (direccion) {
            case TipoMovimiento.moverEnX:
                movimiento = new MovementFunc(sumX);
                getDistancia = new Distance(getX);
                break;
            case TipoMovimiento.moverEnY:
                movimiento = new MovementFunc(sumY);
                getDistancia = new Distance(getY);
                break;
            case TipoMovimiento.moverEnMinX:
                movimiento = new MovementFunc(resX);
                getDistancia = new Distance(getX);
                break;
            case TipoMovimiento.moverEnMinY:
                movimiento = new MovementFunc(resY);
                getDistancia = new Distance(getY);
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
