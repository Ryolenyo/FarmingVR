using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Mole : MonoBehaviour
{
    public bool isCatch = true;
    public bool isCatchByTrapper = false;
    public bool isGoDown = false;
    public bool isGoUp = false;

    //public float eatTime = 5;
    public float currentTime = 0;
    public float comebackTime = 15;
    public float startPos = -0.79f;

    public GameObject[] animation;
    public GameObject[] target;
    public int randomGround = 15;
	public int randomed;
    private float speed = 0.01f;

	private float timing = 6.06f;
	
	AudioSource sound;
	public AudioClip getOut;
	public AudioClip squeak;
	private bool outed = false;
	private bool squeaked = false;

    // Start is called before the first frame update
    void Start()
    {
		sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject trapper = GameObject.FindWithTag("Trapper");

        if (!isCatch)
        {
            Animation goUp = animation[0].GetComponent<Animation>();
            if (isGoUp)
            {
				if (timing > 0)
				{
					if (timing <= 5 && !outed)
					{
						sound.PlayOneShot(getOut, 0.7f);
						outed = true;
					}
					else if (timing <= 3 && !squeaked)
					{
						sound.PlayOneShot(squeak, 0.7f);
						squeaked = true;
					}
					timing -= Time.deltaTime;
				}

                if (!goUp.IsPlaying("Take 001"))
                {
					timing = 6.06f;
					outed = false;
					squeaked = false;

                    currentTime = 0;
                    isGoUp = false;
                    isGoDown = true;
                }
            }
            else if (isGoDown)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.005f, transform.position.z);

				if (transform.position.y < -1 && !outed)
				{
					sound.PlayOneShot(getOut, 0.7f);
					outed = true;
				}

                if (transform.position.y < -1.8f)
                {
					outed = false;
                    isGoDown = false;
                    animation[0].SetActive(false);
                }
            }
            else
            {
                if (trapper != null)
                {
                    transform.position = new Vector3(trapper.transform.position.x, startPos, trapper.transform.position.z);
                    transform.rotation = Quaternion.identity;
                }
                else
                {
                    randomed = Random.Range(0, randomGround);
					
                    transform.localPosition = new Vector3(target[randomed].transform.position.x + 0.25f, startPos, target[randomed].transform.position.z);
                    transform.rotation = Quaternion.identity;
                }

                isGoUp = true;
                animation[0].SetActive(true);
                animation[1].SetActive(false);
                goUp.Play("Take 001");
            }
        }
        else
        {
            if (currentTime > comebackTime)
            {
                isCatch = false;

                Rigidbody mole = GetComponent<Rigidbody>();
                Collider moleCol = GetComponent<Collider>();
				mole.velocity = new Vector3(0, 0, 0);
				mole.angularVelocity = new Vector3(0, 0, 0);
                mole.useGravity = false;
                moleCol.isTrigger = true;

                isGoUp = false;
                isGoDown = false;
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
            Debug.Log("CATCH");

            animation[0].SetActive(false);
            animation[1].SetActive(true);

            Animation caught = animation[1].GetComponent<Animation>();
            caught.Play("Take 001");

            Rigidbody mole = GetComponent<Rigidbody>();
            Collider moleCol = GetComponent<Collider>();
			mole.useGravity = true;
            //moleCol.isTrigger = false;

			if (!isCatch)
			{
				Debug.Log("set zero");
				currentTime = 0;
				isCatch = true;
			}
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //When mole be caught by trapper, delete script
        if ((other.tag == "Trapper" || other.tag == "Net") && !isGoUp)
        {
            gameObject.transform.parent = other.transform;
            MoleCaughtBehavior sc = gameObject.AddComponent<MoleCaughtBehavior>();
			sc.tool = other.tag;
            animation[0].SetActive(false);
            animation[1].SetActive(true);

            Animation caught = animation[1].GetComponent<Animation>();
            caught.Play("Take 001");
			
			Destroy(gameObject.GetComponent<Throwable>());
			Destroy(gameObject.GetComponent<Interactable>());
            Destroy(this);
        }
		else if (other.tag == "Plant" || other.tag == "Sapling")
		{
			if(transform.position.y < -1)
			{
				Debug.Log("STOLE");
				PlantBehavior plant = other.gameObject.GetComponent<PlantBehavior>();
				plant.stolen = true;
			}
		}
    }

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Net")
		{
			gameObject.transform.parent = other.transform;
            MoleCaughtBehavior sc = gameObject.AddComponent<MoleCaughtBehavior>();
			sc.tool = other.tag;

            animation[0].SetActive(false);
            animation[1].SetActive(true);

            Animation caught = animation[1].GetComponent<Animation>();
            caught.Play("Take 001");
			
			Destroy(gameObject.GetComponent<Throwable>());
			Destroy(gameObject.GetComponent<Interactable>());
            Destroy(this);
		}
	}
}