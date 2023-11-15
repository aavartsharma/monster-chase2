using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tplayer : MonoBehaviour
{
    [SerializeField] private Transform postoshoot;
    [SerializeField] private GameObject partlie;
    [SerializeField] private Rigidbody2D playersr; 
    [SerializeField] private Animator playersanime;
    [SerializeField] private SpriteRenderer sprit;
    [SerializeField] private Joystick joystick;
    [SerializeField] private float Speed;
    [SerializeField] private float jumpspeed;
    [SerializeField] private float shootingForce;
    [SerializeField] private string moves;
    [SerializeField] private string twox;
    [SerializeField] private string heart;
    private Camera mainc;
    private float timesone;
    private bool tappingbutton = false;
    private bool isGround = true;
    private bool shouldbejumping = false;

    void Start()
    {
        mainc = Camera.main;//getting the main camera referce
    }

    void FixedUpdate()
    {
        float joystickMove = joystick.Horizontal;
        Vector2 pos = transform.position;
        if(joystickMove < 0) // moving to left
        {
            playersanime.SetInteger(moves,2);
            sprit.flipX = true;
            pos.x += -Speed * Time.deltaTime;
            transform.position = pos;
        }
        if(joystickMove > 0) // moving to right
        {
            playersanime.SetInteger(moves,2);
            sprit.flipX = false;
            pos.x += Speed * Time.deltaTime;
            transform.position = pos; 
        }
        if(isGround && shouldbejumping) // in jump state
        {
            jumper();
        }
        else
        {
            shouldbejumping = false;
        }
        
        if(joystickMove == 0f && isGround)
        {
            playersanime.SetInteger(moves,1);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            isGround = true;
        }
        if(collision.gameObject.CompareTag(twox))
        {
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag(heart))
        {
            Destroy(collision.gameObject);
            // health should be fulled
        }
    }

    void Update()
    {
        if(Input.touchCount > 0 )
        {
            if(Time.time <= timesone)
            {
                return;
            }
            timesone = Time.time + 1f;
            Vector3 inputPosition = Giveintputpos();
            if(tappingbutton == false)
            {
                shootparticle(inputPosition);
            }
        }      
    }
    Vector3 Giveintputpos() // function for getting dirition of the tapped places
    {
        Vector3 inputPosition = Vector3.zero;
        Touch t = Input.GetTouch(0);
        inputPosition = t.position;
        inputPosition.z = 10f;
        inputPosition = mainc.ScreenToWorldPoint(inputPosition);
        return inputPosition;
    }
    void shootparticle(Vector3 tragetpos)// spawer and shoot the bullet in the given position
    {
        GameObject partli = Instantiate(partlie,transform.position,Quaternion.identity);
        Rigidbody2D partlierb2d = partli.GetComponent<Rigidbody2D>();
        Vector3 dir = (tragetpos-transform.position).normalized;
        partlierb2d.AddForce(dir*shootingForce,ForceMode2D.Impulse);
    }
    void jumper() // to make player jump
    {
        playersr.AddForce(new Vector2(0f, jumpspeed), ForceMode2D.Impulse);
        playersanime.SetInteger(moves,3);
        isGround = false;
    }

    public void isbuttonpressed(bool pr)
    {
        tappingbutton = pr;
    }
    public void jumps(bool shouldjump)
    {
        shouldbejumping = shouldjump;
    }
}
