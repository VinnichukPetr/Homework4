using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class HeartDisplay : MonoBehaviour
{
    [SerializeField] private Airplane _airplane;
    [SerializeField] private Image _heartImage;
    [SerializeField] private Transform _spawnPoint;

    private List<Image> _images = new List<Image>();

    private void Start()
    {
        Vector3 spawnPosition = _spawnPoint.position;

        for (int i = 0; i < _airplane.HealthValue; i++)
        {   
            Image image = Instantiate(_heartImage, spawnPosition, Quaternion.identity, transform);
            spawnPosition.x += 100;
            _images.Add(image);
        }
    }

    private void OnEnable() => _airplane.HealthChanged += OnHealthChanged;
    private void OnDisable() => _airplane.HealthChanged -= OnHealthChanged;

    private void OnHealthChanged()
    {
        var deletedHeart = _images[^1];
        _images.Remove(deletedHeart);
        deletedHeart.gameObject.SetActive(false);
    }
}
