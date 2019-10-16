using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Player previousHitter;
    private int hits;
    private GameObject flame;
    private bool inFlames = false;
    public float speed;
    public Vector3 initialImpulse = new Vector3(10, 0, 0);
    public Player hitter { get; private set; }
    public GameObject Flame;
    public int defaultPoints = -2;
    public int points;

    // Start is called before the first frame update
    void Start()
    {
        points = defaultPoints;
        speed = 10; //setting the speed
        Vector2 randomValues = UnityEngine.Random.insideUnitCircle; //generetes random X Y
        while (randomValues.y < 0.3)
        {
            Debug.Log("rolled " + randomValues.y + " for ball's new z - rerolling");
            randomValues = UnityEngine.Random.insideUnitCircle; //prevent the ball from moving too vertical and not towards the players
        }
        Vector3 startVel = new Vector3(randomValues.x, 0, randomValues.y); //creates a vector3 from the random values (x<-x, y<-0, z<-y)
        GetComponent<Rigidbody>().AddForce(startVel.normalized * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collider)
    {
        PlayerBorder playerBorder = collider.gameObject.GetComponent<PlayerBorder>();
        Paddle paddle = collider.gameObject.GetComponent<Paddle>();

        if (paddle)
        {
            hits++; // increment hits counter if hits a paddle
            previousHitter = paddle.player != hitter ? hitter : previousHitter; // keep track of the previous hitter (comes handy in case of own goal)
            hitter = paddle.player;
        }
        else if (playerBorder)
        {
            hits = 0; // reset if hits a wall
            hitter = playerBorder.player && hitter && playerBorder.player.playerName != hitter.playerName ? hitter : previousHitter; // in case of own goal the previous hitter should get the points

            RepositionStart();

            if (inFlames)
            {
                ExtinguishFlame();
            }
        }
    }

    public void RepositionStart()
    {
        transform.position = new Vector3(0f, 1f, 0f); //move the ball to the middle
        GetComponent<Rigidbody>().velocity = Vector3.zero; //stopping the ball
        speed = 10; //resetting the requested speed to normal
        Vector2 randomValues = UnityEngine.Random.insideUnitCircle; //generetes random X Y
        while (randomValues.y < 0.3)
        {
            Debug.Log("rolled " + randomValues.y + " for ball's new z - rerolling");
            randomValues = UnityEngine.Random.insideUnitCircle; //prevent the ball from moving too vertical and not towards the players
        }
        Vector3 startVel = new Vector3(randomValues.x, 0, randomValues.y); //creates a vector3 from the random values (x<-x, y<-0, z<-y)
        GetComponent<Rigidbody>().AddForce(startVel.normalized * speed, ForceMode.Impulse);
    }

    public void SetInFlames()
    {
        if (!inFlames)
        {
            Vector3 postition = transform.position + new Vector3(0f, 1.5f, 0f);
            flame = Instantiate(Flame, transform.position, Quaternion.Euler(-90f, 0f, 0f), gameObject.transform);
            inFlames = true;
        }
    }

    void ExtinguishFlame()
    {
        Debug.Log("ExtinguishFlame");
        Destroy(flame);
        inFlames = false;
        points = defaultPoints;
    }
}
