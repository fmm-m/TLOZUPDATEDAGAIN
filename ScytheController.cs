using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheController : MonoBehaviour
{
    public GameObject player;
    private float angle = 0;
    public float damping = 1;
    private bool animating = false;
    private float animatingAngle = 0;
    public Vector2 playerDir;
    

    // Start is called before the first frame update
    void Start()
    {
        
        this.transform.Rotate(0, 0, -65);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(InputManager.Fight);
        if (Input.GetMouseButtonDown(0) == true && !animating)
        {
            angle = 0;
            animating = true;
            transform.rotation = new Quaternion(0, 0, 0, 0);
            Debug.Log("Hello Toby, I think the button was clicked :)");

            

        }
        this.transform.position = player.transform.position;

        if (animating)
        {
            Vector3 rotatedPoint = Quaternion.AngleAxis(angle + player.transform.rotation.z, Vector3.forward / 3) * Vector3.left;
            


            var lookAtPos = Quaternion.LookRotation(player.transform.position);
            

            this.transform.position += rotatedPoint;
            // this.transform.LookAt(player.transform);
            this.transform.Rotate(0, 0, 3);
            angle += 3;

            if (angle >= 400)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
                animating = false;
            }
            
        }


        
        

    }
}
