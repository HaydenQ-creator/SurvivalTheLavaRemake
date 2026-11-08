extends MeshInstance3D

var rise_speed: float = .001
	
func _process(delta):
	position.y += rise_speed * delta
