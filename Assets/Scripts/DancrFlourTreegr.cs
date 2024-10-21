using UnityEngine;

public class DancrFlourTreegr : MonoBehaviour
{
    private Transform _child;
    [SerializeField] private Animator _animator;
    [SerializeField] private string _nameChild;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Vizitor"))
        {
            _child = other.transform.GetChild(0);
            _animator = _child.GetComponent<Animator>();
            _animator.SetBool("Dance", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Vizitor"))
        {
            _child = other.transform.GetChild(0);
            _animator = _child.GetComponent<Animator>();
            _animator.SetBool("Dance", false);
        }
    }
}
