using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    
    [SerializeField] private Gradient gradient;

    private Image _healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        _healthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        _healthBar.color = gradient.Evaluate(_healthBar.fillAmount);
    }
}
