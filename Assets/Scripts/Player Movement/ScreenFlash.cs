using UnityEngine;

public class ScreenFlash : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private int activate = Animator.StringToHash("Activate");

    public void FlashScreen() => animator.SetTrigger(activate);
}
