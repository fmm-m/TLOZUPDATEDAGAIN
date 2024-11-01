using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombScript : MonoBehaviour
{
    Vector3 velocity;
    public float speed = 0.0005f;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 distances = Input.mousePosition - this.transform.position;
        float angleToMouse = Mathf.Atan2(distances.y, distances.x);
        velocity = new Vector3(Mathf.Cos(angleToMouse) * speed, Mathf.Sin(angleToMouse) * speed, 0);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity;
        velocity *= 0.05f;
        if (velocity.magnitude <= 0.5) {
            velocity = new Vector3(0, 0, 0);
        }
    }
}
