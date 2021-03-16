using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int wayPointCount; // �̵� ��� ����
    private Transform[] wayPoints; // �̵� ��� ����
    private int currentIndex = 0; // ���� ��ǥ���� �ε���
    private Movement2D movement2D; 

   
    public void Setup(Transform[] wayPoints)
    {
        movement2D = GetComponent<Movement2D>();

        // �� �̵� ��� WayPoints ���� ����
        wayPointCount = wayPoints.Length;
        this.wayPoints = new Transform[wayPointCount];
        this.wayPoints = wayPoints;

        // �� ��ġ ù��° wayPoint ��ġ�� ����
        transform.position = wayPoints[currentIndex].position;

        StartCoroutine("OnMove");
        
    }

    // Update is called once per frame
    private IEnumerator OnMove()
    {
        // ���� �̵� ���� ����
        NextMoveTo();

        while(true)
        {
            //ȸ��
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
            // �̵� ���� ���� ���� ��ǥ����
            currentIndex ++;
            Vector3 direction = (wayPoints[currentIndex].position - transform.position).normalized;
            movement2D.MoveTo(direction);
        }
        // ���� ��ġ�� ��ǥ�����̸�
        else
        {
            Destroy(gameObject);
        }
    }
}
