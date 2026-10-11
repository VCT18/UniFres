using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            //Debug.Log("Cham vao Enemy, Thua!");
            //gameObject.SetActive(false); 
            //GameManager.Instance.GameOver();
            GameEvents.Instance.TriggerGameOver();
        }
    }
}
