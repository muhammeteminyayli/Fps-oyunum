using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSystem : MonoBehaviour
{
    private Camera mainCam;
    private float lastTime;
    [SerializeField]private float distance;
    [SerializeField] private float fireRate;
    private AmmoSystem AmmoS;
    private PickAndDrop PickDrop;
    private AudioSource audioSource;
    [SerializeField] private AudioClip ShoutSound;
    public GameObject bulletHole;
    void Start()
    {
        mainCam=Camera.main;
        AmmoS=GetComponent<AmmoSystem>();
        PickDrop=GetComponent<PickAndDrop>();
        audioSource=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)&&AmmoS.weaponsInfo[PickDrop.CurrentIndex].currentAmmo>0 &&Time.time-lastTime>fireRate){
            
            audioSource.PlayOneShot(ShoutSound);
            Ray ray=mainCam.ViewportPointToRay(new Vector3(0.5f,0.5f,1));
            RaycastHit hit;
            AmmoS.weaponsInfo[PickDrop.CurrentIndex].currentAmmo-=1;
            lastTime=Time.time;
            if(Physics.Raycast(ray,out hit,distance)){
                switch(hit.collider.gameObject.tag){
                    case "Enemy":
                    int damage = Random.Range(5,25);
                    hit.collider.gameObject.GetComponent<HealthSystem>().Health-=damage;
                    Debug.Log(damage);
                    break;
                    case "Other":
                    Instantiate(bulletHole,hit.point+new Vector3(0,0,-0.1f),Quaternion.LookRotation(-hit.normal));
                    break;

                }
                
            }
        }
    }
}
