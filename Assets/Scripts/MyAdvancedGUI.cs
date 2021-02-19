using UnityEngine;


public class MyAdvancedGUI : MonoBehaviour
{
    private float mySlider = 1.0f; // Положение пользовательского слайдера
    public Color myColor;         // Градиент цвета
    public MeshRenderer GO;      // Ссылка на рендер объекта
    public GUISkin mySkin;

    void OnGUI()
    {
        GUI.skin = mySkin;
        mySlider = LabelSlider(new Rect(10, 50, 200, 20), mySlider, 0.0f, 5.0f, "My Slider"); // Отрисовка пользовательского слайдера
        myColor = RGBSlider(new Rect(10, 70, 200, 20), myColor);  // Отрисовка пользовательского набора слайдеров для получения градиента цвета
        GO.material.color = myColor; // Покраска объекта
    }

    // Отрисовка пользовательского слайдера
    float LabelSlider(Rect screenRect, float sliderValue, float sliderMinValue, float sliderMaxValue, string labelText) // ДЗ добавить MinValue
    {
        // создаём прямоугольник с координатами в пространстве и заданой шириной и высотой 
        Rect labelRect = new Rect(screenRect.x, screenRect.y, screenRect.width / 2, screenRect.height);
               
        GUI.Label(labelRect, labelText);   // создаём Label на экране

        Rect sliderRect = new Rect(screenRect.x + screenRect.width / 2, screenRect.y, screenRect.width / 2, screenRect.height); // Задаём размеры слайдера
        sliderValue = GUI.HorizontalSlider(sliderRect, sliderValue, sliderMinValue, sliderMaxValue); // Вырисовываем слайдер и считываем его параметр
        return sliderValue; // Возвращаем значение слайдера
    }

    // Отрисовка тройной слайдер группы, каждый слайдер отвечает за свой цвет
    Color RGBSlider(Rect screenRect, Color rgb)
    {
        // Используя пользовательский слайдер, создаём его
        rgb.r = LabelSlider(screenRect, rgb.r, 0.0f, 1.0f, "Red");
        
        // делаем промежуток
        screenRect.y += 20;
        rgb.g = LabelSlider(screenRect, rgb.g, 0.0f, 1.0f, "Green");

        screenRect.y += 20;
        rgb.b = LabelSlider(screenRect, rgb.b, 0.0f, 1.0f, "Blue");

        screenRect.y += 20;
        rgb.a = LabelSlider(screenRect, rgb.a, 0.0f, 1.0f, "alpha");

        return rgb; // возвращаем цвет
    } 
}
