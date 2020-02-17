using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public float moveSpeed = -5;
    public int score = 0;
    public Text scoreText;

    private Rigidbody2D myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.name == "Player")
        {
            Respawn();
            score = score - 1;
            scoreText.text = score.ToString();
            if (score < 0)
            {
                scoreText.text = "GAME OVER :( !!!!!!";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);
        if (transform.position.x < -10)
        {
            Respawn();
            score = score + 1;
            scoreText.text = score.ToString();
        }
    }

    void Respawn()
    {
        transform.position = new Vector2(10.0f, -1);
        transform.localScale += new Vector3(0, Random.Range(-0.1f, 0.1f), 0);
        moveSpeed = Random.Range(-8.0f, -3.0f);
    }

}
















