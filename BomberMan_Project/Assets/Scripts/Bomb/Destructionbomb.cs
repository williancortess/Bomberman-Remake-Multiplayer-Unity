using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Destructionbomb : NetworkBehaviour
{
	float auxTime = 0.0f;
	float timeDestruction = 3.0f;
	public GameObject explosion;
    //GameObject player;
    //public ControlPlayer controlPlayer;

    void Start()
    {
        /*GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject g in players)
        {
            if(g.GetComponent<NetworkIdentity>().isLocalPlayer)
                controlPlayer = g.GetComponent<ControlPlayer>();
        }  */
              
        //player = GameObject.FindGameObjectWithTag("Player");        
    }

    // Update is called once per frame
    void Update () {

      //  if (isServer)
      //  {
            auxTime += Time.deltaTime;
            if (auxTime > timeDestruction)
            {


                //Instantiate(explosion, transform.position, transform.rotation);
                Cmd_Explosion();
                //controlPlayer.SetRetiraAddBomb(1);
                Destroy(gameObject);
                //ExplosionDamage(gameObject.transform.position, 0.3f);
        }

            ExplosionDamage(gameObject.transform.position, 0.3f);

       // }

        
    }

    [Command] //commands are server-side!
    public void Cmd_Explosion()
    {
        //Faz o Spawn dos bullets no servidor - Todos recebem a informacao
        GameObject BombObj = (GameObject)Instantiate(explosion, transform.position, transform.rotation);
        NetworkServer.Spawn(BombObj);

        //Debug.Log("CHAMA RETIRA BOMBA");
        //controlPlayer.SetRetiraAddBomb(1);

    }

    void ExplosionDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].gameObject.tag == "Fb")
            {
                Cmd_Explosion();
                Destroy(gameObject);
            }
        }
    }
    
}
