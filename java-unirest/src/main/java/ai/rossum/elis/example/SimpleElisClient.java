package ai.rossum.elis.example;

import com.mashape.unirest.http.JsonNode;
import com.mashape.unirest.http.Unirest;
import com.mashape.unirest.http.exceptions.UnirestException;

import java.io.File;
import java.nio.file.Paths;

@SuppressWarnings("WeakerAccess")
class SimpleElisClient {
    private String host;
    private String secretKey;

    public SimpleElisClient(String host, String secretKey) {
        this.host = host;
        this.secretKey = secretKey;
    }

    public void submitInvoiceAndWaitForResult(String filePath, SimpleElisClient client) throws UnirestException {
        JsonNode result = client.submitDocument(filePath);
        System.out.println("Submit result: " + result);
        if (result.getObject().getString("status").equals("processing")) {
            String documentId = result.getObject().getString("id");
            System.out.println("Document id: " + documentId);
            result = client.getDocumentWithPolling(documentId, 30, 5000);
            System.out.println("Document successfully processed:");
            System.out.println(result);
        } else {
            throw new IllegalArgumentException("Could not submit invoice: " + result);
        }
    }

    public JsonNode submitDocument(String filePath) throws UnirestException {
        System.out.println("Submitting document: " + filePath);
        String contentType = Paths.get(filePath).getFileName().toString().endsWith(".png")
            ? "image/png" : "application/pdf";
        System.out.println("Content type: " + contentType);
        return Unirest.post(host + "/document")
            .header("Authorization", "secret_key " + secretKey)
            .field("file", new File(filePath), contentType)
            .asJson().getBody();
    }

    public JsonNode getDocument(String documentId) throws UnirestException {
        return Unirest.get(host + "/document/" + documentId)
            .header("Authorization", "secret_key " + secretKey)
            .asJson().getBody();
    }

    public JsonNode getDocumentWithPolling(String documentId, int maxRetries, int sleepMillis) throws UnirestException {
        for (int i = 0; i < maxRetries; i++) {
            System.out.println("Waiting... " + (i * sleepMillis * 1e-3) + " s / " + (maxRetries * sleepMillis * 1e-3) + " s");
            JsonNode result = getDocument(documentId);
            String status = result.getObject().getString("status");
            switch (status) {
                case "ready":
                    return result;
                case "error":
                    System.out.println("Result: " + result);
                    throw new IllegalArgumentException("Could not process document: " + result.getObject().getString("message"));
                default:
                    if (i == 0) {
                        System.out.println("Result: " + result);
                    }
                    try {
                        Thread.sleep(sleepMillis);
                    } catch (InterruptedException e) {
                        throw new RuntimeException(e);
                    }
                    break;
            }
        }
        throw new RuntimeException("Time out after " + maxRetries + " attempts");
    }
}
