using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pozisyon : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float Yy;
    private HealthSystem saglik;
   public float randX;
        public float randZ;
    private MeshRenderer mesh;
    void Start()
    {
        saglik=GetComponent<HealthSystem>();
       mesh=GetComponent<MeshRenderer>();
        Pozis();
    }
    
    public void Pozis()
    {
        float randX = Random.Range(-14f, 14f);
        float randZ = Random.Range(-14f, 14f);

        if (mesh != null)
        {
            transform.position = new Vector3(randX, Yy, randZ);
            mesh.enabled = true;
        }
    }
    

    // Update is called once per frame
   
}
