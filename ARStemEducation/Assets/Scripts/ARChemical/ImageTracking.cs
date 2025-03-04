﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageTracking : MonoBehaviour
{
    [SerializeField]
    private GameObject[] placeablePrefabs;
    GameObject newPrefab;

    // for element rotation
    ARElementRotate arElementRotate;
    public Button leftButtonObj;
    public Button rightButtonObj;
    bool shouldTotateLeft;
    bool shouldTotateRight;

    // store prefabs
    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();
    private ARTrackedImageManager trackedImageManager;

    private void Start()
    {
        arElementRotate = gameObject.AddComponent<ARElementRotate>();
        shouldTotateLeft = false;
        shouldTotateRight = false;
        Button leftButton = leftButtonObj.GetComponent<Button>();
        Button rightButton = rightButtonObj.GetComponent<Button>();
        leftButton.onClick.AddListener(LeftClick);
        rightButton.onClick.AddListener(RightClick);
    }

    private void Awake()
    {
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
        foreach (GameObject prefab in placeablePrefabs)
        {
            newPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            newPrefab.name = prefab.name;
            spawnedPrefabs.Add(prefab.name, newPrefab);
        }
    }

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += ImageChanged;
    }
    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= ImageChanged;
    }

    private void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {

        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            UpdateImage(trackedImage);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdateImage(trackedImage);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            spawnedPrefabs[trackedImage.name].SetActive(false);
        }

    }
    private void UpdateImage(ARTrackedImage trackedImage)
    {
        string name = trackedImage.referenceImage.name;
        Vector3 position = trackedImage.transform.position;

        GameObject prefab = spawnedPrefabs[name];
        prefab.transform.position = position;
        prefab.SetActive(true);

        foreach(GameObject go in spawnedPrefabs.Values)
        {
            //go.gameObject.transform.Rotate(0, 1, 0);
            if(go.name != name)
            {
                go.SetActive(false);
            }
        }
    }
    private void Update()
    {
        ShouldRotate();
    }

    public void LeftClick()
    {
        shouldTotateRight = false;
        shouldTotateLeft = true;
        Debug.Log("OnCLickListener start");
    }

    public void RightClick()
    {
        shouldTotateLeft = false;
        shouldTotateRight = true;
        Debug.Log("OnCLickListener start");
    }

    public void ShouldRotate()
    {
        if (shouldTotateLeft)
        {
            foreach (GameObject go in spawnedPrefabs.Values)
            {
                go.gameObject.transform.Rotate(0, -1, 0);
            }
            Debug.Log("rotate left ing");
        }
        else if (shouldTotateRight)
        {
            foreach (GameObject go in spawnedPrefabs.Values)
            {
                go.gameObject.transform.Rotate(0, 1, 0);
            }
            Debug.Log("rotate right ing");
        }
    }
}
