using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Arrow : MonoBehaviour
{

    public Transform target;  // 목표 지점
    public Vector3 targetPosition = new Vector3(11.224f, 0.761f, 0.376f);  // 목표 위치

    private NavMeshAgent navMeshAgent;
    Vector3 a;
    void Start()
    {
        a = gameObject.transform.localPosition;
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        navMeshAgent.speed = 0;  // 이동 속도 0으로 설정 (화살표만 회전)
    }

    void Update()
    {
        if(gameObject.transform.position != a)
        {
            gameObject.transform.localPosition = a;
        }
        // 목표 지점으로 내비게이션 설정
        navMeshAgent.SetDestination(targetPosition);

        // NavMesh 경로를 얻고, 첫 번째 경로 포인트를 사용하여 회전
        if (navMeshAgent.pathPending || navMeshAgent.path.corners.Length < 2)
            return;

        // 첫 번째 코너(목표지점과 가까운 경로)를 바라보도록 회전
        Vector3 direction = navMeshAgent.path.corners[1] - transform.position;
        direction.y = 0;  // 수평면에서만 회전
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
    }
}
