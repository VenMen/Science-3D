using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] private AnimationCurve _movingCurve;
    private float _totalTime;
    private float _currentTime;

    void Start()
    {
        _totalTime = _movingCurve.keys[_movingCurve.keys.Length - 1].time;
        _currentTime = Random.Range(0, 1f);
    }

    private void FixedUpdate()
    {
        gameObject.transform.position = new Vector3(transform.position.x, _movingCurve.Evaluate(_currentTime), transform.position.z);
        _currentTime += Time.fixedDeltaTime;
        if (_currentTime > _totalTime)
        {
            _currentTime = 0;
        }
    }
}
