using Godot;
using System;

public partial class MainTest : Node2D
{
	private Vector2		lastMousePos;
	private Vector2 	startPos;
	private Vector2 	endPos;
	private float		t = 0.0f;
	
	[Export]
	private float		walkingSpeed = 10.0f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		lastMousePos = Position;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("ui_left_click")) {
			lastMousePos = GetViewport().GetMousePosition();
			startPos = Position;
			endPos = lastMousePos;
			t = 0.0f;
		}

		if (t <= 1 && (endPos - startPos).Length() > 0) {
			t += (float)delta * walkingSpeed / (endPos - startPos).Length();
			Position = startPos + (endPos - startPos) * t;
		}
	}
}
