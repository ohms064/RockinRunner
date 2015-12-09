using UnityEngine;
using System.Collections;

public class RightArmBehavior : MonoBehaviour {
    private Animator animator;
    public string input = "w";
    public bool golpe;
    private BoxCollider box;

    void Awake() {
        box = this.GetComponent<BoxCollider>();
        animator = GetComponent<Animator>();
        golpe = false;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (golpe) {
            animator.SetTrigger("Golpe");
            StartCoroutine(Golpear());
            golpe = false;
        }
	}

    public void setGolpe(bool gol) {
        this.golpe = gol;
    }

    private IEnumerator Golpear() {
        yield return new WaitForSeconds(0.2f);
        box.enabled = true;
        yield return new WaitForSeconds(0.3f);
        box.enabled = false;
    }
}
