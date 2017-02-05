using UnityEngine;
using UnityEngine.Networking;
using Prototype.NetworkLobby;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class NetGameManager : NetworkBehaviour
{
    static public NetGameManager sInstance = null;
 
    public Text m_text;
    

    [SyncVar]
    int floorTime;

    void Awake()
    {
        sInstance = this;
    }

    void Start()
    {
        StartCoroutine(GameCoroutine());
    }
    
    void Update()
    {
        
    }

    public override void OnStartServer()
    {        
        
        base.OnStartServer();
    }


    IEnumerator GameCoroutine()
    {
        float remainingTime = 300.0f;
        floorTime = Mathf.FloorToInt(remainingTime);

        while (remainingTime > 1)
        {
            remainingTime -= Time.deltaTime;
            int newFloorTime = Mathf.FloorToInt(remainingTime);
            
                floorTime = newFloorTime;
                m_text.text = "Macth ends in: " + floorTime ;
                if(floorTime <= 0)
                {
                ExplosionDamage(gameObject.transform.position, 500.0f);

            }
            yield return null;
        }
    }

    void ExplosionDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].gameObject.tag == "Player")
            {
                Destroy(hitColliders[i].gameObject);
            }
        }
    }

}
