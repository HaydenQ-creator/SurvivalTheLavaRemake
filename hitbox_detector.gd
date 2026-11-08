extends Area3D


# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	self.area_entered.connect(_on_area_entered)

func _on_area_entered(area):
	print("Hit")
# Called every frame. 'delta' is the elapsed time since the previous frame.
