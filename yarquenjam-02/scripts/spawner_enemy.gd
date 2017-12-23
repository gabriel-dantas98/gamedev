extends Node

const enemy_diagonal = preload("res://scenes/enemy_diagonal.tscn")
const enemy_reto = preload("res://scenes/enemy_reto.tscn")
const enemy_olaf = preload("res://scenes/enemy_olaf.tscn")

func _ready():
	yield(utils.create_timer(1.2), "timeout")
	spawn()
	pass
	
func spawn():
	while true:
		randomize()
		
		var enemy_list = [enemy_diagonal, enemy_diagonal, enemy_diagonal, enemy_reto, enemy_reto, enemy_olaf]
		var enemy = enemy_list[rand_range(0, 6)].instance()
		var pos = Vector2()
		pos.x = rand_range(25, utils.view_size.width-25)
		pos.y = -15
		enemy.set_pos(pos)
		get_node("container").add_child(enemy)
		yield(utils.create_timer(rand_range(0, 2)), "timeout")
	pass	
