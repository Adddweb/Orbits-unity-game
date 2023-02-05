using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodiesCountController : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _stext;
    [SerializeField] private GameObject BodiePrefab;
    [SerializeField] private GameObject parent;
    [SerializeField] private GameObject[] bodies;
    private float oldsvalue = 0;
    void Start()
    {
        bodies = new GameObject[(int)_slider.maxValue];
        /*_slider.onValueChanged.AddListener((v) =>
        {
            if(v == 0)
            {
                foreach(var body in bodies)
                {
                    Destroy(body.gameObject);
                }
            }
            else
            {
                _stext.text = v.ToString() + " bodies";
                
            }
        });*/
            
    }
    void Update()
    {
        if(_slider.value != oldsvalue)
        {
            if(_slider.value > oldsvalue && _slider.value != 0)
            {
                _stext.text = _slider.value.ToString() + " bodies";
                bodies[(int)_slider.value - 1] = Instantiate(BodiePrefab);
                bodies[(int)_slider.value - 1].transform.position = new Vector2(Random.Range(-9.0f, 9.0f), Random.Range(-3.0f, 3.0f));
                bodies[(int)_slider.value - 1].transform.SetParent(parent.transform);
                oldsvalue = _slider.value;
            }
            else if(_slider.value < oldsvalue && _slider.value != 0)
            {
                _stext.text = _slider.value.ToString() + " bodies";
                Destroy(bodies[(int)_slider.value - 1]);
                bodies[(int)_slider.value - 1] = null;
                oldsvalue = _slider.value;
            }
            else if(_slider.value == 0)
            {
                _stext.text = _slider.value.ToString() + " bodies";
                for(int i = 0; i < bodies.Length; i++)
                {
                    Destroy(bodies[i]);
                    bodies[i] = null;
                }    
                oldsvalue = 0;
            }
        }
    }
    public void OnPauseButtonDown()
    {
        Time.timeScale = 0f;
    }
    public void OnResumeButtonDown()
    {
        Time.timeScale = 1f;
    }
}
