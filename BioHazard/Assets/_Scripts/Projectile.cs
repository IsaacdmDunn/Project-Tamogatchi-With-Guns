using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float bulletLifeTime;

    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletLifeTime -= Time.deltaTime;
        if (bulletLifeTime < 0)
        {
            Destroy(this.gameObject);
        }
        GetComponent<Rigidbody>().velocity = transform.forward * 25;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
        
    }

  


}
