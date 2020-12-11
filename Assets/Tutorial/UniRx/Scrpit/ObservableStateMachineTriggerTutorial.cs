using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class ObservableStateMachineTriggerTutorial : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private ObservableStateMachineTrigger[] observableStateMachineTriggers;
    private void OnEnable()
    {
        this.observableStateMachineTriggers = this.animator.GetBehaviours<ObservableStateMachineTrigger>();
        foreach (var item in this.observableStateMachineTriggers)
        {
            var enterIdle = item.OnStateEnterAsObservable().Where(info => info.StateInfo.IsName("Idle"));
            enterIdle.Subscribe(OnEnterIdle).AddTo(this);
            var exitIdle = item.OnStateExitAsObservable().Where(info => info.StateInfo.IsName("Idle"));
            exitIdle.Subscribe(ExitIdle).AddTo(this);
        }
    }

    private void Reset()
    {
        this.animator = GetComponent<Animator>();
    }

    private void ExitIdle(ObservableStateMachineTrigger.OnStateInfo obj)
    {
        Debug.Log("ExitIdle");
        foreach (var item in this.observableStateMachineTriggers)
        {
            var attackHit = item.OnStateUpdateAsObservable()
                .Where(info => info.StateInfo.IsName("Attack"))
                .SkipWhile(info => info.StateInfo.normalizedTime <= 0.5f)
                .Take(1);
            attackHit.Subscribe(OnAttack);

        }
    }

    private void OnAttack(ObservableStateMachineTrigger.OnStateInfo obj)
    {
        Debug.Log("Attack");
    }

    private void OnEnterIdle(ObservableStateMachineTrigger.OnStateInfo obj)
    {
        Debug.Log("EnterIdle");
    }
}
