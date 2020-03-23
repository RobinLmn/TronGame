using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObjectMover : MonoBehaviourPun, IPunObservable
{
    [SerializeField]
    private float _moveSpeed = 1f;

    private Animator _animator;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //if (stream.IsWriting)
        //{
        //    stream.SendNext(transform.position);
        //    stream.SendNext(transform.rotation);
        //}
        //else if (stream.IsReading)
        //{
        //    transform.position = (Vector3)stream.ReceiveNext();
        //    transform.rotation = (Quaternion)stream.ReceiveNext();
        //}
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (base.photonView.IsMine)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            transform.position += (new Vector3(x, y, 0f) * _moveSpeed);

            UpdateMovingBoolean((x != 0f || y != 0f));
        }
    }

    private void UpdateMovingBoolean(bool moving)
    {
        _animator.SetBool("Moving", moving);
    }    
 
}
