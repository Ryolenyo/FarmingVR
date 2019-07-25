using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class MoleBehavior : MonoBehaviour
{
    private bool isCatch = true;
    private bool isCatchByTrapper = false;
    private bool isEat = false;
    private bool isGoUp = false;

    public float eatTime = 5;
    public float currentTime = 0;
    public float comebackTime = 15;

    public GameObject[] target;
    public int randomGround = 15;
    private float speed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //finding trapper
        GameObject trapper = GameObject.FindWithTag("Trapper");

        //State
        if (!isCatch)
        {
            if (isEat)
            {
                //Wait x sec for player to catch while eating
                if (currentTime > eatTime)
                {
                    //Ready to go down
                    currentTime = 0;
                    isEat = false;
                    isGoUp = false;
                }
                else
                {
                    currentTime += Time.deltaTime;
                    //Enable Throwable script
                    Throwable script = GetComponent<Throwable>();
                    script.enabled = true;
                }

            }
            else
            {
                if (isGoUp)
                {
                    if (transform.position.y < 0.4f)
                    {
                        //Go Up from new target ground
                        transform.position = new Vector3(transform.position.x, transform.position.y + 0.005f, transform.position.z);
                    }
                    else
                    {
                        //Reach nice spot ! Ready to eat
                        currentTime = 0;
                        isEat = true;
                    }

                }
                else
                {
                    if (transform.position.y > -0.5f)
                    {
                        //unable throwable script
                        Throwable script = GetComponent<Throwable>();
                        script.enabled = false;

                        //Go Down
                        transform.position = new Vector3(transform.position.x, transform.position.y - 0.005f, transform.position.z);
                    }
                    else
                    {
                        //Luring by trapper
                        if (trapper != null)
                        {
                            //found trapper Go to trapper
                            transform.position = new Vector3(trapper.transform.position.x, trapper.transform.position.y - 1, trapper.transform.position.z);
                            transform.rotation = Quaternion.identity;
                        }
                        else
                        {
                            //Find new ground
                            randomGround = Random.Range(0, 17);
                            //Go to that position
                            transform.localPosition = new Vector3(target[randomGround].transform.position.x + 0.25f , target[randomGround].transform.position.y - 0.5f, target[randomGround].transform.position.z - 0.25f);
                            transform.rotation = Quaternion.identity;
                        }

                        //Ready to go up
                        isGoUp = true;
                    }
                }
            }
        }
        else
        {
            //Be thrown away
            if (currentTime > comebackTime)
            {
                isCatch = false;

                //Ready to go back down
                Rigidbody mole = GetComponent<Rigidbody>();
                Collider moleCol = GetComponent<Collider>();
                mole.useGravity = false;
                moleCol.isTrigger = true;

                isEat = false;
                isGoUp = false;
            }
            else
            {
                currentTime += Time.deltaTime;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //When mole be caught by player, Add gravity and trigger
        if (other.tag == "AllGround")
        {
            isCatch = true;
            Rigidbody mole = GetComponent<Rigidbody>();
            Collider moleCol = GetComponent<Collider>();
            mole.useGravity = true;
            moleCol.isTrigger = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //When mole be caught by trapper, delete script
        if (other.tag == "Trapper" || other.tag == "Net")
        {
            Debug.Log("Caughtaa");
            gameObject.transform.parent = other.transform;
            MoleCaughtBehavior sc = gameObject.AddComponent<MoleCaughtBehavior>();
            Destroy(this);
        }
    }

}