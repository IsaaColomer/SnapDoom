using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletCode : MonoBehaviour
{
    private Rigidbody rb;
    public GunsVariables gunsVariables;
    private Vector3 direction;
    [SerializeField] private GameObject gameObjectToDelete;
    private BeatCode beatCode;
    private float offBeatVel;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        beatCode = FindObjectOfType<BeatCode>();
        Launch();
        offBeatVel = gunsVariables.bulletVelocity / gunsVariables.offBeatVelocity;
    }
    public void SetDirection(Vector3 _direction)
    {
        direction = _direction;
    }
    private void Launch()
    {
        rb.velocity = direction.normalized * gunsVariables.bulletVelocity;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<BasicEnemyMovement>().GetHitAndGetHitOrDie();
            Destroy(gameObjectToDelete);
        }
    }
    private void Update()
    {
        if(beatCode.isOnBeat)
        {
            rb.velocity = direction.normalized * gunsVariables.bulletVelocity;
            //rb.AddForce(direction.normalized * gunsVariables.bulletVelocity, ForceMode.Acceleration);
        }
        else
        {
            rb.velocity = direction.normalized * offBeatVel;
        }
    }
    public void SetGameObjectId(GameObject go)
    {
        gameObjectToDelete = go;
    }
}
