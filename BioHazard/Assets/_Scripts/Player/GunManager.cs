using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public List<GameObject> guns;
    public GameObject currentGun;
    int gunEquiped =1;

    // Start is called before the first frame update
    void Start()
    {
        guns[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        int tempGunID = gunEquiped;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            guns[gunEquiped].SetActive(false);
            gunEquiped = 0;
            guns[gunEquiped].SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            guns[gunEquiped].SetActive(false);
            gunEquiped = 1;
            guns[gunEquiped].SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            guns[gunEquiped].SetActive(false);
            gunEquiped = 2;
            guns[gunEquiped].SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            guns[gunEquiped].SetActive(false);
            gunEquiped = 3;
            guns[gunEquiped].SetActive(true);
        }

    }

    
}
