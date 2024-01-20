<?

require_once 'helper.php';

$servername = "localhost";
$username = "root";
$password = "-89hjkpZ!;";
$database = "complexwarning";

$connect = mysqli_connect($servername, $username, $password, $database);

function mysqliQuery($connect, $query, $type) {
    $mysqliQuery = mysqli_query($connect, $query);
    if (is_object($mysqliQuery) && $type === "array") return mysqli_fetch_all($mysqliQuery);
    if (is_object($mysqliQuery) && $type === "object") return $mysqliQuery;
  }