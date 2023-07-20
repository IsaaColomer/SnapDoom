using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletCode : MonoBehaviour
{
    private Rigidbody rb;
    public GunsVariables gunsVariables;
    private Vector3 direction;
    [SerializeField] private GameObject gameObjectToDelete;
    // Start is called before the first frame update
    void Start()
    {
        Launch();
    }
    public void SetDirection(Vector3 _direction)
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
        if(collision.transform.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<BasicEnemyMovement>().GetHitAndGetHitOrDie();
            Destroy(gameObjectToDelete);
        }
    }
    public void SetGameObjectId(GameObject go)
    {
        gameObjectToDelete = go;
    }
}
