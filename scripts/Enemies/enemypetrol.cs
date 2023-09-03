using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemypetrol : MonoBehaviour
{
    [Header ("Petrol points")]
    [SerializeField] private Transform leftedge;
    [SerializeField] private Transform rightedge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField]private float speed;
    private Vector3 init;
    private bool movingleft;


    private void Awake()
    {
        init = enemy.localScale;
    }


    private void Update()
    {
        if (movingleft)
        {
            if(enemy.position.x >= leftedge.position.x)
            {
                moveindirection(-1);
            }
            else
            {
                //change direction
                directionchange();
            }
        }
        else
        {
            if (enemy.position.x <= rightedge.position.x)
            {
                moveindirection(1);
            }
            else
            {
                //change direction
                directionchange();
            }
            
        }
    }
    private void directionchange()
    {
        movingleft = !movingleft;
    }


    private void moveindirection(int _direction)
    {
        //face the right direction 
        enemy.localScale = new Vector3(Mathf.Abs( init.x) * _direction, init.y, init.z);

        //move the enemy
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y,enemy.position.z);
    }
}
