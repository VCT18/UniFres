using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 3f;
    private void OnEnable()
    {
        Invoke(nameof(ReturnToPool), lifetime);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }

    void Update()
    {
        transform.Translate(Vector3.up*speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) return; 
        ReturnToPool();
    }
    void ReturnToPool()
    {
        ObjectPool.Instance.ReturnObject(gameObject);
    }
}
