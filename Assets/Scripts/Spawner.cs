using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Coin _coinTemplate;
    [SerializeField] private Bomb _bombTemplate;
    [SerializeField] private int _objectsCount;

    private void Start()
    {
        for (int i = 0; i < _objectsCount; i++)
        {
            Vector3 randomSpawnVector = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100));
            if (Random.Range(0, 3) == 0)
                Instantiate(_coinTemplate, randomSpawnVector, Quaternion.identity, transform);
            else
                Instantiate(_bombTemplate, randomSpawnVector, Quaternion.identity, transform);
        }
    }
}
