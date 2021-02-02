
<?php

header('Content-Type: application/json');



$rdf = array
(
        '@context'=> array
        (
                'Place'=> 'http://schema.org',
                'Sas'=> 'http://web.socem.plymouth.ac.uk'
        ),

    'crime'=> array
    (
        '0'=> array
        (
            '@type'=> 'crime',
            'Year'=> '2003',
            'Incidents'=> '30273'
        ),
        '1'=> array
        (
            '@type'=> 'crime',
            'Year'=> '2004',
            'Incidents'=> '28060'
        ),
        '2'=> array
        (
            '@type'=> 'crime',
            'Year'=> '2005',
            'Incidents'=> '29451'
        ),
        '3'=> array
        (
            '@type'=> 'crime',
            'Year'=> '2006',
            'Incidents'=> '28705'
        ),
        '4'=> array
        (
            '@type'=> 'crime',
            'Year'=> '2007',
            'Incidents'=> '28209'
        ),
        '5'=> array
        (
            '@type'=> 'crime',
            'Year'=> '2008',
            'Incidents'=> '26037'
        ),
        '6'=> array
        (
            '@type'=> 'crime',
            'Year'=> '2009',
            'Incidents'=> '24037'
        ),
        '7'=> array
        (
            '@type'=> 'crime',
            'Year'=> '2010',
            'Incidents'=> '21515'
        ),
        '8'=> array
        (
            '@type'=> 'crime',
            'Year'=> '2011',
            'Incidents'=> '20539'
        ),
        '9'=> array
        (
            '@type'=> 'crime',
            'Year'=> '2012',
            'Incidents'=> '21127'
        ),
        '10'=> array
        (
            '@type'=> 'crime',
            'Year'=> '2013',
            'Incidents'=> '18713'
        ),
        '11'=> array
        (
            '@type'=> 'crime',
            'Year'=> '2014',
            'Incidents'=> '18980'
        ),
        '12'=> array
        (
            '@type'=> 'crime',
            'Year'=> '2015',
            'Incidents'=> '18763'
        ),



    )


);

echo json_encode($rdf);

?>