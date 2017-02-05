using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;

public class BombAttack : NetworkBehaviour
{
	//GameObject player;
	//PlayerHealth playerHealth;
	Animator anim;


	void Awake ()
	{


    }

	//https://docs.unity3d.com/ScriptReference/Physics.OverlapSphere.html
	void ExplosionDamage(Vector3 center, float radius) {
		Collider[] hitColliders = Physics.OverlapSphere(center, radius);

		for (int i = 0; i < hitColliders.Length; i++) {
			if(hitColliders[i].gameObject.tag == "Box")
			{
				Destroy(hitColliders[i].gameObject);
			} 

			if(hitColliders[i].gameObject.tag == "Player")
			{
                Destroy(hitColliders[i].gameObject);
                //if(playerHealth.currentHealth > 0)
                //{
                //playerHealth.TakeDamage (100);
                //}
            } 
		}
	}

	void Start () {

        //player = GameObject.FindGameObjectWithTag("Player");
        //playerHealth = player.GetComponent<PlayerHealth>();
        ExplosionDamage (gameObject.transform.position, 0.8f);

    }
    

	void Update () {

	}
}
