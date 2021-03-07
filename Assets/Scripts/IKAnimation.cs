using UnityEngine;

[RequireComponent(typeof(Animator))]
public class IKAnimation : MonoBehaviour
{
    [SerializeField] private Animator animatorGO;
    
    //the object to work with hands;
    [SerializeField] private Transform handObj;
    
    //the object which we are looking at
    [SerializeField] private Transform lookObj;

    [SerializeField] private Transform rightFoot;
    [SerializeField] private Transform leftFoot;

    [SerializeField] private float rightHandWeight = 1;
    [SerializeField] private bool ikActive;

    // Start is called before the first frame update
    void Start()
    {
        animatorGO = GetComponent<Animator>();
    }

    //calls each time when animation is updated
    private void OnAnimatorIK(int layerIndex)
    {
        if (ikActive)
        {
            if(handObj)
            {
                //������� ���� ���������� ���. �� ������� ������ ��������� ������� ����� � ������� ������ �� 
                //������� ���� ��������. ���� ��� ����� 1, �� ���� ��� ���� (�.�., ��, ��� �� �������)
                //����� ��������� ������ � �������, �������� � ����. ���� 0, �� ��� �� �������� �� ��������.
                //0,5 - ������������. ��� �������� ����������� ��������� ���� �����������. ��������, ���
                //����� �� � ����, ��� ������� � ��� �������.
                animatorGO.SetIKPositionWeight(AvatarIKGoal.RightHand, rightHandWeight);
                animatorGO.SetIKRotationWeight(AvatarIKGoal.RightHand, rightHandWeight);

                animatorGO.SetIKPosition(AvatarIKGoal.RightHand, handObj.position);
                animatorGO.SetIKRotation(AvatarIKGoal.RightHand, handObj.rotation);
            }

            if(lookObj)
            {
                animatorGO.SetLookAtWeight(1);

                animatorGO.SetLookAtPosition(lookObj.position);
            }
        } else
        {
            animatorGO.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            animatorGO.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
            animatorGO.SetLookAtWeight(0);
        }
    }
}
