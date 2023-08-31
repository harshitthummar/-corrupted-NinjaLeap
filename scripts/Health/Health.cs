using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startinghealth;
    private Animator anim;

    //we can get value from anywhere but we cant set it unless in this script
    public float currenthealth { get; private set; }
    private bool dead;

    private void Awake()
    {
        currenthealth = startinghealth;
        anim = GetComponent<Animator>();
    }

    public void takedamage(float _damage)
    {
        
        currenthealth = Mathf.Clamp(currenthealth - _damage, 0, startinghealth);
    
    
        if(currenthealth > 0 ) 
        {
            //player damage
            anim.SetTrigger("hurt");
        }
        else
        {
            if(!dead)
            {
                anim.SetTrigger("die");
                GetComponent<playermovement>().enabled = false;
                dead = true;
            }
            //player dead
            
        }
    }

    public void addhealth(float _value)
    {
        currenthealth = Mathf.Clamp(currenthealth + _value, 0, startinghealth);
    }
  

}
