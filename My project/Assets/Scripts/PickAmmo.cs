using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAmmo : MonoBehaviour
{
    // Start is called before the first frame update
    private PickAndDrop PickDrop;
    private AmmoSystem AmmoS;

    void Start()
    {
        PickDrop=GameObject.FindWithTag("Player").GetComponent<PickAndDrop>();
        AmmoS=GameObject.FindWithTag("Player").GetComponent<AmmoSystem>();

    }

    private void OnDestroy(){
        AmmoS.weaponsInfo[PickDrop.CurrentIndex].totalAmmo+=
        AmmoS.weaponsInfo[PickDrop.CurrentIndex].maximumAmmo;
    }
    
}
