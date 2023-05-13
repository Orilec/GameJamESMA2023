using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLock : MonoBehaviour
{

    [SerializeField] private Transform _mCursorVisual;
    [SerializeField] private Vector3 _mDisplacement;
    [SerializeField] private RectTransform _containerRectTransform;
    void Start()
    {
        // this sets the base cursor as invisible
        Cursor.visible = false;
    }

    void Update()
    {
        var mPosition = Input.mousePosition + _mDisplacement;
        mPosition.x = Mathf.Clamp(mPosition.x, 0, Screen.width);
        mPosition.y = Mathf.Clamp(mPosition.y, 0, _containerRectTransform.rect.height);
        _mCursorVisual.position = mPosition;

    }

}
