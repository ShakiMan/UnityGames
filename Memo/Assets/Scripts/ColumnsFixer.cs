using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColumnsFixer : MonoBehaviour
{
    private GridLayoutGroup _layoutGroup;

    void Start()
    {
        _layoutGroup = gameObject.GetComponent<GridLayoutGroup>();
        _layoutGroup.constraint = GridLayoutGroup.Constraint.FixedRowCount;
        if (MenuScript.Height == 4 && MenuScript.Width == 4)
        {
            _layoutGroup.constraintCount = 4;
        }
        else
        {
            _layoutGroup.constraintCount = 2;
        }
    }
}
