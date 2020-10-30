using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    UnityEngine.AI.NavMeshAgent nav;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(player.position);
    }
}
