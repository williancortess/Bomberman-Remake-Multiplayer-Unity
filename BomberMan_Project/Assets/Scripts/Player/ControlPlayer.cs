using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ControlPlayer : NetworkBehaviour
{
    
    Vector3 movement;
    int floorMask;
    Rigidbody playerRigibody;
    Animator anim;
   
    float bombaTimer = 0f;
    public GameObject bomba;

    [SyncVar]
    public string m_playerName = "Player";

    [SyncVar]
    public Color m_playerColor = Color.white;

    public TextMesh m_textName;
    public TextMesh m_textName2;

    [SyncVar]
    public float speed = 6f;

    //[SyncVar]
    //public int fireRate = 1;

    [SyncVar]
    public int addBomb = 1;

    [SyncVar]
    public int intBombAux = 0;

    // Use this for initialization
    void Start () {
        m_textName.text = m_playerName;
        m_textName.color = m_playerColor;

        m_textName2.text = m_playerName;
        m_textName2.color = m_playerColor;
    }

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigibody = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update () {
        if (isLocalPlayer)
        {

            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            Vector3 temp = transform.localEulerAngles;

            if (Input.GetKey(KeyCode.UpArrow))
            {
                temp.y = 0.0f;
                playerRigibody.transform.rotation = Quaternion.Euler(temp);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                temp.y = 180.0f;
                playerRigibody.transform.rotation = Quaternion.Euler(temp);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                temp.y = 270.0f;
                playerRigibody.transform.rotation = Quaternion.Euler(temp);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                temp.y = 90.0f;
                playerRigibody.transform.rotation = Quaternion.Euler(temp);
            }

            Move(h, v);
            Animating(h, v);

            if (intBombAux > 0)
            {
                bombaTimer += Time.deltaTime;

                if (bombaTimer > 3.0f)
                {
                    //intBombAux -= 1;
                    //if (intBombAux < 0)
                    //{
                        intBombAux = 0;
                    //}
                    bombaTimer = 0;
                }

            }

            



            if ((Input.GetKeyDown("z") || Input.GetKeyDown(KeyCode.Space)) && intBombAux < addBomb)
            {
                intBombAux += 1;
                Cmd_Shoot();
            }

        }

       

    }

    /*public void SetRetiraAddBomb(int iBomb)
    {
        Debug.Log("RETIRA BOMBA");
        //Cmd_RetiraBomba();
        intBombAux -= iBomb;

        if(intBombAux < 0)
        {
            intBombAux = 0;
        }
    }*/

    //[Command]
    //public void Cmd_RetiraBomba()
    //{
    //    intBombAux -= 1;
    //}


    [Command] //commands are server-side!
    public void Cmd_Shoot()
    {
        //Faz o Spawn dos bullets no servidor - Todos recebem a informacao
        //intBombAux += 1;
        GameObject BombObj = (GameObject)Instantiate(bomba, transform.position, transform.rotation);
        NetworkServer.Spawn(BombObj);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PuSpeed")
        {
            speed += 2;
            Destroy(other.gameObject);
        }else

        if(other.gameObject.tag == "FbAb")
        {
            addBomb += 1;
            Destroy(other.gameObject);
        }
    }
    

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigibody.MovePosition(transform.position + movement);
    }


    void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }
   
}
