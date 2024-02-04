using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHole : MonoBehaviour
{
    // Start is called before the first frame update
    public float DeleteTime;
    void Start()
    {
    Invoke("DeleteBulletHole",DeleteTime);
    }

    // Update is called once per frame
    void DeleteBulletHole()
    {
        Destroy(this.gameObject);
    }
}
