using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [Header("Path scanners")]
    [SerializeField] PathScanner scannerUp;
    [SerializeField] PathScanner scannerDown;
    [SerializeField] PathScanner scannerLeft;
    [SerializeField] PathScanner scannerRight;
    Rigidbody2D rb;
    enum Rotation
    {
        Up,
        Down,
        Left,
        Right
    }
    Vector2 minBounds;
    Vector2 maxBounds;
    Animator myAnimator;
    Vector2 direction;
    float angle;
    Vector3 scale;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponentInChildren<Animator>();
    }
    void Start()
    {
        direction = Vector2.right;;
        angle = Mathf.Atan2(0, 1) * Mathf.Rad2Deg;
        scale = Vector3.one;
    }
    void Update()
    {
        ProcessInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        transform.localScale = scale;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        // Vector2 newDelta = direction * speed * Time.deltaTime;

        // Vector2 newPos = new Vector2();
        // newPos.x = transform.position.x + newDelta.x;
        // newPos.y = transform.position.y + newDelta.y;
        // transform.position = newPos;

        rb.velocity = direction * speed;
    }

    private void RotateAndSetDirection(Rotation rotation)
    {
        switch (rotation)
        {
            case Rotation.Up:
                if (!scannerUp.Blocked)
                {
                    scale.x = 1;
                    angle = Mathf.Atan2(1, 0) * Mathf.Rad2Deg;
                    direction = Vector2.up;
                }
                break;
            case Rotation.Down:
                if (!scannerDown.Blocked)
                {
                    scale.x = 1;
                    angle = Mathf.Atan2(-1, 0) * Mathf.Rad2Deg;
                    direction = Vector2.down;
                }
                break;
            case Rotation.Left:
                if (!scannerLeft.Blocked)
                {
                    scale.x = -1;
                    angle = Mathf.Atan2(0, 1) * Mathf.Rad2Deg;
                    direction = Vector2.left;
                }
                break;
            case Rotation.Right:
                if (!scannerRight.Blocked)
                {
                    scale.x = 1;
                    angle = Mathf.Atan2(0, 1) * Mathf.Rad2Deg;
                    direction = Vector2.right;
                }
                break;
            default:
                break;
        }
    }

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            RotateAndSetDirection(Rotation.Up);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            RotateAndSetDirection(Rotation.Down);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            RotateAndSetDirection(Rotation.Right);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            RotateAndSetDirection(Rotation.Left);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Portal") {
            Teleport(other.GetComponent<Portal>());
        }
    }

    void Teleport(Portal currPortal)
    {
        transform.position = currPortal.GetExitTransformFromOtherPortal().position;
    }
}
