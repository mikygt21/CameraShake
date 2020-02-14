using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraShake : MonoBehaviour
{
    private float m_spring = 0.0f;
    private float m_damper = 0.0f;
    private float m_shake = 0.0f;

    [SerializeField] Slider m_springSlider;
    [SerializeField] Slider m_damperSlider;
    [SerializeField] Slider m_shakeSlider;

    public Vector2 PositionDiff = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        m_springSlider.onValueChanged.AddListener(delegate { m_spring = m_springSlider.value; });
        m_damperSlider.onValueChanged.AddListener(delegate { m_damper = m_damperSlider.value; });
        m_shakeSlider.onValueChanged.AddListener(delegate { m_shake = m_shakeSlider.value; });

        m_spring = m_springSlider.value;
        m_damper = m_damperSlider.value;
        m_shake = m_shakeSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(m_spring + " - " + m_damper + " - " + m_shake);

    }

    public void AddShake(Vector2 input)
    {

    }
}
