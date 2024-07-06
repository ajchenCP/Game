using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Pathfinding;
using UnityEngine;

[RequireComponent(typeof(Seeker))]
public abstract class SmallMonster : MonoBehaviour
{
    private Seeker _seeker;
    [SerializeField]
    private Transform _player;
    private int _currentWaypointIndex=0;

    [SerializeField]
    private List<Vector3> _pathWaypoints=new List<Vector3>();

    private float _timer = 0f;
    [SerializeField]
    private float _interval = 0.5f;

    [SerializeField]
    private float _speed = 1f;

    [SerializeField]
    private float _gap = 5f;

    [SerializeField]
    bool _isAttackable = false;
    private void Awake() {
        _seeker = GetComponent<Seeker>();
    }

    private void Update() {
        if(Vector2.Distance(transform.position,_player.position)<=_gap)
        {
            _isAttackable=true;
            Attack();
            return;
        }else _isAttackable=false;

         _timer += Time.deltaTime;

        if (_timer >= _interval)
        {
            GetPath(_player.position);
            _timer = 0f;
        }

        Seek();
        Vector3 dir = (_pathWaypoints[_currentWaypointIndex]-transform.position).normalized;
        transform.position+=dir*Time.deltaTime*_speed;        
    }

    protected abstract void Attack();

    private void GetPath(Vector3 targetPosition)
    {
        _currentWaypointIndex=0;
        _seeker.StartPath(transform.position, targetPosition, p=>{
            _pathWaypoints=p.vectorPath;
        });
    }

    private void Seek(){

        if (_pathWaypoints.Count is <= 0 ||_pathWaypoints==null){
            GetPath(_player.position);
        }else if(Vector2.Distance(transform.position,_pathWaypoints[_currentWaypointIndex])<=0.1f)
        {
            _currentWaypointIndex++;
            if(_currentWaypointIndex>=_pathWaypoints.Count)
            {
                GetPath(_player.position);
            }
        }
    }
}
