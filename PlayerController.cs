using UnityEngine;
using UnityEngine.InputSystem; // thêm dòng này

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Đọc phím bấm theo cách mới
        Vector2 input = Vector2.zero;

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            input.x = -1f;
        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            input.x = 1f;

        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            input.y = -1f;
        else if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            input.y = 1f;

        Vector3 direction = new Vector3(input.x, input.y, 0f);
        transform.Translate(direction * speed * Time.deltaTime);

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Shoot();
        }
    }
    void Shoot()
    {
        GameObject bullet = ObjectPool.Instance.GetObject();
        bullet.transform.position = transform.position;
        bullet.SetActive(true);
    }
}