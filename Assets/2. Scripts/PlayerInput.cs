using UnityEngine;
using UnityEngine.AI;

public class PlayerInput : MonoBehaviour
{
    Camera mainCamera;
    Character character;

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
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            character.Movement.Stop();
        }
    }
}

// 딕셔너리를 활용해 키 입력과 행동을 매핑해 확장성을 고려하는 방안은 추후 버튼이 많아지면 고려