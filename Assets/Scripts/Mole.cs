using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
	private bool isCatch = true;
    private bool isCatchByTrapper = false;
    private bool isGoDown = false;
    private bool isGoUp = false;

    //public float eatTime = 5;
    public float currentTime = 0;
	public float upTime = 6.07f;
    public float comebackTime = 15;

	public GameObject[] animation;
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
        GameObject trapper = GameObject.FindWithTag("Trapper");

		if (!isCatch)
		{
			if (isGoUp)
			{
				animation[0].SetActive(true);
				animation[1].SetActive(false);
				animation[2].SetActive(false);

				if (currentTime < upTime)
				{
					currentTime += Time.deltaTime;
				}
				else
				{
					isGoUp = false;
					isGoDown = true;
					currentTime = 0;
				}
			}
			else if (isGoDown)
			{
				animation[0].SetActive(false);
				animation[1].SetActive(true);
				animation[2].SetActive(false);

				if (animation[1].transform.localPosition.y > -0.3f)
				{
					animation[1].transform.position = new Vector3(animation[1].transform.position.x, animation[1].transform.position.y - 0.005f, animation[1].transform.position.z);
				}
				else
				{
					animation[1].SetActive(false);
					//animation[1].transform.localPosition.y = -0.07f;

					if (trapper != null)
					{
						animation[0].SetActive(true);
						animation[2].SetActive(false);

						transform.position = new Vector3(trapper.transform.position.x, transform.position.y, trapper.transform.position.z);
                        transform.rotation = Quaternion.identity;
					}
					else
					{
						randomGround = Random.Range(0, 17);
						transform.localPosition = new Vector3(target[randomGround].transform.position.x + 0.25f , transform.position.y, target[randomGround].transform.position.z - 0.25f);
                        transform.rotation = Quaternion.identity;
					}

					isGoUp = true;
				}
			}
		}
		else
		{
			if (currentTime < comebackTime)
			{
				currentTime += Time.deltaTime;
			}
			else
			{
				isCatch = false;

				Rigidbody mole = GetComponent<Rigidbody>();
				Collider moleCol = GetComponent<Collider>();

				mole.useGravity = false;
				moleCol.isTrigger = true;

				isGoUp = false;
			}
		}
    }
}
