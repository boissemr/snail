#pragma strict
private var controller: CharacterController;
 var speed: float = 6.0;
 var turnSpeed: float = 90;
 
 function Start(){
 
     controller = GetComponent(CharacterController);
 }
 
 function Update(){
 
     var movDir: Vector3;
 
     transform.Rotate(0,Input.GetAxis("Horizontal")*turnSpeed*Time.deltaTime,0);
     movDir = transform.forward*Input.GetAxis("Vertical")*speed;
     // moves the character in horizontal direction
     controller.Move(movDir*Time.deltaTime-Vector3.up*0.1);    
 }
 