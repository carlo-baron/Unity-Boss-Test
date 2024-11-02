using UnityEngine;

public class Projectiles : MonoBehaviour
{
    private Vector2 direction;
    private Rigidbody2D rb;
    [SerializeField]private int damage = 10;
    [SerializeField] float speed;
    bool isRicocheted = false;

    public Vector2 Direction{
        get { return direction; }
        set { direction = value; }
    }

    private Transform launcher;
    public Transform Launcher{
        get { return launcher; }
        set { launcher = value; }
    }
    
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
        if(!isRicocheted){
            if(other.CompareTag("player")){
                other.GetComponent<IDamageable>()?.Hurt(damage);
                Destroy(gameObject);
            }
        }else{
            if(other.tag != "player" && other.tag != gameObject.tag){
                other.GetComponent<IDamageable>()?.Hurt(damage);
                Destroy(gameObject);
            }
        }

    }

    void Update(){
        if(launcher == null) Destroy(gameObject);
    }

    internal void Ricochet(){
        Vector3 newDir = (launcher.position - transform.position).normalized;
        direction = newDir;
        isRicocheted = true;

        float rotationValue = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationValue - 180);

        rb.linearVelocity = Vector2.zero;

        rb.AddForce(direction * speed, ForceMode2D.Impulse);
        print("Ricocheted");
    }
    void OnBecameInvisible(){
        Destroy(gameObject);
    }
}
