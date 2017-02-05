using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ParticulasIA : NetworkBehaviour
{
    bool colidiu = false;
    int fireRate = 3;
	public GameObject[] eixo1;
	public GameObject[] eixo2;
	public GameObject[] eixo3;
	public GameObject[] eixo4;
	public GameObject fire;
    
    //GameObject[] players;
    //ControlPlayer controlPlayer;

    void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        //controlPlayer = player.GetComponent<ControlPlayer>();
    }

	void Start () {
        /*players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject g in players)
        {
            if (g.GetComponent<NetworkIdentity>().isLocalPlayer)
                controlPlayer = g.GetComponent<ControlPlayer>();
        }*/


        InstantiateBomb();
        InstantiateBomb2();
        InstantiateBomb3();
        InstantiateBomb4();
    }

	void Update () {
	
	}
	

	/*void InstantiateBomb() {
		fireRate = PlayerMovement.fireRate;

		for (int i1 = 0; i1 <= fireRate; i1++) {
			Instantiate(fire, eixo1[i1].transform.position, fire.transform.rotation);
		}

		for (int i2 = 0; i2 <= fireRate; i2++) {
			Instantiate(fire, eixo2[i2].transform.position, fire.transform.rotation);
		}

		for (int i3 = 0; i3 <= fireRate; i3++) {
			Instantiate(fire, eixo3[i3].transform.position, fire.transform.rotation);
		}

		for (int i4 = 0; i4 <= fireRate; i4++) {
			Instantiate(fire, eixo4[i4].transform.position, fire.transform.rotation);
		}

	}*/

    bool InstantiateBomb()
    {
        //fireRate = controlPlayer.fireRate;
        for (int i1 = 0; i1 <= fireRate; i1++)
        {
            if (i1 == 0)
            {
                Cmd_Shoot(eixo1[0].transform.position);
                Instantiate(fire, eixo1[0].transform.position, fire.transform.rotation);
            }
            else

            if (GetColider(eixo1[i1 - 1].transform.position, 0.1f) == false)
            {
                Cmd_Shoot(eixo1[i1].transform.position);
                Instantiate(fire, eixo1[i1].transform.position, fire.transform.rotation);
            }
            else
            {
                return false;
            }
        }

        return true;

    }

    bool InstantiateBomb2()
    {
        //fireRate = controlPlayer.fireRate;


        for (int i2 = 0; i2 <= fireRate; i2++)
        {
            
            if (i2 == 0)
            {
                Cmd_Shoot(eixo2[0].transform.position);
                Instantiate(fire, eixo2[0].transform.position, fire.transform.rotation);
            }
            else

            if (GetColider(eixo2[i2 - 1].transform.position, 0.1f) == false)
            {
                Cmd_Shoot(eixo2[i2].transform.position);
                Instantiate(fire, eixo2[i2].transform.position, fire.transform.rotation);
            }
            else
            {
                return false;
            }
        }

        return true;

    }


    bool InstantiateBomb3()
    {
        //fireRate = controlPlayer.fireRate;



        for (int i3 = 0; i3 <= fireRate; i3++)
        {

            if (i3 == 0)
            {
                Cmd_Shoot(eixo3[0].transform.position);
                Instantiate(fire, eixo3[0].transform.position, fire.transform.rotation);
            }else

            if (GetColider(eixo3[i3 - 1].transform.position, 0.1f) == false)
            {
                Cmd_Shoot(eixo3[i3].transform.position);
                Instantiate(fire, eixo3[i3].transform.position, fire.transform.rotation);
            }
            else
            {
                return false;
            }
        }

        return true;


    }

    bool InstantiateBomb4()
    {
        //fireRate = controlPlayer.fireRate;

        for (int i4 = 0; i4 <= fireRate; i4++)
        {
            if (i4 == 0)
            {
                Cmd_Shoot(eixo4[0].transform.position);
                Instantiate(fire, eixo4[0].transform.position, fire.transform.rotation);
            } else

                if(GetColider(eixo4[i4 - 1].transform.position, 0.1f) == false)
                {
                Cmd_Shoot(eixo4[i4].transform.position);
                Instantiate(fire, eixo4[i4].transform.position, fire.transform.rotation);
                }else
            {
                return false;
            }
        }

        return true;
    }

    [Command]
    public void Cmd_Shoot(Vector3 pos)
    {
        //Faz o Spawn dos bullets no servidor - Todos recebem a informacao
        GameObject FireObj = (GameObject)Instantiate(fire, pos, fire.transform.rotation);
        NetworkServer.Spawn(FireObj);
    }

    bool GetColider(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].gameObject.tag == "Box" || hitColliders[i].gameObject.tag == "Map")
            {
                return true;
            }
            
        }
        return false;
    }
}
