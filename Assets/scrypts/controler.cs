using Unity.Mathematics;
using UnityEngine;

public class controler : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpforce;
    private Rigidbody rb;
    [SerializeField]
    private Transform ca;
    private Vector3 turn;
    [SerializeField]
    private float horisental_sensitive;
    [SerializeField]
    private float vertical_sensitive;
    void playerotate()
    {
        float vertical=Input.GetAxis("Mouse Y")*vertical_sensitive;
        float horisental = Input.GetAxis("Mouse X") * vertical_sensitive;
        turn.x-=vertical;
        turn.x = Mathf.Clamp(turn.x, -90, 90);
        turn.y += horisental;
        transform.rotation=Quaternion.Euler(transform.rotation.x, turn.y, 0);
        ca.transform.rotation=Quaternion.Euler (turn.x,turn.y, 0);
    }
    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * speed);

        }
     
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * speed);


        }

        if (Input.GetKey(KeyCode.D))
        { 
            rb.AddForce(transform.right * speed);
        
        
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-transform.right * speed);


        }

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.up *  speed);


        }
    }   

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        playerotate();
    }
}
