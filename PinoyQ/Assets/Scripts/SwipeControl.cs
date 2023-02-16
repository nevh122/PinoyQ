using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SwipeDirection
{
    Right,
    Left,
    Up,
    Down
}

public class SwipeControl : MonoBehaviour
{
    public static System.Action<SwipeDirection> SwipeAction;
    Vector2 Origin;
    Vector2 End;
    Vector2 SwipeDir;
    float SwipeMagnitude = 0.05f;
    bool isSwiping;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Checks if the initial mouse position connects with the 2D Collider
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Origin = Input.mousePosition;
            Origin.x /= Screen.width;
            Origin.y /= Screen.height;
            
            isSwiping = true;          
        }
        else if (Input.GetMouseButton(0) && isSwiping)
        {
            End = Input.mousePosition;
            End.x /= Screen.width;
            End.y /= Screen.height;

            SwipeDir = Vector2.zero;
            SwipeDir.x = End.x - Origin.x;
            SwipeDir.y = End.y - Origin.y;

            if (SwipeDir.magnitude > SwipeMagnitude)
            {
                isSwiping = false;
                if (Mathf.Abs(SwipeDir.x) > Mathf.Abs(SwipeDir.y))
                {
                    if (SwipeDir.x > 0)
                        //Debug.Log("Right");
                    CallSwipeAction(SwipeDirection.Right);
                    else
                        //Debug.Log("Left");
                    CallSwipeAction(SwipeDirection.Left);
                }
                else
                {
                    if (SwipeDir.y > 0)
                        //Debug.Log("Up");
                    CallSwipeAction(SwipeDirection.Up);
                    else
                        //Debug.Log("Down");
                    CallSwipeAction(SwipeDirection.Down);
                }
            }
        }
        else
            isSwiping = false;
    }

    void CallSwipeAction(SwipeDirection _whichDir)
    {
        if (SwipeAction != null)
            SwipeAction(_whichDir);
    }
}
