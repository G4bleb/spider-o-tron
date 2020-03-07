using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpider : MonoBehaviour
{
    public float speed = 1f, radius = 1f;
    [Tooltip("Probability percentage of direction change every AI tick")]
    public float directionChangeProba = 50f;
    
    [SerializeField] private float AITickRate = .3f;

    private Vector3 objective;
    private Animation walkingAnim;
    private Rigidbody rb;

    void Start()
    {
        walkingAnim = GetComponent<Animation>();
        rb = GetComponent<Rigidbody>();
        objective = transform.position;
        StartCoroutine(DecideAndMove());
    }

    void FixedUpdate()
    {
        if (objective.x - transform.position.x < 0.01 & objective.z - transform.position.z < 0.01)
        {
            rb.velocity = Vector3.zero;
            walkingAnim.Stop();
        }
    }

    private Vector3 FindObjective(){
        Vector2 objXZ = Random.insideUnitCircle * radius;
        objective = new Vector3(objXZ.x, transform.position.y, objXZ.y);
        return objective;
    }

    private void MoveToObjective(){
        Vector3 direction = objective - transform.position;
        direction.Normalize();
        direction.y = 0;
        rb.velocity = direction * speed;
        walkingAnim.Play();
    }

    IEnumerator DecideAndMove(){
        while(true){
            if(Random.value * 100 >= directionChangeProba){ //50% chance
                rb.velocity = Vector3.zero;
                FindObjective();
                transform.LookAt(objective);
                MoveToObjective();
            }
            yield return new WaitForSeconds(.3f);
        }
    }
}
