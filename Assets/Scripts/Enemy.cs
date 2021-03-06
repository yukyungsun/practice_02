using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int wayPointCount; // 이동 경로 개수
    private Transform[] wayPoints; // 이동 경로 정보
    private int currentIndex = 0; // 현재 목표지점 인덱스
    private Movement2D movement2D; 

   
    public void Setup(Transform[] wayPoints)
    {
        movement2D = GetComponent<Movement2D>();

        // 적 이동 경로 WayPoints 정보 설정
        wayPointCount = wayPoints.Length;
        this.wayPoints = new Transform[wayPointCount];
        this.wayPoints = wayPoints;

        // 적 위치 첫번째 wayPoint 위치로 설정
        transform.position = wayPoints[currentIndex].position;

        StartCoroutine("OnMove");
        
    }

    // Update is called once per frame
    private IEnumerator OnMove()
    {
        // 다음 이동 방향 설정
        NextMoveTo();

        while(true)
        {
            //회전
            transform.Rotate(Vector3.forward * 10);

            if (Vector3.Distance(transform.position, wayPoints[currentIndex].position) < 0.02f * movement2D.MoveSpeed )
            {
                NextMoveTo();
            }

            yield return null;

        }
    }

    private void NextMoveTo()
    {
        if ( currentIndex < wayPointCount - 1)
        {
            transform.position = wayPoints[currentIndex].position;
            // 이동 방향 설정 다음 목표지점
            currentIndex ++;
            Vector3 direction = (wayPoints[currentIndex].position - transform.position).normalized;
            movement2D.MoveTo(direction);
        }
        // 현재 위치가 목표지점이면
        else
        {
            Destroy(gameObject);
        }
    }
}
