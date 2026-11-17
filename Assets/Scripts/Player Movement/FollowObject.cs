using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] private Transform objectToFollow;

    private void Update()
    {
        transform.position = objectToFollow.position;
    }
}
