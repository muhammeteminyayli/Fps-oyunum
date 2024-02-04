using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    
    private PickAndDrop pick;

    void Start()
    {
      pick =GetComponent<PickAndDrop>(); 
    }

    
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.E)){
            pick.CurrentIndex+=1;
        }
        else if(Input.GetKeyUp(KeyCode.Q)){
            pick.CurrentIndex-=1;
        }
    }
}
