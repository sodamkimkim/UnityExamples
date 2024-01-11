<?php
// asp, jsp, php

$servername = "localhost:3306";// $ : 변수 선언. :db포트
$username = "root";
$password = "asd123";
$dbname = "db_score";

$id = $_POST["id"]; // "id" 키로 WWWForm에서 던진 "id"키랑 맵핑 해서 해당 키의 value 저장
$pw = $_POST["pw"];
$score = $_POST["score"];

$conn = new mysqli($servername, $username, $password, $dbname); // db connect 변수 conn.

if($conn->connect_error){
		die("connection failed: ". $conn->connect_error);
}

$sql = "SELECT * FROM tb_score WHERE id = '" . $id."'";
// 접속이 된 객체에 쿼리 던짐
$result = $conn->query($sql); // db 연결객체 쿼리 초기화 - select 결과 result에 받아줌
	
// echo .$sql;
if($result->num_rows > 0){
	$update_sql = "UPDATE tb_score SET score = '".
				$score . "', pw = " . $pw .  " WHERE id = '" . $id . "'";
	$conn->query($update_sql); // db 연결객체 쿼리 초기화
 echo $update_sql;
}
else{  // 아이디 없으면 추가해 줌
	$insert_sql = "INSERT INTO tb_score(id, pw, score)
	VALUES('" . $id . "','" . $pw . "', '".$score."')";
	$conn->query($insert_sql); // db 연결객체 쿼리 초기화
 echo $insert_sql;
}
//echo $score;
echo ", ".$result->num_rows;
$conn->close();
?>