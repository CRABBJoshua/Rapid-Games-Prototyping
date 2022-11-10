using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public Transform PlayerHeight;

    public bool isGrounded;
    Rigidbody rb;

    // player id (set to 0 for single player, or increments for local multiplayer)
    public int id;

    public bool isInitialised;

    // movement
    public float maxSpeed, acceleration;
    private float maxSpeedSqr;
    private bool canMove;

    // scoring
    private int score;
    public int Score { get { return score; } set { score = value; } }

    Vector3 posSinceLastScore;
    Vector3 upAxis;

    public Camera camera;

    public bool CanMove
    {
        get { return canMove; }
        set
        {
            canMove = value;

            if (canMove == true) RB.constraints = RigidbodyConstraints.None;
            else RB.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    float horizInput, vertInput;    

    Vector3 restartPoint;
    public Vector3 RestartPoint { get { return restartPoint; } }

    
    public Rigidbody RB { get { return rb; } }

    public bool IsOnZAxis = false;
    public bool IsOnYAxis = false;
    public bool IsOnXAxis = false;

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 20.0f, 0.0f);

        CanMove = false;
    }

    public void init()
    {
        // do not allow duplicate players
        if (GameManager.Instance.registerNewPlayer(id, this) == false)
        {
            Destroy(gameObject);
        }
        else
        {
            restartPoint = transform.position;
            maxSpeedSqr = maxSpeed * maxSpeed;

            isInitialised = true;

            DontDestroyOnLoad(gameObject);
        }
    }

    protected float getPlanarVelocitySqr()
    {
        return (rb.velocity.x * rb.velocity.x) + (rb.velocity.z * rb.velocity.z);
    }

    protected Vector3 getPlanarVelocityDirection()
    {
        return new Vector3(rb.velocity.x, 0, rb.velocity.z);
    }

    public void addScore(int scoreToAdd)
    {
        Score += scoreToAdd;

        UIManager.Instance.updateScore(id, Score);
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove == true)
        {
            horizInput = Input.GetAxis("Horizontal");
            vertInput = Input.GetAxis("Vertical");
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        if (CanMove == true && (horizInput != 0 || vertInput != 0))
        {
            Vector3 direction = new Vector3(horizInput, 0, vertInput);
            direction = Quaternion.Euler(0, -135, 0) * direction;

            //var worldSpaceCameraRelativeDir = camera.transform.TransformDirection(direction);

            //var projectedVec = Vector3.ProjectOnPlane(worldSpaceCameraRelativeDir, Vector3.up);
            //projectedVec.y = 0;

            //if (IsOnZAxis)
            //{
            //    //if (PlayerHeight.position.y > 25)
            //    //{
            //    //    direction = new Vector3(horizInput, vertInput, 0);
            //    //    direction = Quaternion.Euler(0, -135, 0) * direction;
            //    //    Debug.Log("Changed to Other Z");
            //    //}
            //    else
            //    {
            //        direction = new Vector3(horizInput, vertInput, 0);
            //        direction = Quaternion.Euler(0, -135, 0) * direction;
            //        Debug.Log("Changed to Z");
            //    }
            //}

            if (IsOnZAxis)
            {
                direction = new Vector3(horizInput, vertInput, 0);
                direction = Quaternion.Euler(0, -135, 0) * direction;
                Debug.Log("Changed to Z");
            }

            if (IsOnYAxis)
            {
                direction = new Vector3(horizInput, 0, vertInput);
                direction = Quaternion.Euler(0, -135, 0) * direction;
                Debug.Log("Changed to Y");
            }

            if (IsOnXAxis)
            {
                direction = new Vector3(horizInput, vertInput--, 0); 
                direction = Quaternion.Euler(0, -135, 0) * direction;
                Debug.Log("Changed to X");
            }

            

                if (getPlanarVelocitySqr() < maxSpeedSqr)
            {
                rb.AddForce(direction * acceleration, ForceMode.Force);
            }

            if (getPlanarVelocitySqr() > maxSpeedSqr)
            {
                Vector3 planarDir = getPlanarVelocityDirection().normalized;
                rb.velocity = new Vector3(planarDir.x * maxSpeed, rb.velocity.y, planarDir.z * maxSpeed);
            }
        }
        else if(IsOnZAxis)
        {

        }
        upAxis = -Physics.gravity.normalized;
    }

    void LateUpdate()
    {
        if (CanMove == true && Vector3.Distance(transform.position, posSinceLastScore) > 3)
        {
            posSinceLastScore = transform.position;

            score += GameManager.Instance.pointsPerUnitTravelled;

            UIManager.Instance.updateScore(id, score);
        }
    }
}
