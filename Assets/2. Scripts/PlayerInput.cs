using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Camera mainCamera;
    Character character;

    [SerializeField] GameObject clickEffect;

    void Awake()
    {
        mainCamera = Camera.main;
        character = GetComponent<Character>();
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                character.Movement.MoveTo(hit.point);

                if (Input.GetMouseButtonDown(1))
                {
                    Instantiate(clickEffect, hit.point + Vector3.up * 0.03f, Quaternion.LookRotation(hit.normal));
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            character.Movement.Stop();
        }
    }
}

// 추후 버튼이 많아지면 딕셔너리를 활용하여 키 입력과 행동을 매핑해 확장성을 고려