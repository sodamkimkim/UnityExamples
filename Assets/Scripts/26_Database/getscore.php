<?php
// asp, jsp, php

$servername = "localhost:3306";
$username = "root";
$password = "asd123";
$dbname = "db_score";

$conn = new mysqli($servername, $username, $password, $dbname);

if($conn->connect_error){
		die("connection failed: ". $conn->connect_error);
}

$sql = "SELECT * FROM tb_score";
$result = $conn->query($sql);
if($result->num_rows > 0)
{
// parsing편의를 위해 Json form 으로 server data string 받아줌 [ { '키':'value' }, { }, { }, ]
	echo "[";
	while($row = $result->fetch_assoc()) // record 하나 $row에 저장
	{
		echo "{'id': '" . $row['id']."','pw': '" .$row['pw']."', 'score' : '" . $row['score']."'},"; // $row['id'] -> dictionary로 row 내에서 '키'로 매핑 'id', 'score'
	}
	echo "]";
}
$conn->close();
?>