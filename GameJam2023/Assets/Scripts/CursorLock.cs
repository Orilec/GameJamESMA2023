using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLock : MonoBehaviour
{

    [SerializeField] private Transform _mCursorVisual;
    [SerializeField] private Vector3 _mDisplacement;
    [SerializeField] private RectTransform _containerRectTransform;
    private bool _isLocked;
    void Start()
    {
        // this sets the base cursor as invisible
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    void Update()
    {
        var mPosition = Input.mousePosition + _mDisplacement;
        if (!_isLocked)
        {
            mPosition.x = Mathf.Clamp(mPosition.x, 0, Screen.width);
            mPosition.y = Mathf.Clamp(mPosition.y, 0, _containerRectTransform.rect.height);
        }
        else
        {
            mPosition = new Vector2(500, 80);
        }
        _mCursorVisual.position = mPosition;
    }


}
