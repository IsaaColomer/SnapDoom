using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BasicEnemyMovement : MonoBehaviour
{
    public EnemiesVariables enemiesVariables;
    private Animator anim;
    private Transform player;
    private NavMeshAgent agent;
    public string hitAnimationName;
    private float lifes;
    private BasicGunBehaviour guns;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        agent.velocity = new Vector3(0.15f, 0.15f, 0.15f);
        lifes = enemiesVariables.spiderLifes;
        guns = FindObjectOfType<BasicGunBehaviour>();
        LookAtPlayer();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateDistanceToPlayer();
        LookAtPlayer();
    }
    public void CalculateDistanceToPlayer()
    {
        float d = Vector3.Distance(transform.position, player.position);
        anim.SetFloat("_DistanceToPlayer", d);
        if(d < 25f)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            agent.SetDestination(transform.position);
        }
    }
    private void LookAtPlayer()
    {
        transform.LookAt(player);
    }

    public void GetHitAndGetHitOrDie()
    {
        if(lifes == 1)
        {
            OnlyGetHit();
            RemoveKilledEnemyFromList();
            Destroy(this.gameObject);
        }
        else
        {
            OnlyGetHit();
        }
        
    }
    
    public void RemoveKilledEnemyFromList()
    {
        guns.enemiesInLevel.Remove(this.gameObject);
    }
    private void OnlyGetHit()
    {

        anim.Play(hitAnimationName);
        lifes--;
        Debug.Log(lifes);
    }
}
