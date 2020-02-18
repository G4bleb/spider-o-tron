using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpider : MonoBehaviour
{
    Vector3 direction = Vector3.zero;
    // Start is called before the first frame update
    public float speed, AreaXmin, AreaXmax, AreaZmin, AreaZmax;
    public int directionChangesProba; //if its high, it will change less direction

    private float reachX, reachZ;
    private Animation walking;
    void Start()
    {
        walking = GetComponent<Animation>();
    }

    void FixedUpdate()
    {
        TryDestinationUpdtate();

        if (reachX - this.transform.position.x < 0.1 & reachZ - this.transform.position.z < 0.1)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            walking.Stop();
        }
    }

    public void DrawingSetup()
    {
        Vector3 dir = GetComponent<Rigidbody>().velocity;
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, angle);
    }
    public void TryDestinationUpdtate()
    {
        int random = Random.Range(0, directionChangesProba);
        if (random == 1) //change destination
        {
            do
            {
                reachZ = Random.Range(AreaZmin,AreaZmax);
                reachX = Random.Range(AreaXmin, AreaXmax);
            } while (reachX - this.transform.position.x < 1 & reachZ - this.transform.position.z < 1);

            direction.x = reachX - this.transform.position.x;
            direction.z = reachZ - this.transform.position.z;
            direction.Normalize();
            GetComponent<Rigidbody>().velocity = direction * speed;
            walking.Play();
            DrawingSetup();
        }
    }
}
