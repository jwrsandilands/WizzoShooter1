using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public float moveSpeed = 0.0f;
    public float delay = 0f;
    public int damage = 1;
    

    private void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * moveSpeed);
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
    }

    private void OnBecameInvisible()
    {
        Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
