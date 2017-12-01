using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour {
    private Transform laCible;

    /***Variable Detection***/
    public float distanceDetect = 4.0F; //4.0F à l'origine
    public bool detecter;
    //Une fois sorti de la zone de detection l'ennemi arrête de poursuivre le joueur apres le temps donné par cette variable "decroche" 
    public float decroche = 3; //3 à l'origine
    private Mouvement sComportement;



    // Use this for initialization
    void Start()
    {

        sComportement = GetComponent<Mouvement>();
        laCible = sComportement.cible;

    }

    // Update is called once per frame
    void Update()
    {

        CalculDist();

    }

    //Verifie la position du joueur
    private void CalculDist()
    {
        //Le joueur est a ditance
        if (laCible)
        {
            float sqrLen = (laCible.position - transform.position).sqrMagnitude;
            if (sqrLen < distanceDetect * distanceDetect)
            {
                detecter = true;
                ConditionComportement();//Appel de methode
                if (IsInvoking("Timer"))//Annule l'invocation au cas d'une invocation déjà effectué
                {
                    CancelInvoke("Timer");
                }
            }
            //Le joueur n'est plus a distance
            if (sqrLen > distanceDetect && detecter)
            {
                detecter = false;
                PlusAdistance();
            }

        }
    }


    private void ConditionComportement()
    {
        if (detecter)
        {
            //BonneDist();
            sComportement.pause = false;
            sComportement.poursuite = true;

        }

    }

    //Active la poursuite dans le script "comportement"
    private void BonneDist()
    {
        sComportement.poursuite = true;
    }

    //Appel la methode coroutine "Timer"
    private void PlusAdistance()
    {
        Invoke("FinPoursuite", decroche);//Permet d'utilisé un temps donné avant d'arreter la poursuite et appel la méthode "finPoursuite"
    }

    //Met fin a la poursuite du joueur
    private void FinPoursuite()
    {
        sComportement.pause = true;
        sComportement.poursuite = false;
        print("DESACTIVE LA POURSUITE !!");

    }

}