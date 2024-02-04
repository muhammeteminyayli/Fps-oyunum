using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class PickAndDrop : MonoBehaviour
{
    // Start is called before the first frame update
    public int CurrentIndex{
        get{return currentIndex;}
        set{currentIndex=value;ChangeWeapon();}
    }
    private int currentIndex;
    public string[] weaponsString;
    [SerializeField]private GameObject[] weapons;
    [SerializeField]private GameObject weaponSpanPoint;
    [SerializeField]private Camera mainCam;
    void Start()
    {
        mainCam=Camera.main;
        for(int i=0;i<weapons.Length;i++){
            weapons[i].SetActive(false);
            weaponsString[i]=weapons[i].gameObject.name;
        }
    weapons[currentIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G)){
            if(weaponsString[currentIndex]=="fist"){
                return;
            }
            weaponsString[currentIndex]="fist";
            weapons[currentIndex].SetActive(false);
            GameObject instantiedObjct=Instantiate(weapons[currentIndex].gameObject,
                weaponSpanPoint.transform.position,weaponSpanPoint.transform.rotation);
            instantiedObjct.SetActive(true);
            instantiedObjct.name=weapons[currentIndex].gameObject.name;

        }
        if(Input.GetKeyDown(KeyCode.F)){
            Ray ray =mainCam.ViewportPointToRay(new Vector3(0.5f,0.5f,1));
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit,2f)){
                switch(hit.collider.gameObject.tag){
        
                case "Weapon":
                    if(weaponsString[currentIndex]!="fist"){
                        return;
                    }
                    for(int i=0;i<weapons.Length;i++){
                    weapons[i].SetActive(false);
                }
                    weapons[currentIndex].SetActive(true);
                    weaponsString[currentIndex]=hit.collider.gameObject.name;
                    Destroy(hit.collider.gameObject);
                    break;
                case "Ammo":
                    Destroy(hit.collider.gameObject);
                    break;
                }
                
                
            }
        }
    }
    void ChangeWeapon(){
        if(currentIndex>(weapons.Length-1))
            currentIndex=0;
        else if(currentIndex<0)
            currentIndex=weapons.Length-1;
        for(int i=0;i<weapons.Length;i++){
            weapons[i].SetActive(false);
        }
        if(weaponsString[currentIndex]!="fist")
            weapons[currentIndex].SetActive(true);

        weapons[currentIndex].SetActive(true);
    }
}
