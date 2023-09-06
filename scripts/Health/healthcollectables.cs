using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthcollectables : MonoBehaviour
{
    [SerializeField] private float healthvalue;

    [SerializeField] private AudioClip pickup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            soundmanager.instance.playsound(pickup);
            collision.GetComponent<Health>().addhealth(healthvalue);
            gameObject.SetActive(false);
        }
    }
}
