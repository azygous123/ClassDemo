using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Rigidbody2D rb;

    Animator animator; // trigger animation transitions etc.

    GameObject player; // track the main player 
   // Transform 


    bool isPlayerDetected = false; // not detected yet
    bool isAttacking = false;

    float detectionRange = 1.2f; 



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Character"); //make sure this is set in Unity
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        DetectPlayer();
    }
    void Attack()
    {
        if (!isAttacking)
        { 
            isAttacking = true;
            animator.SetTrigger("Attack");
        }
    }

    void DetectPlayer()
    {
        float distace = Vector2.Distance(transform.position, player.transform.position);
        if(!isPlayerDetected)
        {
            if (distace <= detectionRange)
            {
                //player detected
                isPlayerDetected = true;
                Attack(); // start attacking

            }
            else 
            {
                isPlayerDetected = false;
            }
        }
    }

}
