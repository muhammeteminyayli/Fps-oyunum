using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class HealthSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float health;
    [SerializeField] private GameObject deadPanel;
    
    public int  kill=0;
    private Pozisyon poz;
     [SerializeField] private TMP_Text killtext;
    [SerializeField] private TMP_Text hptext;
    [SerializeField] private Image hpImage;
  
    public int Kill { get; private set; }
     public float Health{
        get{
        return health;
        }
        set{
        health =value;
        switch(gameObject.tag){
            case "Player":
            
             hptext.text=$"HP: {health.ToString()}";
             break;
            case "Enemy":
            HpImage.rectTransform.sizeDelta=new Vector2(health/100,0.3f);
           killtext.text=$"Olüm: {kill.ToString()}";
            break;

        }
        
        
        Checker(GetGameObject());
        }
    }

    public Image HpImage { get => hpImage; set => hpImage = value; }

    void Start(){
        poz=GetComponent<Pozisyon>();
        if(gameObject.CompareTag("Player")){
                deadPanel.SetActive(false);
            }
           
    }

    private GameObject GetGameObject()
    {
        return gameObject;
    }

    public void Checker(GameObject gameObject)
    {
        if(health<=0){
            switch(gameObject.tag){
                case "Player":
                kill=0;
                deadPanel.SetActive(true);
                StopCoroutine("Spawn");
                StartCoroutine("Spawn");
                
                break;
            case "Enemy":
            
            kill+=1;
            gameObject.SetActive(false);
            poz.Pozis();
             health = 100;
            gameObject.SetActive(true);
            
            break;
            }
           
        }
    }

    IEnumerator Spawn(){
        kill=0;
        yield return new WaitForSeconds(3);
        deadPanel.SetActive(false);
        health=100;
        
    }
     

}
