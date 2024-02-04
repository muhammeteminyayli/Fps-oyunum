using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSystem : MonoBehaviour
{
    public AmmoInfo[] weaponsInfo;
    private PickAndDrop PickDrop;

    void Start()
    {
        PickDrop=GetComponent<PickAndDrop>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.R)&&
        weaponsInfo[PickDrop.CurrentIndex].currentAmmo<weaponsInfo[PickDrop.CurrentIndex].maximumAmmo&&
        weaponsInfo[PickDrop.CurrentIndex].totalAmmo>0){

         int temporaryAmmo= weaponsInfo[PickDrop.CurrentIndex].maximumAmmo-
            weaponsInfo[PickDrop.CurrentIndex].currentAmmo;
        
        if(weaponsInfo[PickDrop.CurrentIndex].totalAmmo-temporaryAmmo<=0){
            weaponsInfo[PickDrop.CurrentIndex].currentAmmo+=weaponsInfo[PickDrop.CurrentIndex].totalAmmo;
            weaponsInfo[PickDrop.CurrentIndex].totalAmmo=0;
        }
            
        else{
            weaponsInfo[PickDrop.CurrentIndex].totalAmmo-=temporaryAmmo;
            weaponsInfo[PickDrop.CurrentIndex].currentAmmo+=temporaryAmmo;
        }
        if(weaponsInfo[PickDrop.CurrentIndex].totalAmmo>=weaponsInfo[PickDrop.CurrentIndex].maximumAmmo)
            weaponsInfo[PickDrop.CurrentIndex].currentAmmo=weaponsInfo[PickDrop.CurrentIndex].maximumAmmo;
        }
    }
}
[System.Serializable] public struct AmmoInfo{
    public int currentAmmo;
    public int totalAmmo;
    public int maximumAmmo;
}