using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Link : MonoBehaviour {


    [SerializeField] private Button youTubeButton;
    public string _link;


    private void Awake() {
        youTubeButton.onClick.AddListener(() => {
            Application.OpenURL(_link);
        });
    }

}