using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyprojectile : enemy_damage
{
    [SerializeField] private float speed;
    [SerializeField] private float resettime;
    private float lifetime;
    public void activateprojectile()
    {
        lifetime = 0;
        gameObject.SetActive(true); 
    }
    private void Update()
    {
        float movementspeed=speed * Time.deltaTime;
        transform.Translate(movementspeed,0,0);
        if(lifetime > resettime)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);//first goto parent script and then next method
        gameObject.SetActive(false);

    }
}
