var fs = require('fs');
const request = require('request');

const API_KEY = 'xxxxxxxxxxxxxxxxxxxxxx_YOUR_ELIS_API_KEY_xxxxxxxxxxxxxxxxxxxxxxx';
const DOC_PATH = 'invoice.pdf';
const URL = 'https://all.rir.rossum.ai/document';

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
        contentType: 'multipart/form-data',  // for images use: 'image/*'
      }
    },
  },
},

(err, res, body) => {
  if (err) { return console.log(err); }
  console.log(body);
});
