# Elis client example in Java & Unirest & Gradle

Build the example app, submit a document and wait for the result processed by Elis API:

```
./gradlew run -PappArgs="['../data/invoice.png', 'https://all.rir.rossum.ai', 'xxxxxxxxxxxxxxxxxxxxxx_YOUR_ELIS_API_KEY_xxxxxxxxxxxxxxxxxxxxxxx']"
```

Check the code:

- `src/main/java/ai/rossum/elis/example/`
  - [SimpleElisClient.java](src/main/java/ai/rossum/elis/example/SimpleElisClient.java)
  - [ElisExampleApp.java](src/main/java/ai/rossum/elis/example/ElisExampleApp.java)


[Unirest library docs](http://unirest.io/java.html).
