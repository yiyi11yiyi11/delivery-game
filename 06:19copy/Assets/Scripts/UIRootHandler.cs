using UnityEngine;
using UnityEngine.UI;
 
public class UIRootHandler : MonoBehaviour {
	void Awake () {
            UIManager.Instance.m_CanvasRoot = gameObject;
	}
}
