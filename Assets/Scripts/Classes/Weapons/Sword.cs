using UnityEngine;

public class Sword : Weapon
{
    public float distanceFromCharacter = 1.5f;
    private SpriteRenderer spriteRenderer;

    public float pushForce = 5f;

    void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //La espada necesita hacer override para agregar un desplazamiento hacia adelante constamente para darle el efecto que quería darle.
    protected override void rotate()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePosition - transform.parent.position).normalized;
        transform.position = transform.parent.position + direction * distanceFromCharacter;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        if (angle > 90 || angle < -90)
        {
            spriteRenderer.flipY = true;
        }
        else
        {
            spriteRenderer.flipY = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Rigidbody2D enemyRigidbody = other.GetComponent<Rigidbody2D>();
            if (enemyRigidbody != null)
            {
                Vector2 pushDirection = (other.transform.position - transform.position).normalized;
                enemyRigidbody.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
            }
        }
    }
}
