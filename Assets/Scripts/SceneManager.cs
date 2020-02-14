﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] GameObject[] m_scenes;
    private int m_currentIndex = 0;


    // Update is called once per frame
    public void ChangeScene(int val)
    {
        m_scenes[m_currentIndex].SetActive(false);
        m_currentIndex = (m_currentIndex + (val < 0 ? val + Mathf.Abs(val) * m_scenes.Length : val)) % m_scenes.Length;
        m_scenes[m_currentIndex].SetActive(true);
    }
}
