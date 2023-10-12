public class EnemyStateMachine : StateMachine<EnemyStateMachineData>
{
	private void Start()
	{
		SwitchState(Data.WalkState);
	}
}