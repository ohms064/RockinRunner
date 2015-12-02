using UnityEngine;
using System.Collections;

public class RightArmBehavior : MonoBehaviour {
    private Animator animator;
    public string input = "w";
    public bool golpe;

    void Awake() {
        animator = GetComponent<Animator>();
        golpe = false;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (golpe)
        {
            animator.SetInteger("Status", 1);
        }
        else {
            animator.SetInteger("Status", 0);
        }
	}

    public void setGolpe(bool gol) {
        this.golpe = gol;
    }
}
