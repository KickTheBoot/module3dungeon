using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]Transform Target;

    [SerializeField] string TargetName;

    float FollowSpeed;
    AnimationCurve FollowSpeedCurve;

    public float Speed;

    [SerializeField] Vector2 FollowOffset;
    Vector2 Treshold;
    // Start is called before the first frame update
    void Start()
    {
        Treshold = CalculateTreshold();
    }

    // Update is called once per frame
    void Update()
    {
        if(Target)
        {

        }
        

    }

    void FixedUpdate()
    {
        if(Target)
        {
            Vector2 follow = Target.position;
            float xDifference = Mathf.Abs(follow.x - transform.position.x);
            float yDifference = Mathf.Abs(follow.y - transform.position.y);

            Vector2 NewPosition = transform.position;

            if(xDifference >= Treshold.x)
            {
                NewPosition.x = follow.x;
            }
            if(yDifference >= Treshold.y)
            {
                NewPosition.y = follow.y;
            }

            transform.position = Vector3.MoveTowards(transform.position, follow, Speed * Time.fixedDeltaTime);
        }
        else
        {
            Target = GameObject.Find(TargetName).transform;
        }

    }

    private Vector3 CalculateTreshold()
    {
        Rect aspect = Camera.main.pixelRect;
        Vector2 t = new Vector2(Camera.main.orthographicSize * aspect.width/aspect.height, Camera.main.orthographicSize);
        t.x -= FollowOffset.x;
        t.y -= FollowOffset.y;
        return t;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector2 border = CalculateTreshold();
        Gizmos.DrawWireCube(transform.position, border * 2);

    }
}
