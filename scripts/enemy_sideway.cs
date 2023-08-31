using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_sideway : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().takedamage(damage);
        }
    }
}
