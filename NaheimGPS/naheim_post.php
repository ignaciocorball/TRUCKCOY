<?php
/*
  TRUCKCOY POST PHP SCRIPT
  https://www.github.com/ignaciocorball
  
  The above copyright notice and this permission notice shall be included in all
  copies or substantial portions of the Software.

*/
date_default_timezone_set("America/Santiago");

// Database connection info
$servername = "localhost";
$dbname = "123456789_MIDB";
$username = "123456789_MIUSERNAME";
$password = "123456789";

// This Api key need be the same of device
$api_key_server = "UniversidadDeAysen111";

// Global Variables
$data = @file_get_contents("https://api.ipgeolocationapi.com/geolocate/" . $_SERVER['REMOTE_ADDR']);
$items = json_decode($data, true);
$HTTPUSERAGENT = $_SERVER['HTTP_USER_AGENT'];
$ip_Address = $_SERVER['REMOTE_ADDR'];

$reg_date = date('Y/m/d', time());
$reg_time = date('h:i:s', time());


//Post Method
try{
    if ($_SERVER["REQUEST_METHOD"] == "POST") {
        $api_key = test_input($_POST["api_key"]);
        if($api_key == $api_key_server) {
            $id = null;
            $deviceID = test_input($_POST['deviceID']);
            $patente = test_input($_POST['patente']);
            $company = test_input($_POST['company']);;
            $lat = test_input($_POST["lat"]);
            $lng = test_input($_POST["lng"]);
            $alt = test_input($_POST["alt"]);
            $crs = test_input($_POST["crs"]);
            $spd = test_input($_POST["spd"]);
            $sat = test_input($_POST["sat"]);
            $deviceStatus = 'Online';
            $temperature = null;
            $http_user_agent = $HTTPUSERAGENT;
            $ipaddress = $ip_Address;
            // Create connection
            $conn = new mysqli($servername, $username, $password, $dbname);
            // Check connection
            if ($conn->connect_error) {
                die("Conexión fallida: " . $conn->connect_error);
            } 
            
            $sql = "INSERT INTO naheim_111 (id, device_id, patente, company, latitude, longitude, altitude, course, speed, satellites, temperature, reg_time, reg_date, ip_address ,device_status, user_agent) VALUES ('" . $id . "', '" . $deviceID . "', '" . $patente . "', '" . $company . "', '" . $lat . "','" . $lng . "','" . $alt . "','" . $crs . "','" . $spd . "','" . $sat . "','" . $temperature . "','" . $reg_time . "','" .$reg_date . "','" . $ipaddress . "','" . $deviceStatus . "','" . $http_user_agent . "')";
            
            if ($conn->query($sql) === TRUE) {
                echo "New query generated successfully";
            }
            else{
                echo "SQL Error: " . $sql . "<br>" . $conn->error;
            }
            $conn->close();
        }
        else {
            echo "Oh!, you find the button." . "<br>" .  "Take a cookie 🍪!" . "<br>". "Don't try bad things!";
        }
    }
    else {
        echo $reg_date; echo " "; echo $reg_time;
        echo "<br>";
        echo "Post method has been set up.";
    }
}
catch (Exception $e){
    echo "Query error: " . "<br>" . $e;
}
function test_input($data) {
    $data = trim($data);
    $data = stripslashes($data);
    $data = htmlspecialchars($data);
    return $data;
}

?>


<form action="" method="POST" autocomplete="off">
        <input type="submit" value="submit" formmethod="POST" hidden>
</form>