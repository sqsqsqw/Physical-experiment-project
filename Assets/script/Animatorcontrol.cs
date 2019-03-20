using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animatorcontrol : MonoBehaviour {

    public Animator ani;
    public Slider slider;
    AnimatorStateInfo stateInfo;
    float _time = 0f;


	// Use this for initialization
	void Start () {
        stateInfo = ani.GetCurrentAnimatorStateInfo(0);

	}
	
	// Update is called once per frame
	void Update ()
    {
        _time = Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            OnSliderValueChange(slider.value);
        }
        else
        {
            if (_time >= 0.5f)
            {
                _time = 0f;
                slider.onValueChanged.AddListener(OnSliderValueChange);
                slider.value = ani.GetCurrentAnimatorStateInfo(0).normalizedTime;
            }
        }
	}
    public void OnSliderValueChange(float value)  
    {
        slider.onValueChanged.RemoveAllListeners();
        ani.Play(stateInfo.fullPathHash, 0, value);
        
    }
}

