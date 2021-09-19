using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Speeds")]
    [SerializeField] private float horizontalSpeed = 0.03f;
    [SerializeField] private float verticalSpeed = 0.01f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position	 += Vector3.left * horizontalSpeed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position	 += Vector3.right * horizontalSpeed;
        }

        this.transform.position += Vector3.forward * verticalSpeed;
    }
}
