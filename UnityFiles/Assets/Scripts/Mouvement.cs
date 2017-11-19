using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour {
    public Transform cible;//glisser l'objet player
    private Transform maTransform;
    private UnityEngine.AI.NavMeshAgent agent;
    public bool poursuite;
    public float pdv = 10f;
    public bool pause;


    void Awake()
    {
        maTransform = transform;
    }

    // Use this for initialization
    void Start()
    {

        //Initialisation du script NavMeshAgen qui se trouve sur le même objet que ce script
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        pause = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (poursuite)
        {
            mouvement();
        }

        if (poursuite == false && pause == true)
        {
            miseEnAttente();
        }

    }


    private void mouvement()
    {
        //Si la variable "vieActuelle" est supérieur a 0
        if (pdv > 0)
        {
            Debug.DrawLine(cible.transform.position, maTransform.position, Color.blue);
            agent.destination = cible.position;//le squelette se dirige vers le joueur
        }
    }

    //L'ennemi reste a sa position actuelle
    private void miseEnAttente()
    {
        print("NE BOUGE PLUS !!");
        agent.destination = transform.position;
    }


}