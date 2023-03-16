using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float health = 100;
    [SerializeField] GameObject bloodEffectPrefab = null; 
    [SerializeField] GameObject deathEffectPrefab = null; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0)
        {
            GameObject deathEffectPrefab = Instantiate(bloodEffectPrefab, this.gameObject.transform.position, Quaternion.identity);
            deathEffectPrefab.name = "bloodEffect";
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullets")
        {
            health -= other.GetComponent<Projectile>().damage;
            if (bloodEffectPrefab != null)
            {
                GameObject bloodEffectOBJ = Instantiate(bloodEffectPrefab, other.gameObject.transform.position, Quaternion.identity);
                bloodEffectOBJ.name = "bloodEffect";
            }
            
            Destroy(other);
        }
    }
}
