using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float maxHealth;
    [SerializeField] float difficultyMod = 3; //average 
    [SerializeField] int healthRechargeRate;
    [SerializeField] int healthRechargeTime;
    [SerializeField] Scrollbar healthBar;
    [SerializeField] Text healthTxt;
    [SerializeField] bool alive = true;
    [SerializeField] Image deadFadeEffect;
    float fade =0;
    float deathAngle = 0f;
    private void Update()
    {
        if (!alive)
        {
            fade += 0.0052f;
            Color fadeColor = new Color(deadFadeEffect.color.r, deadFadeEffect.color.g, deadFadeEffect.color.b, Mathf.Lerp(0,.7f,fade));
            deadFadeEffect.color = fadeColor;
            deathAngle = 0.02f;
            if (this.gameObject.transform.rotation.eulerAngles.z < 90)
            {
                this.gameObject.transform.Rotate(new Vector3(0, 0, 1), Mathf.Lerp(0, 90, deathAngle));
            }
            
        }
    }

    public float Health
    {
        get { return health; }
        set { 
            health = value;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        healthBar.size = (health/100);
        if (health <= 0)
        {
            health = 0;
            alive = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy Bullet")
        {
            
            Health -= 1f * difficultyMod;
            healthTxt.text = Mathf.RoundToInt(health).ToString();

            
        }
    }
}
