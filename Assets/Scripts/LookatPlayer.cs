using UnityEngine;

public class LookatPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void Update() => transform.LookAt(player.position);

}
