using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponUserInterface : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private TMP_Text weaponText;
    [SerializeField]private TMP_Text ammoText;
    private AmmoSystem AmmoS;
    private PickAndDrop PickDrop;
    void Start()
    {
        AmmoS=GameObject.FindWithTag("Player").GetComponent<AmmoSystem>();
        PickDrop=GameObject.FindWithTag("Player").GetComponent<PickAndDrop>();

    }

    // Update is called once per frame
    void Update()
    {
        weaponText.text=$"{PickDrop.weaponsString[PickDrop.CurrentIndex]}";
        if(PickDrop.weaponsString[PickDrop.CurrentIndex]=="fist"){
            ammoText.text="0/0";
        }
        else{
                ammoText.text=$"{AmmoS.weaponsInfo[PickDrop.CurrentIndex].currentAmmo }/{AmmoS.weaponsInfo[PickDrop.CurrentIndex].totalAmmo}";
        }
        
    }
}
