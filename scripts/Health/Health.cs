using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startinghealth;
    private Animator anim;

    //we can get value from anywhere but we cant set it unless in this script
    public float currenthealth { get; private set; }
    private bool dead;

    [Header("IFrames")]
    [SerializeField] private float iframeduration;
    [SerializeField] private int numberofflashes;
    private SpriteRenderer spiterend;

    private void Awake()
    {
        currenthealth = startinghealth;
        anim = GetComponent<Animator>();
        spiterend = GetComponent<SpriteRenderer>();
    }

    public void takedamage(float _damage)
    {
        
        currenthealth = Mathf.Clamp(currenthealth - _damage, 0, startinghealth);
    
    
        if(currenthealth > 0 ) 
        {
            //player damage
            anim.SetTrigger("hurt");
            StartCoroutine(invlnerability());
        }
        else
        {
            if(!dead)
            {
                anim.SetTrigger("die");

                //disable player after dead
                if(GetComponent<playermovement>() != null)
                    GetComponent<playermovement>().enabled = false;
                
                //disable enemy after kills player
                if(GetComponentInParent<enemypetrol>() != null)
                    GetComponentInParent<enemypetrol>().enabled = false;

                if (GetComponent<melee_enemy>() != null)
                    GetComponent<melee_enemy>().enabled = false;        
                dead = true;
            }
            //player dead
            
        }
    }

   
    public void addhealth(float _value)
    {
        currenthealth = Mathf.Clamp(currenthealth + _value, 0, startinghealth);
    }

    private IEnumerator invlnerability()
    {
        Physics2D.IgnoreLayerCollision(10,11,true);
        for (int i = 0; i < numberofflashes; i++)
        {
            spiterend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iframeduration / (numberofflashes * 2));
            spiterend.color = Color.white;
            yield return new WaitForSeconds(iframeduration / (numberofflashes * 2));
        }

        Physics2D.IgnoreLayerCollision(10, 11, false);
    }

}
