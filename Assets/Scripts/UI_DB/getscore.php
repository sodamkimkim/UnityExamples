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
// parsing���Ǹ� ���� Json form ���� server data string �޾��� [ { 'Ű':'value' }, { }, { }, ]
	echo "[";
	while($row = $result->fetch_assoc()) // record �ϳ� $row�� ����
	{
		echo "{'id': '" . $row['id']."','pw': '" .$row['pw']."', 'score' : '" . $row['score']."'},"; // $row['id'] -> dictionary�� row ������ 'Ű'�� ���� 'id', 'score'
	}
	echo "]";
}
$conn->close();
?>