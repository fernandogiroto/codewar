using UnityEngine;

public class Player_ThrowState : PlayerState
{
    private float stateTimer = 0.5f; // dura a animação

    public Player_ThrowState(Player player, StateMachine stateMachine, string stateName) 
        : base(player, stateMachine, stateName) { }

    public override void Enter()
    {
        base.Enter();
        stateTimer = 0.5f;

        anim.SetTrigger("throw"); // toca a anim
    }

    public override void Update()
    {
        base.Update();

        stateTimer -= Time.deltaTime;

        if (stateTimer <= 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
