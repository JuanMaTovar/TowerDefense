using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public GameObject objetivo;
    public int vida = 100;
    public Animator Anim;
    // Start is called before the first frame update

    private void OnEnable()
    {
        objetivo = GameObject.Find("Objetivo");
    }
    private void OnDisable()
    {
        
    }
    void Start()
    {
        GetComponent<NavMeshAgent>().SetDestination(objetivo.transform.position);
        Anim = GetComponent<Animator>();
        Anim.SetBool("IsMoving", true);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Objetivo")
        {
            Anim.SetBool("IsMoving", false);
            Anim.SetTrigger("OnObjetiveReached");
        }
    }
    public void Danar()
    {
        objetivo?.GetComponent<Objetivo>().RecibirDano(5);
    }
    public void RecibirDano(int dano = 10)
    {
        vida -= dano;
    }
}