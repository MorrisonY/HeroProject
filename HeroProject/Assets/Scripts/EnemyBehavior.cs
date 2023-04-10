using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	
	public float mSpeed = 20f;
		
	// Use this for initialization
	void Start () {
		NewDirection();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += (mSpeed * Time.smoothDeltaTime) * transform.up;
		GlobalBehavior globalBehavior = GameObject.Find ("GameManager").GetComponent<GlobalBehavior>();
		
		GlobalBehavior.WorldBoundStatus status =
			globalBehavior.ObjectCollideWorldBound(GetComponent<Renderer>().bounds);
			
		if (status != GlobalBehavior.WorldBoundStatus.Inside) {
			Debug.Log("collided position: " + this.transform.position);
			NewDirection();
		}	
	}

    public int health = 1;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Egg"))
        {
            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            // Do something when enemy collides with player
        }
    }


	// New direction will be something completely random!
	private void NewDirection() {
		Vector2 v = Random.insideUnitCircle;
		transform.up = new Vector3(v.x, v.y, 0.0f);
	}
}


