using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageDetection : MonoBehaviour
{
    public float health = 10;

    public Text damagetext;
    public Text deadText;

    private CapsuleCollider collider;

    private void Start()
    {
        damagetext.text = "Health: " + health;
        collider = GetComponent<CapsuleCollider>();
        deadText.text = " ";
    }

    private void OnTriggerEnter(Collider other)
    {
        collider.enabled = false;

        health -= 1;

        damagetext.text = "Health: " + health;

        StartCoroutine(ReactivateCollider());

        Die();
    }

    IEnumerator ReactivateCollider()
    {
        yield return new WaitForSecondsRealtime(1);

        collider.enabled = true;
    }

    public void Die()
    {
        if (health <= 0)
        {
            deadText.text = "You Died";

        }
    }
}
