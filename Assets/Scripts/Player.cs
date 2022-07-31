using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;
    private bool staying = true;
    private Queue<Vector2> moveToPositionQueue = new Queue<Vector2>();

    [SerializeField] PathDrawer pathDrawer;
    [SerializeField] LineRenderer lineRenderer;

    private void Update()
    {
        if (PlayerInput.GetMouseButtonDown(0))
        {
            var clickPosition = (Vector2)Game.cam.ScreenToWorldPoint(Input.mousePosition);
            moveToPositionQueue.Enqueue(clickPosition);
            pathDrawer.LinePointAdded(lineRenderer, clickPosition);
        }

        if (staying && moveToPositionQueue.Count > 0)
        {
            StartCoroutine(Move(moveToPositionQueue.Dequeue()));
        }
    }

    IEnumerator Move(Vector2 targetPosition)
    {
        staying = false;
        while (true)
        {
            lineRenderer.SetPosition(0, transform.position);
            var step = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, step);
            if (Vector2.Distance(transform.position, targetPosition) < 0.001f)
            {
                break;
            }
            yield return null;
        }
        transform.position = targetPosition;
        pathDrawer.LinePointReached(lineRenderer);
        staying = true;
    }

    public void Die()
    {
        EventManager.SendPlayerDied();
        Destroy(gameObject);
    }
}
