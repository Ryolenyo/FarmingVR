using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyBehavior : MonoBehaviour
{
    private float meter;
    private float currentMeter;
    private float speed;
    public float money;

    [SerializeField] Text moneyText;


    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = money.ToString();

        speed = 0.01f;
        currentMeter = transform.position.y;
        meter = currentMeter + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMeter > meter)
        {
            Destroy(this.gameObject);
        }
        else
        {
            currentMeter += speed;
            transform.position = new Vector3(transform.position.x, currentMeter, transform.position.z);
        }
    }
}
