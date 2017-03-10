// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayerAnimatorManager.cs" company="Exit Games GmbH">
//   Part of: Photon Unity Networking Demos
// </copyright>
// <summary>
//  Used in DemoAnimator to cdeal with the networked player Animator Component controls.
// </summary>
// <author>developer@exitgames.com</author>
// ����ע�ͣ������ƣ�CloudHu��
// --------------------------------------------------------------------------------------------------------------------


using UnityEngine;
using System.Collections;

namespace ExitGames.Demos.DemoAnimator
{
	public class PlayerAnimatorManager : Photon.MonoBehaviour 
	{
		#region PUBLIC PROPERTIES

		public float DirectionDampTime = 0.25f;

		#endregion

		#region PRIVATE PROPERTIES

		Animator animator;

		#endregion

		#region MONOBEHAVIOUR MESSAGES

		/// <summary>
		/// MonoBehaviour method called on GameObject by Unity during initialization phase.
		/// </summary>
	    void Start () 
	    {
	        animator = GetComponent<Animator>();    //��ȡ�������
        }
	        
		/// <summary>
		/// MonoBehaviour method called on GameObject by Unity on every frame.
		/// </summary>
	    void Update () 
	    {

			// Prevent control is connected to Photon and represent the localPlayer
	        if( photonView.isMine == false && PhotonNetwork.connected == true )
	        {
	            return;
	        }

            //���û�л�ȡ���򱨴�
            if (!animator)
	        {
				return;//���û�л�ȡ���������������return�ж�
            }

            // ������Ծ
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

            // ֻ�е������ڱ��ܵ�ʱ�������Ծ��
            if (stateInfo.IsName("Base Layer.Run"))
            {
                // ��ʱʹ�ô���������
                if (Input.GetButtonDown("Fire2")) animator.SetTrigger("Jump"); 
			}
           
			// �����ƶ�
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");


            if( v < 0)//��ֵУ��
            {
                v = 0;
            }

            //�����ٶȲ���ֵ
            animator.SetFloat( "Speed", h*h+v*v );
            animator.SetFloat( "Direction", h, DirectionDampTime, Time.deltaTime );
	    }

		#endregion

	}
}