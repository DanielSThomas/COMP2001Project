<!DOCTYPE html>
<html>
<head>
    <title>LinkedDataSite</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</head>


<body>

<nav class="navbar navbar-inverse">
    <div class="container-fluid">
        <div class="navbar-header">
            <a class="navbar-brand" href="#">Crime in Plymouth</a>
        </div>
        <ul class="nav navbar-nav">
            <li class="active"><a href="#">Home Page</a></li>
            <li><a href="data.php">Readable Data</a></li>
            <li><a href="../crime/index.php">Machine Data</a></li>
        </ul>
    </div>
</nav>


    <div class="jumbotron">
        <div class="container text-center">
        <h1>Crime in Plymouth</h1>
        <p>A linked data project</p>
        </div>
    </div>
<div class="container text-center">
    <div class="row">
        <div class="col-sm-6">
            <h3>Project Vision</h3>
            <p>This site provides a summary of all the offences in plymouth ranging from 2003 to 2015</p>
            <p>The overall data can be accessed in table form and a summary of the total crimes can also be accessed in JSON-LD</p>
        </div>
        <div class="col-sm-6">
            <h3>Data</h3>
            <p>The data is provided from the Plymouth City Council found at: https://plymouth.thedata.place/dataset/crime </p>
            <p>You can also access data on the overall crime in JSON-LD by accessing the "Machine Data" tab.</p>
        </div>
    </div>
</div>

<div class="container text-center">


    <h4>Attributions:</h4>
    <p>Bootstrap 3.4.1</p>
    <p>Jquery 3.5.1</p>
</div>

</body>

</html>