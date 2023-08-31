using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthcollectables : MonoBehaviour
{
    [SerializeField] private float healthvalue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().addhealth(healthvalue);
            gameObject.SetActive(false);
        }
    }
}
