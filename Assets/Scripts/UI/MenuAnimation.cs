using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuAnimation : MonoBehaviour
{
    [SerializeField] private GameObject title;
    [SerializeField] private GameObject restartTextObject;

    [SerializeField] private GameObject difficultyButtonsGroup;
    
    private float _zRotationBound = 0.03f;
    private Vector3 _zRotation = new Vector3(0, 0, 1f);
    private float _speed = 0.1f;
    [SerializeField] private bool zReached;

    private GridLayoutGroup buttonGridGroup;
    private float xMinCellSize = 115.0f;
    private float xMaxCellSize = 130.0f;
    [SerializeField] private bool xCellSizeReached;
    private bool yCellReached;
    private Vector2 increaseSize = new Vector2(0.06f, 0.06f);

    private void Awake()
    {
        buttonGridGroup = difficultyButtonsGroup.GetComponent<GridLayoutGroup>();
    }

    private void FixedUpdate()
    {
        RotateTitle();
        ChangeDifficultyButton();
    }
    
    
    //Rotate Game Title between two z values
    private void RotateTitle()
    {
        if (zReached == false && title.transform.rotation.z < _zRotationBound)
        {
            title.transform.Rotate(_zRotation * _speed);
            restartTextObject.transform.Rotate(_zRotation * _speed);
            if (title.transform.rotation.z > _zRotationBound)
            {
                zReached = true;
            }
        }
        else
        {
            title.transform.Rotate(-_zRotation * _speed);
            restartTextObject.transform.Rotate(-_zRotation * _speed);
            if (title.transform.rotation.z < -(_zRotationBound))
            {
                zReached = false;
            }
        }
    }
    
    // Increase/decrease size of buttons between two x values
    private void ChangeDifficultyButton()
    {
        if (xCellSizeReached == false && buttonGridGroup.cellSize.x < xMaxCellSize)
        {
            buttonGridGroup.cellSize += increaseSize;
            if (buttonGridGroup.cellSize.x > xMaxCellSize)
            {
                xCellSizeReached = true;
            }
        }
        else
        {
            buttonGridGroup.cellSize -= increaseSize;
            if (buttonGridGroup.cellSize.x < xMinCellSize)
            {
                xCellSizeReached = false;
            }
        }
    }
}
