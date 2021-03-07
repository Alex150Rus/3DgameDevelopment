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

    [SerializeField] private float weightLeftFoot;
    [SerializeField] private float weightRightFoot;

    private Vector3 rightfootPos;
    private int rightHash;
    private int leftHash;

    // Start is called before the first frame update
    void Start()
    {
        animatorGO = GetComponent<Animator>();

        rightHash = Animator.StringToHash("rightFoot");
        leftHash =  Animator.StringToHash("leftFoot");
    }

    //calls each time when animation is updated
    private void OnAnimatorIK(int layerIndex)
    {
        if (ikActive)
        {
            weightLeftFoot = animatorGO.GetFloat(leftHash);
            weightRightFoot = animatorGO.GetFloat(rightHash);

            animatorGO.SetIKPositionWeight(AvatarIKGoal.LeftFoot, weightLeftFoot);
            animatorGO.SetIKRotationWeight(AvatarIKGoal.LeftFoot, weightLeftFoot);
            animatorGO.SetIKPositionWeight(AvatarIKGoal.RightFoot, weightRightFoot);
            animatorGO.SetIKRotationWeight(AvatarIKGoal.RightFoot, weightRightFoot);
            
            RaycastHit hit;

            if (Physics.Raycast(rightFoot.position, Vector3.down, out hit, 3f))
                rightfootPos = hit.point;

            //когда мы попадаем в какую-то поверхность, мы получаем hitPoint и к этой поверхности стемится нога
            animatorGO.SetIKPosition(AvatarIKGoal.RightFoot, rightfootPos);

            if (handObj)
            {
                //вначале надо установить вес. На сколько сильно изменение позиции кодом в скрипте влияет на 
                //текущую фазу анимации. Если вес равен 1, то рука или нога (т.е., то, что мы изменем)
                //будет находится строго в позиции, заданной в коде. Если 0, то код на анимацию не повлияет.
                //0,5 - интерполяция. Вес помогает потихонечку увеличить силу воздействия. Например, чем
                //ближе мы к цели, тем сильнее к ней тянемся.
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
