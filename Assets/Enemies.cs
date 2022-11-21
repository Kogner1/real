using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemies : Player
{
    private GameObject target;
    [SerializeField] 
    public string LevelName;
    [SerializeField] 
    public int LevelIndex;


    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        FSM(); 
    }

    private void FixedUpdate()
    {
        MovementBehaviour();
    }

    public void FSM()
    {
        switch (CurrentState)
        {
            case States.IDLE:
                MovementBehaviour();
                break;
            case States.MOVING:
                MovementBehaviour();
                break;
            case States.ATACK:
                break;
            default:
                break;
        }
    }
    public void MovementBehaviour ()
    {
        if (target != null) // para que solo persigan al jugador seria asi ? : if(target !=null and (Other.CompareTag("Player")){ }
        {
            Vector2 vec = target.transform.position - transform.position;
            vec.Normalize();
            rd.velocity = vec * Speed * Time.deltaTime;
        }
        else
        {
            SetCurrentState(States.IDLE);
        }

    }






    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("entro");
            target = collision.gameObject;
        SetCurrentState(States.MOVING);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       // Debug.Log("salio");
        target = null;
        SetCurrentState(States.IDLE);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        
        {
            SceneManager.LoadScene(LevelName);
        }
        
    }
}
