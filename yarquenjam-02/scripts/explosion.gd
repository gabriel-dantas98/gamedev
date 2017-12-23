extends Node

func _ready():
	#randomize()
	#set_rot(deg2rad(rand_range(0, 360)))
	#get_node("p_smoke").set_emitting(true)
	#get_node("p_flare").set_emitting(true)
	audio_player.play("hit_enemy")
	get_node("anim").play("fade_out")
	yield(get_node("anim"), "finished")
	queue_free()
	pass
