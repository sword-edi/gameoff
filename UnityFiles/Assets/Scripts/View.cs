using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour {

    public float View_Radius;
    [Range(0,360)]
    public float View_Angle;

    public LayerMask Target_Mask;
    public LayerMask Obstacle_Mask;

    public List<Transform> Visible_Targets = new List<Transform>();

    

    //pour le tir
    public float bulletImpulse = 20.0f;
    public Transform canon;
    public Rigidbody projectile;
	public GameObject gun;

    //pour poursuivre
    private Transform maTransform;
    private UnityEngine.AI.NavMeshAgent agent;
	private Transform target;

	private GunShoot shooter;
	Health health;
	bool melee;

    void Awake()
    {
		maTransform = transform;
    }

    void Start(){
        StartCoroutine("FindTargetsWithDelay", 0.2f);

        //Initialisation du script NavMeshAgen qui se trouve sur le même objet que ce script
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		if (gun != null)
			shooter = gun.GetComponent<GunShoot>();
		health = GetComponent<Health>();
		melee = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (health.IsAlive()) {
			if (Visible_Targets.Count > 0) {
				int r = (int)Random.Range(0f, Visible_Targets.Count);
				target = Visible_Targets.ToArray()[r];
				if (CompareTag("CC")) {
					if (!melee) {
						Mouvement(target);
					}
				} else if (CompareTag("Tir")) {
					//float rand = Random.Range(3.0f, 4.0f);
					//InvokeRepeating("Shoot", 2, rand);
					//Shoot();
					if (shooter != null && health != null && health.IsAlive())
						shooter.SetShooting(true);
				}
			} else {
				if (shooter != null && health != null && health.IsAlive())
					shooter.SetShooting(false);
				if (CompareTag("CC")) {
					Stop();
				}
			}
		} else {
			Stop();
		}
        //InvokeRepeating("Shoot", 2, rand);
        //Shoot(Target, Dir_To_Target);
    }

    IEnumerator FindTargetsWithDelay(float Delay){
        while (true)
        {
            yield return new WaitForSeconds(Delay);
            FindVisibleTarget();
        }
    }

    void FindVisibleTarget(){
        Visible_Targets.Clear();
        Collider[] Target_In_View_Radius = Physics.OverlapSphere(transform.position, View_Radius, Target_Mask);

        for (int i = 0; i < Target_In_View_Radius.Length; i++){
			Transform Target = Target_In_View_Radius[i].transform;
			Vector3 Dir_To_Target = (Target.position - transform.position).normalized;

			if (Vector3.Angle(transform.forward, Dir_To_Target) < View_Angle/2){
                float dst_To_Target = Vector3.Distance(transform.position, Target.position);

				if (Physics.Raycast(transform.position, Dir_To_Target, dst_To_Target, Target_Mask) && !Physics.Raycast(transform.position, Dir_To_Target, dst_To_Target, Obstacle_Mask)) {
					Visible_Targets.Add(Target);
                }
            }
        }
    }

    public Vector3 DirFromAngle(float Angle_In_Degrees, bool Angle_Is_Global){
        if (!Angle_Is_Global){
            Angle_In_Degrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(Angle_In_Degrees * Mathf.Deg2Rad), 0, Mathf.Cos(Angle_In_Degrees * Mathf.Deg2Rad));
    }

    private void Shoot()
    {
        /*Vector3 direction = target.position - transform.position;

        /* bullet = Instantiate(projectile, canon.position, canon.rotation);

        bullet.AddForce(8, 0, 0, ForceMode.Impulse);

        Destroy(bullet.gameObject, 2);*/

		/*
        //Rigidbody bullet = (Rigidbody)Instantiate(projectile, transform.position + transform.forward, transform.rotation);
        Rigidbody bullet;
        //bullet = Instantiate(projectile, canon.position, canon.rotation) as Rigidbody;
        bullet = Instantiate(projectile, canon.position, canon.rotation) as Rigidbody;
        print("Rotation : " + transform.rotation);
        //0.0, 0.7, 0.0, 0.7

        print("Position : " + canon.position);
        //-26.4, 1.1, 0.0

        //bullet.AddForce(transform.forward * bulletImpulse, ForceMode.Impulse);
        bullet.velocity = transform.TransformDirection(Vector3.forward * bulletImpulse);

        Destroy(bullet.gameObject, 2);*/
		Debug.Log("Shooting");
    }


    private void Mouvement(Transform cible)
    {
        //Si la variable "vieActuelle" est supérieur a 0
        //if (pdv > 0)
        //{
		if (cible != null) {
	        Debug.DrawLine(cible.transform.position, maTransform.position, Color.blue);
	        agent.destination = cible.position;//le squelette se dirige vers le joueur
		}
//        print("Bouge :" + agent.destination + " => " + cible.position);
        //}
    }

    //L'ennemi reste a sa position actuelle
    private void Stop()
    {
        //print("NE BOUGE PLUS !!");
        agent.destination = transform.position;
    }

	public void SetMelee(bool m) {
		melee = m;
	}
}
