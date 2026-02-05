using UnityEngine;

public class flagPole : MonoBehaviour
{
    private Vector2 pos;
    private float height;

    public GameObject flag;
    private float flagHeight;
    private float flagWidth;

    private bool dropFlag = false; 

    public Char_Anim player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        pos = transform.position;
        height = GetComponent<SpriteRenderer>().bounds.size.y;

        flagHeight = flag.GetComponent<SpriteRenderer>().bounds.size.y;
        flagWidth = flag.GetComponent<SpriteRenderer>().bounds.size.x;

        flag.transform.position = new Vector2(pos.x - flagWidth/2, pos.y + height * 7 / 16 - flagHeight / 2);
    
        }


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Character")
        {
            player.moveSpeed = 0f;
            player.jumpForce = 0f;
            dropFlag = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        if (dropFlag && flag.transform.position.y > pos.y - height / 2 + flagHeight / 2)
        {
            float dis = -2f * Time.deltaTime;
            flag.transform.Translate(new Vector2(0, dis));
        }
    }
}
