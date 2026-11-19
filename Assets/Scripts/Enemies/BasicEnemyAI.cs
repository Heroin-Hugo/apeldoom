using UnityEngine;
using UnityEngine.AI;

public class BasicEnemyAI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform player;
    [SerializeField] private NavMeshAgent agent;

    [Header("Stats")]
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private LayerMask playerAttackLayer;
    [SerializeField] private float sightRange;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackDamage;
    [SerializeField] private Animator animator;
    [Space]
    public float swingToAttackDelay;

    [SerializeField] private bool inSightRange;
    [SerializeField] private bool inAttackRange;

    [SerializeField] private bool attackingPlayer;

    private Vector3 playerLookPos;

    private int walking = Animator.StringToHash("Walking");
    private int windup = Animator.StringToHash("Windup");
    private int attack = Animator.StringToHash("Attack");

    private void Update()
    {

        CheckPlayerPosition();
        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        playerLookPos = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(playerLookPos);
    }

    private void CheckPlayerPosition()
    {
        inSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        inAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

        if (inSightRange && !inAttackRange) Idle();
        if (inSightRange && !inAttackRange && !attackingPlayer) ChasePlayer();
        if (inSightRange && inAttackRange && !attackingPlayer) Attack();

    }

    private void Idle()
    {
        agent.SetDestination(transform.position);
        animator.SetBool("Walking", false);
    }
    private void ChasePlayer()
    {
        animator.SetBool("Walking", true);
        agent.SetDestination(player.position);
    }

    private void Attack()
    {
        animator.SetBool(walking, false);
        animator.SetTrigger(windup);
        attackingPlayer = true;

        agent.SetDestination(transform.position);
        Invoke(nameof(Swing), swingToAttackDelay);

    }

    private void Swing()
    {
        animator.SetTrigger(attack);
        RaycastHit playerHit;
        if (Physics.Raycast(transform.position, transform.forward, out playerHit, attackRange + 2, playerAttackLayer))
        {
            Debug.Log(playerHit.transform.name);
            var player = playerHit.transform.GetComponent<PlayerHealth>();
            if (player != null) player.TakeDamage(attackDamage);
        }

        Invoke(nameof(ResetAttack), 0.75f);
    }

    private void ResetAttack() => attackingPlayer = false;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
