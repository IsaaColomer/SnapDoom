using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletCode : MonoBehaviour
{
    private Rigidbody rb;
    public GunsVariables gunsVariables;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        Launch();
    }
    public void GetDirection(Vector3 _direction)
    {
        direction = _direction;
    }
    private void Launch()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(direction.normalized * gunsVariables.bulletVelocity, ForceMode.Acceleration);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.gameObject.tag);
        if(collision.transform.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<BasicEnemyMovement>().GetHit();
            WaitToDestroy();
        }
    }
    private IEnumerator WaitToDestroy()
    {
        yield return new WaitForEndOfFrame();
        Destroy(this.gameObject);
    }
}
