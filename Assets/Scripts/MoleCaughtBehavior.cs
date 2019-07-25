using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleCaughtBehavior : MonoBehaviour
{
	Vector3 pos;
	float diff;
	public string tool;

    // Start is called before the first frame update
    void Start()
    {
		if (tool == "Net")
		{
			diff = 1.5f;
		}
		else
		{
			diff = transform.parent.position.y - transform.position.y;
		}
	}

    // Update is called once per frame
    void Update()
    {
		pos = transform.parent.position;
		pos.y = transform.parent.position.y - diff;

		transform.position = pos;
    }
}
