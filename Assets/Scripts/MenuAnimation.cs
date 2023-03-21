using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuAnimation : MonoBehaviour
{
    [SerializeField] private GameObject title;

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
        Debug.Log("deltaTime " + Time.deltaTime);
    }
    

    private void RotateTitle()
    {
        if (zReached == false && title.transform.rotation.z < _zRotationBound)
        {
            title.transform.Rotate(_zRotation * _speed);
            if (title.transform.rotation.z > _zRotationBound)
            {
                Debug.Log("Time Title " + Time.time);
                zReached = true;
            }
        }
        else
        {
            title.transform.Rotate(-_zRotation * _speed);
            if (title.transform.rotation.z < -(_zRotationBound))
            {
                zReached = false;
            }
        }
    }

    private void ChangeDifficultyButton()
    {
        if (xCellSizeReached == false && buttonGridGroup.cellSize.x < xMaxCellSize)
        {
            buttonGridGroup.cellSize += increaseSize;
            if (buttonGridGroup.cellSize.x > xMaxCellSize)
            {
                Debug.Log("Time Buttons " + Time.time);
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
