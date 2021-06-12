using UnityEngine;

public class Controller : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed;
    private CharacterController controller;

    [Header("Zoom")]
    [SerializeField] Camera playerCamera;
    [SerializeField] float cameraDistanceMax = 90f;
    [SerializeField] float cameraDistanceMin = 30f;
    [SerializeField] float scrollSpeed = 4f;
    private float cameraDistance = 60f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        Zoom();
    }

    private void Move()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * moveSpeed);
    }

    private void Zoom()
    {
        cameraDistance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        cameraDistance = Mathf.Clamp(cameraDistance, cameraDistanceMin, cameraDistanceMax);

        playerCamera.fieldOfView = cameraDistance;
    }
}
