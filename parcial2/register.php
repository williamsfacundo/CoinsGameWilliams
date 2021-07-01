<?php  	
	$con = mysqli_connect("localhost","root","root","parcialdos");

//Check that connection happened

	if(mysqli_connect_errno())
	{
		echo "1: Connection Failed"; //error code #1 = Connection failed
		exit();  
	}

//Variables
	$playerName = $_POST["playerName"];	
	$score = $_POST["score"];
	$deaths = $_POST["deaths"];
	

//Check if name exists
	$namecheckquery = "SELECT playerName FROM player WHERE playerName ='" . $playerName . "';";

	$namecheck = mysqli_query($con,$namecheckquery) or die ("2: Name check query failed"); //error cuando falla check

	if(mysqli_num_rows($namecheck)>0)
	{
		echo "3: Name already exist"; //cuando el nombre ya existe 
		exit();
	}

//add user to the table	
	$insertuserquery = "INSERT INTO player (playerName,score,deaths) VALUES ('" .$playerName."','" .$score. "','" .$deaths. "');";
	mysqli_query($con,$insertuserquery) or die("4: Insert player query failed");

	echo ("1");
?>