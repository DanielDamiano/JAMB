using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 1;
    //float attackTimerInitial=0;
    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    bool playerInRange;
    float timer;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();

    }


    // Update is called once per frame
    void OnTriggerEnter (Collider other)
    {
       if(other.gameObject == player)
        {
            playerInRange = true;
            //attackTimerInitial += Time.deltaTime;
        }
    }
    void OnTriggerExit (Collider other)
    {
       if(other.gameObject == player)
        {
            playerInRange = false;
            //Debug.Log(attackTimerInitial);
        }
//attackTimerInitial = 0;
    }
    void Update()
    {
        timer += Time.deltaTime;
        //if (attackTimerInitial >= 5)
        //{
            if (timer >= timeBetweenAttacks && playerInRange)
            {

                Attack();
            }
        //}
        if(playerHealth.health <= 0)
        {
            anim.SetTrigger("PlayerDead");
        }
    }
    void Attack()
    {
        timer = 0f;
        if (playerHealth.health > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
