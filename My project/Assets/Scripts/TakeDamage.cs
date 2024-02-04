using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    // Start is called before the first frame update
    private  void  OnTriggerEnter(Collider collision) {
        
        

        if(collision.gameObject.tag=="Player"){
            HealthSystem healthSystem=collision.gameObject.GetComponent<HealthSystem>();
            healthSystem.Health-=20;
            healthSystem.StopCoroutine("Spawn");
            healthSystem.StartCoroutine("Spawn");
        }

       

        
    }
}
