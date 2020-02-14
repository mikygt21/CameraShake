using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraShake : MonoBehaviour
{
    private float m_spring = 0.0f;
    private float m_damper = 0.0f;
    private float m_shake = 0.0f;

    [Range(0f, 20f)]
    [SerializeField] float m_maxvelocity;
    [Space]

    [Header("Sliders")]

    [SerializeField] Slider m_springSlider;
    [SerializeField] Slider m_damperSlider;
    [SerializeField] Slider m_shakeSlider;

    public Vector2 PositionDiff { get { return m_initialPos - (Vector2)this.transform.position; } }

    private Vector2 m_velocity;
    private Vector2 m_initialPos;

    // Start is called before the first frame update
    void Start()
    {
        m_springSlider.onValueChanged.AddListener(delegate { m_spring = Mathf.Min( Mathf.Max( m_springSlider.value, 0.1f)); });
        m_damperSlider.onValueChanged.AddListener(delegate { m_damper = m_damperSlider.value; });
        m_shakeSlider.onValueChanged.AddListener(delegate { m_shake = m_shakeSlider.value; });

        m_spring = m_springSlider.value;
        m_damper = m_damperSlider.value;
        m_shake = m_shakeSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(m_spring + " - " + m_damper + " - " + m_shake);
        m_velocity += (m_initialPos - (Vector2)this.transform.position) * m_spring;
        m_velocity -= m_velocity * m_damper;
        transform.position = m_velocity;
    }

    public void AddShake(Vector2 input)
    {
        m_velocity += input * m_shake;
        m_velocity = new Vector2(Mathf.Clamp(-m_velocity.x, m_velocity.y, m_maxvelocity), Mathf.Clamp(-m_velocity.x, m_velocity.y, m_maxvelocity));

        if(m_velocity.magnitude > m_maxvelocity) {
            float index = m_velocity.magnitude / m_maxvelocity;
            m_velocity *= (1f / index);
        }
    }
}
