using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptSpider : MonoBehaviour
{
    public int EnemyHealth = 15;
    public GameObject TheSpider; 

    void DeductPoints(int DamageAmount)
    {
        EnemyHealth -= DamageAmount;
    }

    void Update()
    {
        if (EnemyHealth <= 0)
        {
            this.GetComponent<SpiderFollow>().enabled = false;
            TheSpider.GetComponent<Animation>().Play("die");
            EnemyHealth = 1;
        }
    }

    IEnumerator EndZombie()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
