using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveSpider : MonoBehaviour
{
    Vector3 direction = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    [SerializeField]
    private float speed, AreaXmin, AreaZmin, AreaXmax, AreaZmax;
    [SerializeField]
    private int directionChangesProba; //if its high, it will change less direction

    private float reachX, reachZ;
    private Animation walking;
    void Start()
    {
        walking = this.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        TryDestinationUpdtate();

        if (reachX - this.transform.position.x<0.1 && reachZ - this.transform.position.z<0.1)
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            walking.Stop();
        }
    }
    //drawing functions
    public void DrawingSetup()
    {
        var dir = this.gameObject.GetComponent<Rigidbody>().velocity;
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
            } while (reachX - this.transform.position.x < 3 && reachZ - this.transform.position.z < 3);

            direction.x = reachX - this.transform.position.x;
            direction.z = reachZ - this.transform.position.z;
            direction.Normalize();
            this.gameObject.GetComponent<Rigidbody>().velocity = direction * speed;
            walking.Play();
            DrawingSetup();
        }
    }
}
