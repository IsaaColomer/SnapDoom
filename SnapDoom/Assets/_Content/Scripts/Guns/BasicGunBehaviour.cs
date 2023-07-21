using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class BasicGunBehaviour : MonoBehaviour
{
    public GunsVariables gunsVariables;

    [HideInInspector]
    public List<GameObject> enemiesInLevel;

    public Transform gunFiringPoint;
    private Transform player;
    private int i = 0;
    private void Start()
    {
        enemiesInLevel = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }
    public void Shoot()
    {
        // we get all the visible enemies and shoot a bullet to them
        foreach (GameObject item in enemiesInLevel)
        {
            RaycastHit hit;
            if(Physics.Raycast(gunFiringPoint.position, item.transform.position - player.transform.position, out hit, Mathf.Infinity))
            {
                if(hit.transform.gameObject.CompareTag("Enemy"))
                {
                    GameObject b = Instantiate(gunsVariables.bulletPrefab, gunFiringPoint.position, Quaternion.identity);
                    b.GetComponent<BasicBulletCode>().SetDirection(item.transform.position - player.transform.position);
                    b.GetComponent<BasicBulletCode>().SetGameObjectId(b);
                }                
            }
        }
    }
    public void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
}
