using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int startingHealth = 3;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    public int numOfHearts;

    public Image[] hearts;
    public Sprite heart;
    public Sprite emptyHeart;
    Animator anim;
    PlayerMovement playerMovement;
    bool isDead;
    bool damaged;

    private void Awake()
    {
        Debug.Log("Awake");
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        health = startingHealth;
    }

    void Update()
    {
        if(damaged)
        {
            damageImage.color = flashColor;
        }
        else {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = heart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
       
    }
    public void TakeDamage (int amount)
        {
            damaged = true;

            health -= amount;
            if(health <= 0 && !isDead)
            {
                Death();
            }

        }
        void Death()
        {
            isDead = true;
            playerMovement.enabled = false;
        }
}
