require 'restclient'
require 'json'

secret_key='xxxxxxxxxxxxxxxxxxxxxx_YOUR_ELIS_API_KEY_xxxxxxxxxxxxxxxxxxxxxxx'
invoice="/path/to/invoice.pdf"
locale="cz_CZ" #en_US
endpoint='https://all.rir.rossum.ai'

auth="secret_key #{secret_key}"

RestClient.log = 'stdout'

response = RestClient.post "#{endpoint}/document",
  {file: File.new(invoice, 'rb'), locale: locale},
  {:Authorization => auth}

if response.code!=200
  puts "Upload failed"
  exit
end

parsed_response=JSON.parse(response.body)
id=parsed_response['id']

puts "Success - ID: #{}"

while parsed_response["status"]=="processing"
  sleep(5)
  response = RestClient.get "#{endpoint}/document/#{id}",
    {:Authorization => auth}
  parsed_response=JSON.parse(response.body)
end

puts parsed_response.to_json
