using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedBehavior : MonoBehaviour
{
	private bool isPulled = false;
	private float timeTarget = 10;

	AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
		if (isPulled)
		{
			if (timeTarget > 0)
			{
				timeTarget -= Time.deltaTime;
			}
			else
			{
				Destroy(gameObject);
			}
		}
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "AllGround")
        {
            Rigidbody weed = GetComponent<Rigidbody>();
            Collider weedCol = GetComponent<Collider>();
            weed.useGravity = true;
            weedCol.isTrigger = false;
			sound.Play(0);

			isPulled = true;
        }
    }
}
