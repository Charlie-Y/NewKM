#pragma strict

function Start () {

}

function Update () {

}

function OnMouseDown() {
//	Debug.Log("OnMouseDown");
	
	var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
	var hit : RaycastHit;

    if (Physics.Raycast(ray, hit)){
        var newTarget : Vector3 = hit.point;
        Debug.Log(newTarget);
    }
}	