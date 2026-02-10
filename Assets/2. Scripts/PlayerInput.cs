using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Camera mainCamera;
    Character character;

    [SerializeField] GameObject clickEffect;
    [SerializeField] float interactRange = 2.0f;

    ObjectOutline currentOutline;

    Dictionary<KeyCode, Action> keyActions;

    void Awake()
    {
        mainCamera = Camera.main;
        character = GetComponent<Character>();

        keyActions = new Dictionary<KeyCode, Action>()
        {
            { KeyCode.S, Stop },
            // { KeyCode.A, Attack },
        };
    }

    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        bool hasHit = Physics.Raycast(ray, out RaycastHit hit);

        // 오브젝트 외곽선
        if (hasHit)
        {
            if (hit.collider.TryGetComponent(out ObjectOutline newOutline))
            {
                if (currentOutline != newOutline)
                {
                    ClearOutline();
                    newOutline.SetOutline(true);
                    currentOutline = newOutline;
                }
            }
            else
            {
                ClearOutline();
            }
        }
        else
        {
            ClearOutline();
        }

        // 이동
        if (Input.GetMouseButton(1) && hasHit)
        {
            character.Movement.MoveTo(hit.point);
        }

        // 우클릭 이펙트
        if (Input.GetMouseButtonDown(1) && hasHit)
        {
            Instantiate(clickEffect, hit.point + Vector3.up * 0.03f, Quaternion.LookRotation(hit.normal));
        }

        // 키 입력 처리
        HandleKeyboard();
    }

    void HandleKeyboard()
    {
        foreach (var pair in keyActions)
        {
            if (Input.GetKeyDown(pair.Key))
            {
                pair.Value.Invoke();
            }
        }
    }

    void Stop()
    {
        character.Movement.Stop();
    }

    void ClearOutline()
    {
        if (currentOutline != null)
        {
            currentOutline.SetOutline(false);
            currentOutline = null;
        }
    }
}
