using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPGui : MonoBehaviour
{
    [SerializeField, Range(0, 100)]
    private float _health;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DecreaseHP());
    }

    private void OnGUI()
    {
        GUILayout.Label("HP");
        GUI.HorizontalSlider(new Rect(5,20, 200, 20), _health, 0.0f, 100.0f);
    }

    private IEnumerator DecreaseHP()
    {
        while (_health > 0)
        {
            _health -= 1;
            Debug.Log(_health);
            yield return new WaitForSeconds(1f);
        }
    }
}
