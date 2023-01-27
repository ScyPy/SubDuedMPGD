using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public int Health;
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    [SerializeField] private Transform _rayCastPoint;
    [SerializeField] private Transform w1;
    private const float _attackRange = 1.5f;
    private Transform _target;
    [SerializeField] private int _damageAmount;
    private float _lastAttackTime;
    private readonly float _attackRate = 1.5f;
    private Barrier _barrier;
    public bool IsDead;
    //audio
    [SerializeField] private AudioClip _attackAudio;
    [SerializeField] private AudioClip _groanAudio;
    //anim ids
    private readonly int ATTACK1_ANIM = Animator.StringToHash("Attack1");
    private readonly int RUN_ANIM = Animator.StringToHash("Run");
    private readonly int IDLE_ANIM = Animator.StringToHash("Idle");
    private readonly int ATTACK2_ANIM = Animator.StringToHash("Attack2");
    private readonly int DIE_ANIM = Animator.StringToHash("Death");

    void Start()
    {
        //dmg depends on difficulty
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _target = FindPlayer;
        _damageAmount = Mathf.RoundToInt(5 / GameManager.Instance.DifficultyModifier);
        Health = Mathf.RoundToInt(40 / GameManager.Instance.DifficultyModifier);
    }

    public void SetDamage(int dmg)
    {
        _damageAmount = dmg;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead) return;
        if (Health <= 0)
        {
            Die();
            IsDead = true;
            return;
        }
        CheckObstacles();
        if (Vector3.Distance(transform.position, _target.position) > _attackRange && _barrier == null)
        {
            _navMeshAgent.isStopped = false;
            _navMeshAgent.SetDestination(_target.position);
            RunAnim();
        }
        else if(Vector3.Distance(transform.position, _target.position) <= _attackRange)
        {

            _navMeshAgent.isStopped = true;
            AttackPlayer();
        }

        if (_navMeshAgent.isStopped)
            _animator.SetBool(IDLE_ANIM, true);

    }

    private void CheckObstacles()
    {
        RaycastHit hit;
        if (Physics.Raycast(_rayCastPoint.position, transform.forward, out hit, 1f))
        {
            if (hit.transform == this.transform) return;
            if (hit.collider.CompareTag("Barrier"))
            {
                var bar = hit.collider.GetComponent<Barrier>();
                _barrier = bar;
                AttackBarrier(bar);
            }
        }
    }

    public void Die()
    {
        _navMeshAgent.isStopped = true;
        _animator.SetBool(RUN_ANIM, false);
        _animator.SetBool(ATTACK1_ANIM, false);
        _animator.SetBool(ATTACK2_ANIM, false);
        _animator.SetBool(IDLE_ANIM, false);
        _animator.SetBool(DIE_ANIM, true);
        GameManager.Instance.ZombieDied(this.gameObject);
        _target.GetComponent<PlayerHandler>().Gold += 100;
        Destroy(this.gameObject.GetComponent<Collider>());
        Destroy(gameObject, 8f);
    }
    private void RunAnim()
    {
        _animator.SetBool(RUN_ANIM, true);
        _animator.SetBool(IDLE_ANIM, false);
        _animator.SetBool(ATTACK1_ANIM, false);
        _animator.SetBool(ATTACK2_ANIM, false);
    }
    private void AttackAnim(int state)
    {
        if (state == 0)
        {
            _animator.SetBool(RUN_ANIM, false);
            _animator.SetBool(IDLE_ANIM, false);
            _animator.SetBool(ATTACK1_ANIM, true);
            _animator.SetBool(ATTACK2_ANIM, false);
        }
        else
        {
            _animator.SetBool(RUN_ANIM, false);
            _animator.SetBool(IDLE_ANIM, false);
            _animator.SetBool(ATTACK1_ANIM, false);
            _animator.SetBool(ATTACK2_ANIM, true);
        }
    }
    public void TakeDamage(int dmg)
    {
        Health -= dmg;
    }
    public void AttackPlayer()
    {
        if (Time.time - _lastAttackTime <= _attackRate) return;
        _target.GetComponent<PlayerHandler>().TakeDamage(_damageAmount);
        int rand = Random.Range(0, 2);
        transform.LookAt(_target);
        AttackAnim(rand);
        _lastAttackTime = Time.time;
    }

    public void AttackBarrier(Barrier barrier)
    {
        if (Time.time - _lastAttackTime <= _attackRate || barrier == null) return;
        barrier.TakeDamage(_damageAmount);
        transform.LookAt(barrier.transform);
        int rand = Random.Range(0, 2);
        AttackAnim(rand);
        _lastAttackTime = Time.time;
    }

    private Transform FindPlayer => GameObject.FindGameObjectWithTag("Player").transform;
}
