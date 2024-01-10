using Godot;
using System;

public partial class GUI : Control
{
	private Label ScoreLabel;
	private Button PlayButton;
	private Button ResetButton;

	[Signal]
	public delegate void OnPlayButtonClickedEventHandler();

	[Signal]
	public delegate void OnResetButtonClickedEventHandler();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScoreLabel = GetNode<Label>("ScoreLabel");
		PlayButton = GetNode<Button>("PlayButton");
		ResetButton = GetNode<Button>("ResetButton");
	}

	public void OnClickPlayButton() {
		PlayButton.Visible = false;
		EmitSignal(SignalName.OnPlayButtonClicked);
	}

	public void OnClickResetButton() {
		ResetButton.Visible = false;
		EmitSignal(SignalName.OnResetButtonClicked);
	}

	public void OnPlayerIncrementScore(Player Player)
	{
		ScoreLabel.Text = Player.score.ToString();
	}

	public void Reset() {
		ScoreLabel.Text = "0";
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
