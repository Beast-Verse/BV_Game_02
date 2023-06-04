using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10;
    private bool canJump = false;
    public int forceConst = 10;
    private Rigidbody rb;


    public Vector3 boxSize;
    public float maxDistance;
    public LayerMask layerMask;


    public Vector2 turn;


    [SerializeField]
    public float _mouseSensitivity = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate(){
        if(canJump){
            canJump = false;
            rb.AddForce(transform.up*5, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        MonsterMovement();
        if (Input.GetKeyDown(KeyCode.Space) && GroundCheck())
        {
            rb.AddForce(transform.up*5, ForceMode.Impulse);
        }
    }

    void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position - transform.up*maxDistance, boxSize);
    }

    bool GroundCheck(){
        if(Physics.BoxCast(transform.position, boxSize, -transform.up, transform.rotation, maxDistance, layerMask)){
            return true;
        }
        else{
            return false;
        }
    }

    void MonsterMovement()
    {
        float xAxis = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float zAxis = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        turn.x = Input.GetAxis("Mouse X")*_mouseSensitivity;

        transform.Rotate(0, turn.x, 0);

        transform.Translate(xAxis,0,zAxis);
    }

    
}
