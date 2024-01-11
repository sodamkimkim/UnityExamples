<?php

$servername = "localhost:3306";
$username = "root";
$password = "asd123";
$dbname = "db_score";

//$id = $_POST["id"];
//$score = $_POST["score"];
$limits = $_POST["limits"];

$conn = new mysqli($servername, $username, $password, $dbname);

if($conn->connect_error){
		die("connection failed: ". $conn->connect_error);
}

if($limits == "all")
{
$sql = "SELECT * FROM tb_score order by score DESC";
}
else{
$sql = "SELECT * FROM tb_score ORDER BY score DESC LIMIT ".$limits;
}
$result = $conn->query($sql);
// echo $sql;

if($result->num_rows > 0)
{
	echo "[";
	while($row = $result->fetch_assoc()) // record 하나 $row에 저장
	{
		 echo "{'id':'" .$row['id']. "','score':'" .$row['score']."'},";

	}
	echo "]";
}
$conn->close();
?>