using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private float damage;

    [SerializeField]
    private float torque;

    [SerializeField]
    private Rigidbody rigidbody;

    [SerializeField]
    private float dieTime;

    [SerializeField]
    private Transform arrowsTrash;

    private string enemyTag;

    private bool didHit;

    public void Start()
    {
        arrowsTrash = GameObject.Find("ArrowsTrash").transform;
    }

    public void Fly(Vector3 force)
    {
        rigidbody.isKinematic = false;
        rigidbody.AddForce(force, ForceMode.Impulse);
        rigidbody.AddTorque(transform.right * torque);
        transform.SetParent(null);
    }

    private void Die()
    {
        new WaitForSeconds(dieTime);
        Destroy(gameObject);
    }

    public void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.collider.transform.tag);

        if (collision.transform.CompareTag("Player"))
        {
            return;
        }

        if (didHit) return;
        didHit = true;

        if (collision.transform.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<EnemyController>().Die();
        }

        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.isKinematic = true;
        transform.SetParent(arrowsTrash);
        Die();
    }

    private bool CheckCollision()
    {
        return true;
    }
}
