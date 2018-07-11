package ai.rossum.elis.example;

import com.mashape.unirest.http.exceptions.UnirestException;

public class ElisExampleApp {
    public static void main(String args[]) throws UnirestException {
        if (args.length != 3) {
            System.err.println("Arguments: DOCUMENT_PATH ELIS_API_HOST SECRET_KEY");
            System.exit(-1);
        }
        String filePath = args[0];
        String host = args[1];
        String secretKey = args[2];
        SimpleElisClient client = new SimpleElisClient(host, secretKey);
        client.submitInvoiceAndWaitForResult(filePath, client);
    }
}
