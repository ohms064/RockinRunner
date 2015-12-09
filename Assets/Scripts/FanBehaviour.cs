using UnityEngine;
using System.Collections;
public delegate void State();
public class FanBehaviour : MonoBehaviour {
    private Animator animator;
    public string input = "f";
    public int estadoFan;
    public bool teclaF;
    public Manager manager;
    public State StateExec;
    public int punchCounter;
    private bool atacar;

    public const int maxGolpes = 5;


    void Awake()
    {
       animator = GetComponent<Animator>();
       animator.SetInteger("fan_state", 0);
       estadoFan = 0;
       StateExec = new State(Moving);
       atacar = false;
       punchCounter = 0;
    }


    void FixedUpdate() {
        StateExec();
        if(punchCounter == maxGolpes) {
            punchCounter++;
            atacar = false;
            animator.SetTrigger("Fall");
            StateExec = new State(Moving);
            this.transform.parent = null;
        }
    }

    void OnTriggerEnter(Collider signal) {
        if (signal.tag == "FanJumpSignal") {
            animator.SetTrigger("Jump");
            StateExec = new State(Jump);
        }
        else if (signal.tag == "Finish") {
            animator.SetTrigger("Rewind");
            punchCounter = 0;
        }
        else if (signal.tag == "Player") {
            animator.SetTrigger("Steady");
            StateExec = new State(MoveAlong);
            this.transform.parent = signal.transform;
            StartCoroutine(Atacar());
        }
        else if(signal.tag == "Obstaculo" || signal.tag == "Golpe"){
            punchCounter++;
        }
    }

    public void Moving() {
        this.transform.position += new Vector3(manager.velocidadEdif, 0.0f, 0.0f);
    }
    public void Jump() {
        this.transform.position = Vector3.MoveTowards(this.transform.position, manager.carro.position, -manager.velocidad *20* Time.deltaTime);
    }
    public void MoveAlong() {
        //this.transform.position += manager.carro.position - this.transform.position;
        return;
    }

    private IEnumerator Atacar() {
        atacar = true;
        while (atacar) {
            print("Reducción! " + this.name + " ");
            manager.velocidad *= 0.99f;
            yield return new WaitForSeconds(1.5f);
        }
    }
}
