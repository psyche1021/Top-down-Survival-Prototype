using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField, Tooltip("카메라 이동속도")] float moveSpeed = 50f;
    [SerializeField, Tooltip("가장자리 경계선 크기")] float borderSize = 5f;

    // 나중에 맵 크기에 따라 변경할 것
    [SerializeField, Tooltip("최소 이동 가능 범위")] Vector2 minLimit;
    [SerializeField, Tooltip("최소 이동 가능 범위")] Vector2 maxLimit;

    [SerializeField, Tooltip("따라다닐 대상")] Transform target;

    Vector3 targetPos; // 카메라 위치
    bool cameraToggle = false;
    bool isFollowing = false;

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("CameraController에 Target이 없음");
            enabled = false;
            return;
        }

        targetPos = transform.position;
    }

    void Update()
    {
        CameraToggle();

        if (isFollowing)
        {
            CameraMove();
        }
        else
        {
            Vector3 dir = GetEdgeDirection();
            CameraDirMove(dir);
            ClampPosition();
        }

        transform.position = targetPos;
    }

    void CameraDirMove(Vector3 dir)
    {
        if (dir == Vector3.zero) return;

        targetPos += dir * moveSpeed * Time.deltaTime;
    }

    void ClampPosition()
    {
        targetPos.x = Mathf.Clamp(targetPos.x, minLimit.x, maxLimit.x);
        targetPos.z = Mathf.Clamp(targetPos.z, minLimit.y, maxLimit.y);
    }

    void CameraToggle()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            cameraToggle = !cameraToggle;
        }

        isFollowing = Input.GetKey(KeyCode.Space) || cameraToggle;
    }

    void CameraMove()
    {
        targetPos = target.position;
    }

    Vector3 GetEdgeDirection()
    {
        Vector3 mouse = Input.mousePosition;
        Vector3 dir = Vector3.zero;

        if (mouse.y >= Screen.height - borderSize) dir.z += 1; // 상
        if (mouse.y <= borderSize) dir.z -= 1; // 하
        if (mouse.x <= borderSize) dir.x -= 1; // 좌
        if (mouse.x >= Screen.width - borderSize) dir.x += 1; // 우
        return dir.normalized;// 대각선 이동 보간
    }
}
