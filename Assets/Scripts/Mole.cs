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
	public float upTime = 6.07;
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
