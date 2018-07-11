var fs = require('fs');
const request = require('request');

const API_KEY = 'xxxxxxxxxxxxxxxxxxxxxx_YOUR_ELIS_API_KEY_xxxxxxxxxxxxxxxxxxxxxxx';
const DOC_PATH = '../data/invoice.pdf';
const URL = 'https://all.rir.rossum.ai/document';

var contentType = DOC_PATH.toLowerCase().endsWith('.png') ? 'image/pdf' : 'application/pdf'

request.post({
  url: URL,
  method: 'POST',
  headers: {
    'Authorization': 'secret_key ' + API_KEY,
  },
  formData: {
    file: {
      value: fs.createReadStream(DOC_PATH),
      options: {
        contentType: contentType
      }
    },
  },
},

(err, res, body) => {
  if (err) { return console.log(err); }
  console.log(body);
});
