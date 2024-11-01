using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Vector2 movement;

    List<GameObject> bombs;

    private Rigidbody2D rb;
    private Animator animator;

    private const string horizontal = "HORIZONTAL";
    private const string vertical = "VERTICAL";
    public Vector2 playerDirection = new Vector2(0, 0);

    public GameObject bombPrefab;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.Set(InputManager.Movement.x, InputManager.Movement.y);
        movement.Normalize();
        Debug.Log(Input.GetKey(KeyCode.LeftShift));
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = movement * moveSpeed * 1.5f;

        } else
        {
            rb.velocity = movement * moveSpeed;

        }
        if (Input.GetMouseButtonDown(2))
        {
            GameObject bomb = Instantiate(bombPrefab, transform.position, transform.rotation);
            
            Destroy(bomb, 1.30f);
        }

        animator.SetFloat(horizontal, movement.x);
        animator.SetFloat(vertical, movement.y);
        
        if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        {
            playerDirection = Vector2.right * Mathf.Sign(movement.x);

        } else
        {
            playerDirection = Vector2.up * Mathf.Sign(movement.y);

        }




    }
}
