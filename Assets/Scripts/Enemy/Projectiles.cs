using UnityEngine;

public class Projectiles : MonoBehaviour
{
    private Vector2 direction;
    private Rigidbody2D rb;
    [SerializeField]private int damage = 10;
    [SerializeField] float speed;

    public Vector2 Direction{
        get { return direction; }
        set { direction = value; }
    }

    // private Transform 
    
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        if(direction != null){
            float rotationValue = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotationValue - 180);
            rb.AddForce(direction * speed, ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("player")){
            other.GetComponent<IDamageable>()?.Hurt(damage);
        }
    }

    void OnBecameInvisible(){
        Destroy(gameObject);
    }
}
