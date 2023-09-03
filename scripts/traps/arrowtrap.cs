using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowtrap : MonoBehaviour
{
    [SerializeField] private float attackcooldown;
    
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] arrows;
    private float cooldown;

    private void attack()
    {
        cooldown = 0;

        arrows[findarrow()].transform.position = firepoint.position;
        arrows[findarrow()].GetComponent<enemyprojectile>().activateprojectile();


    }

    private int findarrow()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            if (!arrows[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
    private void Update()
    {
        cooldown += Time.deltaTime;
        if(cooldown >= attackcooldown)
        {
            attack();
        }
    }


}
