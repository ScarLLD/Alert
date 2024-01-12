using System.Collections;
using UnityEngine;

public class StealerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _firstPosition;
    [SerializeField] private Vector3 _secondPosition;

    private Vector3 _targetPosition;

    private void Awake()
    {
        _targetPosition = _firstPosition;
    }

    private void Start()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        bool isMove = true;

        while (isMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);

            if (transform.position == _targetPosition)
                ChangeNextPosition();

            yield return null;
        }
    }

    private void ChangeNextPosition()
    {
        if (transform.position == _firstPosition)
            _targetPosition = _secondPosition;

        if (transform.position == _secondPosition)
            _targetPosition = _firstPosition;
    }
}
