using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSettings : MonoBehaviour
{
    [SerializeField]
    private Color Sky, Equator, Ground, SunColor; // ����� ������, � Ambient Skybox
    [SerializeField]
    private float RotateSpeed; // �������� �������� ������

    private Light Sun; // ������ �� �������� ���������


    // Start is called before the first frame update
    void Awake()
    {
        Sun = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        // ����������� Ambient Skybox Color
        RenderSettings.ambientSkyColor = Sky;
        RenderSettings.ambientGroundColor = Ground;
        RenderSettings.ambientEquatorColor = Equator;
        // ����������� ���� ������
        Sun.color = SunColor;
        // ������� ������
        transform.Rotate(transform.right, RotateSpeed, Space.Self);
    }
}
