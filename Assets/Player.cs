using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{



    [SerializeField] protected int Level;
    [SerializeField] protected float Speed = 100;
    [SerializeField] protected States CurrentState = States.IDLE;
    [SerializeField] protected bool isPlayer = false;
    protected Rigidbody2D rd;
   

    public enum States
    {
        IDLE,
        MOVING,
        ATACK
    }





    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        if (isPlayer)
        {
            Move();
        }
      
    }


    


    

    public int GetLevel()
    {
        return Level;
    }

    public void SetLevel(int NewLevel) => Level = NewLevel;



    public void LevelUp()
    {
        Level++;
    }


    public void Move()
    {
        Vector2 velocity = new Vector2();
        

        if (Input.GetKey(KeyCode.A))
        {
            velocity.x = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            velocity.x = +1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            velocity.y = +1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            velocity.y = -1;
        }
        velocity.Normalize();

        if(velocity.magnitude != 0)
        {
            SetCurrentState(States.MOVING);
           
        }
        else
        {
            SetCurrentState(States.IDLE);
            
        }

        rd.velocity = velocity;

        rd.velocity = velocity * Speed * Time.deltaTime;

            }

    public void Atack()
    {
        
    }

    public void SetCurrentState(States states)
    {
        if(CurrentState!= states)
        {
            CurrentState = states;
            switch(CurrentState)
            {
                case States.IDLE:
                    rd.velocity = new Vector2();
                break;
                case States.MOVING:
                break;
                case States.ATACK: 
                break;
                default:
                break;
            }
        }
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        SetCurrentState(States.ATACK);
          
    }

   











































































    }