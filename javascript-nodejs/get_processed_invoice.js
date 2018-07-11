const request = require('request');

const API_KEY = 'xxxxxxxxxxxxxxxxxxxxxx_YOUR_ELIS_API_KEY_xxxxxxxxxxxxxxxxxxxxxxx';
// set the document id manually here
const DOC_ID = 'db0c90a43689e2ee673e42fe'; // <---
const BASE_URL = 'https://all.rir.rossum.ai/document/';
const MAX_ATTS = 12;
const WAIT = 5;  // how many seconds to wait between attempts

var task_is_running = false;
var n_atts = 0;

function setIntervalImmediately(func, interval) {
  func();
  return setInterval(func, interval);
}

var refreshId = setIntervalImmediately(function(){
    if(!task_is_running){
        task_is_running = true;

        request.get({
          url: BASE_URL + DOC_ID,
          method: 'GET',
          headers: {
            'Authorization': 'secret_key ' + API_KEY,
          },
        },

        (err, res, body) => {
          if (err) { return console.log(err); }
          data = JSON.parse(body)
          if (data.status == 'ready') {
            console.log('Document is ready:');
            console.log();
            console.log(data);
            console.log();
            console.log('https://rossum.ai/document/' + DOC_ID + '?apikey=' + API_KEY);
            clearInterval(refreshId);
          } else if (data.status == 'error') {
            console.log('There has been an error:');
            console.log(data.message);
            clearInterval(refreshId);
          } else if (n_atts < MAX_ATTS) {
            console.log((WAIT * n_atts).toString() + 's: status "processing", retrying.')
            n_atts++;
          } else {
            console.log('Timed out.');
            clearInterval(refreshId);
          }
        });

        task_is_running = false;
    }
}, WAIT * 1000);
