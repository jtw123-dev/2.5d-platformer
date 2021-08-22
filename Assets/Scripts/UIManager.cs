using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]private Text _text;
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance==null)
            {
                Debug.Log("UIManager is null");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    public void UpdateCoinDisplay(int points)
    {
        _text.text = "Score: " + points.ToString();
    }
}
