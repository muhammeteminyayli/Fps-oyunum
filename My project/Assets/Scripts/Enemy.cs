using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    private Rigidbody enemy;
    private HealthSystem healthSystem;
    private float bekle;
    
    

    void Start()
    {   
        enemy = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        healthSystem = player.GetComponent<HealthSystem>();
    }

    void Update()
    {
        
        if(Vector3.Distance(enemy.position, player.position)<5f){

            yonel();
            float distance = Vector3.Distance(enemy.position, player.position);

  
            if (distance < 1.5f&& bekle<=0)
                {
                dur();
                bekle=2;
            }
            bekle-=Time.deltaTime;
        }
        
    }

    void yonel()
    {
        Vector3 yon = (player.position - transform.position).normalized;
        enemy.velocity = new Vector3(yon.x * 3, yon.y, yon.z * 3);
        transform.LookAt(new Vector3(player.position.x, player.position.y, player.position.z));
    }

    void dur()
    {
        enemy.velocity = Vector3.zero;
        if (healthSystem != null)
        {

            healthSystem.Health -= 5;
            
        }
    }
    

}
