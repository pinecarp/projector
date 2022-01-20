using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject character;
    
    private void Update()
    {
        Vector3 characterPos = character.transform.position;
        transform.position = Vector3.Lerp(transform.position, new Vector3(characterPos.x, characterPos.y, 0), speed * Time.deltaTime);
    }
}
