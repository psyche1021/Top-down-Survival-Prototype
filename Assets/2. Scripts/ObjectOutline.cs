using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ObjectOutline : MonoBehaviour
{
    [SerializeField] Color outlineColor = Color.yellow;
    [SerializeField, Range(1.001f, 1.1f)] float outlineScale = 1.03f;

    GameObject outlineObj;
    Material outlineMat;

    void Awake()
    {
        CreateOutline();
        SetOutline(false); // 기본은 꺼둠
    }

    void CreateOutline()
    {
        MeshFilter srcMF = GetComponent<MeshFilter>();

        // Outline 오브젝트 생성
        outlineObj = new GameObject("Outline");
        outlineObj.transform.SetParent(transform);
        outlineObj.transform.localPosition = Vector3.zero;
        outlineObj.transform.localRotation = Quaternion.identity;
        outlineObj.transform.localScale = Vector3.one * outlineScale;

        // Raycast 방지 (중요)
        outlineObj.layer = LayerMask.NameToLayer("Ignore Raycast");

        // Mesh 복사
        MeshFilter ofMF = outlineObj.AddComponent<MeshFilter>();
        ofMF.sharedMesh = srcMF.sharedMesh;

        MeshRenderer ofMR = outlineObj.AddComponent<MeshRenderer>();

        // URP Unlit Material
        outlineMat = new Material(Shader.Find("Universal Render Pipeline/Unlit"));
        outlineMat.SetColor("_BaseColor", outlineColor);

        // 핵심: 앞면 제거 → 테두리만 보이게
        outlineMat.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Front);

        ofMR.material = outlineMat;

        // 그림자 관련 제거
        ofMR.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        ofMR.receiveShadows = false;
    }

    public void SetOutline(bool active)
    {
        if (outlineObj != null)
            outlineObj.SetActive(active);
    }

    void OnDestroy()
    {
        if (outlineMat != null)
            Destroy(outlineMat);
    }
}
