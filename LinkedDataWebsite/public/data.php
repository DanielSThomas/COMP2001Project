<!DOCTYPE html>
<html>
<head>
    <title>ReadableData</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</head>

<style>
    table, td
    {
        border: 1px solid black;
        border-collapse: collapse;
        padding: 5px;
    }
</style>
<body>

<nav class="navbar navbar-inverse">
    <div class="container-fluid">
        <div class="navbar-header">
            <a class="navbar-brand" href="index.php">Crime in Plymouth</a>
        </div>
        <ul class="nav navbar-nav">
            <li><a href="index.php">Home Page</a></li>
            <li class="active"><a href="data.php">Readable Data</a></li>
            <li><a href="../crime/index.php">Machine Data</a></li>
        </ul>
    </div>
</nav>

<div class="jumbotron">
    <div class="container text-center">
        <h1>Readable Data</h1>
    </div>
</div>


<div class="container text-center">
<h1>Summary of offences in plymouth from 2003-2015</h1>
<div class="container text-center">
    <?php print <<< HERE
  <table style="width:100%">
HERE;
    $data = file("../crime/resources_summary-of-all-offences-2003-2015.csv");
    foreach ($data as $line){
        $lineArray = explode(",", $line);
        list($Offence, $Year2003, $Year2004, $Year2005, $Year2006, $Year2007, $Year2008, $Year2009, $Year2010, $Year2011, $Year2012, $Year2013, $Year2014, $Year2015) = $lineArray;
        print <<< HERE
   <tr>
   <td>$Offence</td>
   <td>$Year2003</td>
   <td>$Year2004</td>
   <td>$Year2005</td>
   <td>$Year2006</td>
   <td>$Year2007</td>
   <td>$Year2008</td>
   <td>$Year2009</td>
   <td>$Year2010</td>
   <td>$Year2011</td>
   <td>$Year2012</td>
   <td>$Year2013</td>
   <td>$Year2014</td>
   <td>$Year2015</td>
   </tr>
HERE;
    }
    print "</table>"; ?>
</div>

</div>


</body>
</html>

