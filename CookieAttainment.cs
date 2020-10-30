using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieAttainment : MonoBehaviour
{
    float x;
    float y;
    float z;
    public int scoreValue = 1;
    public int count = 0;
    GameObject enemy;
    GameObject player;
    GameObject terrain;
    bool playerContact;
    Vector3 pos;
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player");
        terrain = GameObject.FindGameObjectWithTag("Terrain");
        RandomPosition();
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject == player) || (other.gameObject == enemy))
        {

            if (other.gameObject == player)
            {
                ScoreManager.score += scoreValue;
                RandomPosition();
                Debug.Log(" Cookie");
            }


        }
        else
        {
            while (other.gameObject != player)
            {
               
                RandomPosition();
                Debug.Log("Else From Cookie");
                count++;
                if (count > 20)
                {
                    x = 81.09721f;
                    y = 0.3331361f;
                    z = 90.3978f;
                    pos = new Vector3(x, y, z);
                    count = 0;
                    return;
                }
            }
        }
    }
    

    public void RandomPosition()
    {
        x = Random.Range(-286, 279);
        y = .5f;
        z = Random.Range(-286, 280);
        pos = new Vector3(x, y, z);
        transform.position = pos;
        Debug.Log("Random PositionCallled");
    }

   
}
