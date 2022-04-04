using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    bool isMoving;
    Rigidbody2D rb;
    CircleCollider2D circlecollider;
    public Vector2 direction;
    [SerializeField]
    float movementSpeed;
    public UnityAction onStopMove;
    public UnityAction onMove;
    public UnityAction onClicked;
    public bool clicked = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circlecollider = GetComponent<CircleCollider2D>();

    }


    // Update is called once per frame

    public void Move(float target)
    {

        Vector3 theScale = transform.localScale;

        direction = new Vector2(target, transform.position.y);

        if (target < transform.position.x)
        {
            theScale.x = -1;
        }
        else
        {
            theScale.x = 1;
        }
        transform.localScale = theScale;
        isMoving = true;
    }
    void FixedUpdate()
    {
        if (isMoving)
        {
            onMove?.Invoke();
            transform.position = Vector2.MoveTowards(transform.position, direction, Time.deltaTime * 3);
            
            if (direction.x == transform.position.x)
            {
                onStopMove?.Invoke();
                isMoving = false;
                if (clicked)
                {
                    onClicked?.Invoke();
                    clicked = false;
                }
                return;
               
            }

        }

    }

}
