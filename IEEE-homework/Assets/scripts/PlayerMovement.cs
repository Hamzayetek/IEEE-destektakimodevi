using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject joystick1;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private VariableJoystick joystick;
    [SerializeField] private Transform playertransform;
    public float playerSpeed ;
    private float _horizontal;
    private float _vertical;
    [SerializeField] private float a;


    void Update()
    {
        getmovementýnput();
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical) * playerSpeed * Time.deltaTime;

        transform.Translate(movement);

        Vector3 movement1 = transform.forward*_vertical*playerSpeed* Time.deltaTime;
        rb.MovePosition(rb.position + movement1);


        float turnamount = _horizontal*playerSpeed* Time.deltaTime;
        Quaternion turnrotation = Quaternion.Euler(0,turnamount * a,0);
        rb.MoveRotation(rb.rotation * turnrotation);

    }

    public void hareketidurdur()
    {
        playerSpeed = 0f;
    }

    public void joystickkapa()
    {
        joystick1.SetActive(false);
    }

    //private void FixedUpdate()
    //{
    //    setmovement();
    //    setrotation();
    //}

    private void setmovement()
    {
        rb.velocity = getnewvelocity();
    }

    private Vector3 getnewvelocity ()
    {
        return new Vector3(_horizontal, rb.velocity.y, _vertical) * playerSpeed * Time.fixedDeltaTime;
    }

    private void getmovementýnput()
    {
        _horizontal = joystick.Horizontal;
        _vertical = joystick.Vertical;
    }

    private void setrotation()
    {
        if(_horizontal != 0 || _vertical != 0)
        {
            playertransform.rotation = Quaternion.LookRotation(getnewvelocity());
        }
    }
}
