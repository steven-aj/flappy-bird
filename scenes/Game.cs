using Godot;
using System;

public partial class Game : Node2D
{
	private Player Player;
	private CanvasLayer GUI;
	private RichTextLabel ScoreUI;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Player = GetNode<Player>("Player");
		GUI = GetNode<CanvasLayer>("GUI");
		ScoreUI = GUI.GetNode<RichTextLabel>("ScoreUI");
	}

	public void OnPlayerIncrementScore(Player Player)
	{
        ScoreUI.Text = Player.score.ToString();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
