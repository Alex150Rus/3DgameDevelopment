using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSettings : MonoBehaviour
{
    [SerializeField]
    private Color Sky, Equator, Ground, SunColor; // Цвета солнца, и Ambient Skybox
    [SerializeField]
    private float RotateSpeed; // Скорость вращения солнца

    private Light Sun; // Ссылка на источник освещения


    // Start is called before the first frame update
    void Awake()
    {
        Sun = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        // Настраиваем Ambient Skybox Color
        RenderSettings.ambientSkyColor = Sky;
        RenderSettings.ambientGroundColor = Ground;
        RenderSettings.ambientEquatorColor = Equator;
        // Настраиваем цвет солнца
        Sun.color = SunColor;
        // Вращаем солнце
        transform.Rotate(transform.right, RotateSpeed, Space.Self);
    }
}
