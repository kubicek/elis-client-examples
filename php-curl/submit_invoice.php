<!DOCTYPE html>
<html>
<body>

<?php

// private API key:
$API_KEY = 'xxxxxxxxxxxxxxxxxxxxxx_YOUR_ELIS_API_KEY_xxxxxxxxxxxxxxxxxxxxxxx';
$document_path = 'invoice.pdf';

// first we upload the document

// initialise the cURL var
$ch = curl_init();

// get the response from cURL in future
curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
// make a POST request
curl_setopt($ch, CURLOPT_POST, true);
// set the URL
curl_setopt($ch, CURLOPT_URL, 'https://all.rir.rossum.ai/document');

// set the header
$header = array(
    'Accept: application/json',
    'Content-Type: multipart/form-data',
    'Authorization: secret_key '.$API_KEY,
);
curl_setopt($ch, CURLOPT_HTTPHEADER, $header);

// attach the invoice file
$cfile = curl_file_create($document_path);
// for images use:
// $cfile = curl_file_create($document_path, 'image/*');
$data = array('file' => $cfile);
curl_setopt($ch, CURLOPT_POSTFIELDS, $data);

// upload the file
$response = curl_exec($ch);

if (curl_errno($ch)) {
    // something went wrong
    die('Couldn\'t send request: ' . curl_error($ch));
} else {
    // check the HTTP status code of the request
    $resultStatus = curl_getinfo($ch, CURLINFO_HTTP_CODE);
    // close the session
    curl_close($ch);

    if ($resultStatus == 200) {
        // get the file id
        $doc_id = json_decode($response, true)['id'];
        echo 'File uploaded successfully ('.$doc_id.').<br>';
    } else {
        die('Request failed: HTTP status code: ' . $resultStatus);
    }
}


// wait until the file has been processed
$max_attempts = 12;
$secs_per_attempt = 5;
$success = false;
for ($i = 0; $i < $max_attempts; $i++){
    sleep($secs_per_attempt);  // wait some time (at least 1 sec) before each request

    // initialise the cURL var
    $ch = curl_init();

    // get the response from cURL in future
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
    // set the URL
    curl_setopt($ch, CURLOPT_URL, 'https://all.rir.rossum.ai/document/'.$doc_id);
    // set the header
    $header = array(
        'Accept: application/json',
        'Content-Type: multipart/form-data',
        'Authorization: secret_key '.$API_KEY,
    );
    curl_setopt($ch, CURLOPT_HTTPHEADER, $header);

    // make the request
    $response = curl_exec($ch);
    if (curl_errno($ch)) {
        // something went wrong
        die('Couldn\'t send request: ' . curl_error($ch));
    } else {
        // check the HTTP status code of the request
        $resultStatus = curl_getinfo($ch, CURLINFO_HTTP_CODE);
        // close the session
        curl_close($ch);
        if ($resultStatus == 200) {
            // get the info
            $doc_info = json_decode($response, true);
            switch ($doc_info['status']) { // processing, error or ready
                case 'processing':
                    echo 'After '.(($i + 1) * $secs_per_attempt).' seconds, the status was still processing.<br>';
                    break;
                case 'error':
                    echo 'After '.(($i + 1) * $secs_per_attempt).' seconds, the document has been processed with the error:<br>'.$doc_info['message'].'<br><br>';
                    break 2;  // break out of the loop as well
		case 'ready':
                    echo 'After '.(($i + 1) * $secs_per_attempt).' seconds, the document has been processed.<br>';
                    echo 'Check the results here:<br>';
                    echo '<a href="https://rossum.ai/document/'.$doc_id.'?apikey='.$API_KEY.'">Rossum JavaScript API client</a><br>';
                    $success = true;
                    echo '<br><br><pre>';
                    echo json_encode($doc_info, JSON_PRETTY_PRINT);
                    echo '</pre>';
                    break 2;  // break out of the loop as well
            }
        } else {
            die('Request failed: HTTP status code: ' . $resultStatus);
        }
    }
}

if (!$success) {
    echo '<br>The document has not been processed within the time limit.';
}

?>

</body>
</html>
