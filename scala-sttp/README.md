# Elis API client example in Scala & sttp & sbt

Check the code: [ElisClientExampleSttp.scala](scala-sttp/src/main/scala/ai/rossum/elis/example/ElisClientExampleSttp.scala).

Usage:

```
Usage: elis-example [options]

  --filePath <value>   path to document (PDF/PNG)
  --secretKey <value>  secret API key
  --host <value>       API host base URL
```

Build the example app, submit a document and wait for the result processed by Elis API:

```
sbt "run --filePath ../data/invoice.pdf --secretKey xxxxxxxxxxxxxxxxxxxxxx_YOUR_ELIS_API_KEY_xxxxxxxxxxxxxxxxxxxxxxx"
```

Example output:

```
Submitting the invoice...
Waiting for the invoice being processed...
Polling... 2.0 / 60.0 s
Polling... 4.0 / 60.0 s
Polling... 6.0 / 60.0 s
Polling... 8.0 / 60.0 s
Polling... 10.0 / 60.0 s
Polling... 12.0 / 60.0 s
Polling... 14.0 / 60.0 s
Polling... 16.0 / 60.0 s
Polling... 18.0 / 60.0 s
Polling... 20.0 / 60.0 s
Polling... 22.0 / 60.0 s
Polling... 24.0 / 60.0 s
Polling... 26.0 / 60.0 s
Polling... 28.0 / 60.0 s
Polling... 30.0 / 60.0 s
Polling... 32.0 / 60.0 s
Polling... 34.0 / 60.0 s
Polling... 36.0 / 60.0 s
Polling... 38.0 / 60.0 s
Polling... 40.0 / 60.0 s
Polling... 42.0 / 60.0 s
Polling... 44.0 / 60.0 s
Polling... 46.0 / 60.0 s
Processed invoice:
{
  "text_lines":{
    "content":[
      [
        "ÓQrdlner Jheobold Gardiner & Theobald LLP\n",
        "Management Services\n",
        "The G1 Building\n",
        "5 George Square\n",
        "Glasgow G2 1DY\n",
        ". T 4440)141 568 7333\n",
        "r 568 7345\n",
        "e: gtmsglasgowQgardinercom\n",
        "www.gardiner.com\n",
        "Invoice\n",
        "J\n",
        "Date & Tax Point 1st May 2014                                                         ƟƟƟĚ                       |\n",
        "3                             q                          |\n",
        "To                    FÉFE COLLEGE                     \u201eFife COIEČC: : .\n",
        "7 Pittsburgh Road                                                         ř   \u2013Ú             ,|\n",
        "Dunfermline 1 & May 101t          I .\n",
        "4 KY11 8DY                                                                                                                    !\n",
        "F.A.O. Mr Davie Neilson                                                                      |\n",
        "RECEIVED s                          |\n",
        "\"                            |\n",
        "Invoice No MSG/5946 !\n",
        "Job Ref 88/31035/05                                                                                     Ě\n",
        "VAT Reg. No. 832 7762 12                                                                                           š\n",
        " .\n",
        "FIFE COLLEGE E            ;\n",
        "To:                                                                                                                                                                              z\n",
        "Provision of Project Management Services                                                                                       4\n",
        "relative to Estates Strategy Planning & Business Case 25,474.00                  :\n",
        "ž\n",
        ". Sub Total Exclusive of VAT 25,474.00                     ==\n",
        "]\n",
        "Value Added Tax Q 20% 5,094.80 /\n",
        "TOTAL AMOUNT DUE                L&M\u2026 E30,568.80            j\n",
        "3                                                                                                              j\n",
        "DI               |\n",
        ".\n",
        "j\n",
        "D                  |\n",
        "MXRWRŽLMƟZSG                                                                                                                                            :\n",
        "i\n",
        "i\n",
        ". Cheques to be made payable to Gardiner Theobald LLP alternatively payment may be made directly to our bank account:                         :\n",
        "HSBC Bank PLC Sort Code 40-02-02  Account No. 00375152                                                                  ]\n",
        "Gardiner & Theobald LLP s a iniedliablity partnerahip (Regulated by RICS) which is England and Wales with regitered No. 0C307124                                   |L\n",
        "A liet of membars' names j avalable for inspaction at 10 South Crescenl, London WC1E 78D,the frm'sprincipal place of business and registred office                               |\n",
        "                                                                                              ýl\n\n"
      ]
    ],
    "name":"text_lines",
    "title":"Rough Content"
  },
  "preview":"https://all.rir.rossum.ai/img/1b802c5898009911dd65ecfe_0.png",
  "language":"eng",
  "status":"ready",
  "fields":[
    {
      "name":"account_num",
      "value_type":"text",
      "bbox":[
        745,
        1626,
        833,
        1644
      ],
      "page":0,
      "score":0.957390591633303,
      "checks":{

      },
      "content":"00375152",
      "title":"Bank Account",
      "value":"00375152"
    },
    {
      "name":"bank_num",
      "value_type":"text",
      "bbox":[
        571,
        1620,
        645,
        1644
      ],
      "page":0,
      "score":0.9703049020571556,
      "checks":{

      },
      "content":"40-02-02",
      "title":"Sort Code",
      "value":"40-02-02"
    },
    {
      "name":"amount_total_base",
      "value_type":"number",
      "bbox":[
        953,
        1122,
        1077,
        1158
      ],
      "page":0,
      "score":0.8983528999867364,
      "checks":{

      },
      "content":"25,474.00",
      "title":"Tax Base Total",
      "value":"25474.00"
    },
    {
      "name":"amount_total_tax",
      "value_type":"number",
      "bbox":[
        968,
        1170,
        1078,
        1206
      ],
      "page":0,
      "score":0.9294690197146265,
      "checks":{
        "amount_equations":"good"
      },
      "content":"5,094.80",
      "title":"Tax Total",
      "value":"5094.80"
    },
    {
      "name":"amount_total_tax",
      "value_type":"number",
      "bbox":[
        954,
        1128,
        1078,
        1158
      ],
      "page":0,
      "score":0.7885435252091348,
      "checks":{
        "amount_equations":"bad"
      },
      "content":"25,474.00",
      "title":"Tax Total",
      "value":"25474.00"
    },
    {
      "name":"amount_total",
      "value_type":"number",
      "bbox":[
        959,
        1236,
        1075,
        1278
      ],
      "page":0,
      "score":0.9425718537569309,
      "checks":{
        "amount_equations":"good"
      },
      "content":"30,568.80",
      "title":"Total Amount",
      "value":"30568.80"
    },
    {
      "name":"amount_due",
      "value_type":"number",
      "bbox":[
        962,
        1236,
        1076,
        1278
      ],
      "page":0,
      "score":0.9693305559666132,
      "checks":{
        "amount_equations":"good"
      },
      "content":"30,568.80",
      "title":"Amount Due",
      "value":"30568.80"
    },
    {
      "name":"amount_due",
      "value_type":"number",
      "bbox":[
        965,
        1170,
        1079,
        1206
      ],
      "page":0,
      "score":0.8528612735351506,
      "checks":{
        "amount_equations":"bad"
      },
      "content":"5,094.80",
      "title":"Amount Due",
      "value":"5094.80"
    },
    {
      "name":"date_issue",
      "value_type":"date",
      "bbox":[
        406,
        486,
        562,
        516
      ],
      "page":0,
      "score":0.9253548980242836,
      "checks":{

      },
      "content":"1st May 2014",
      "title":"Issue Date",
      "value":"2014-05-01"
    },
    {
      "name":"date_uzp",
      "value_type":"date",
      "bbox":[
        405,
        498,
        561,
        516
      ],
      "page":0,
      "score":0.7686480680711036,
      "checks":{

      },
      "content":"1St May 2014",
      "title":"Tax Point Date",
      "value":"2014-05-01"
    },
    {
      "name":"date_due",
      "value_type":"date",
      "bbox":[
        405,
        486,
        561,
        516
      ],
      "page":0,
      "score":0.8929166075893362,
      "checks":{

      },
      "content":"1st May 2014",
      "title":"Date Due",
      "value":"2014-05-01"
    },
    {
      "name":"invoice_id",
      "value_type":"text",
      "bbox":[
        402,
        750,
        538,
        780
      ],
      "page":0,
      "score":0.8109326838759122,
      "checks":{

      },
      "content":"MSG/5946",
      "title":"Invoice Identifier",
      "value":"MSG/5946"
    },
    {
      "name":"sender_dic",
      "value_type":"text",
      "bbox":[
        401,
        846,
        551,
        876
      ],
      "page":0,
      "score":0.899231131723511,
      "checks":{

      },
      "content":"832 7762 12",
      "title":"Supplier VAT Number",
      "value":"832776212"
    },
    {
      "name":"sender_name",
      "value_type":"text",
      "bbox":[
        850,
        168,
        1068,
        198
      ],
      "page":0,
      "score":0.8598526967119424,
      "checks":{

      },
      "content":"Gardiner & Theobald LLP",
      "title":"Supplier Name",
      "value":"Gardiner & Theobald LLP"
    },
    {
      "name":"sender_name",
      "value_type":"text",
      "bbox":[
        848,
        192,
        1040,
        216
      ],
      "page":0,
      "score":0.8115931665953814,
      "checks":{

      },
      "content":"Management Services",
      "title":"Supplier Name",
      "value":"Management Services"
    },
    {
      "name":"sender_addrline",
      "value_type":"text",
      "bbox":[
        849,
        252,
        995,
        276
      ],
      "page":0,
      "score":0.915607217191693,
      "checks":{

      },
      "content":"Glasgow G2 1DY",
      "title":"Supplier Address",
      "value":"Glasgow G2 1DY"
    },
    {
      "name":"sender_addrline",
      "value_type":"text",
      "bbox":[
        847,
        234,
        993,
        258
      ],
      "page":0,
      "score":0.9012883570935182,
      "checks":{

      },
      "content":"5 George Square",
      "title":"Supplier Address",
      "value":"5 George Square"
    },
    {
      "name":"sender_addrline",
      "value_type":"text",
      "bbox":[
        849,
        210,
        985,
        240
      ],
      "page":0,
      "score":0.9138018679051039,
      "checks":{

      },
      "content":"The G1 Building",
      "title":"Supplier Address",
      "value":"The G1 Building"
    },
    {
      "name":"sender_addrline",
      "value_type":"text",
      "bbox":[
        847,
        192,
        1043,
        216
      ],
      "page":0,
      "score":0.7961360167425722,
      "checks":{

      },
      "content":"Management Services",
      "title":"Supplier Address",
      "value":"Management Services"
    },
    {
      "name":"recipient_name",
      "value_type":"text",
      "bbox":[
        405,
        528,
        585,
        564
      ],
      "page":0,
      "score":0.9300391324295865,
      "checks":{

      },
      "content":"FIFE COLLEGE",
      "title":"Recipient Name",
      "value":"FIFE COLLEGE"
    },
    {
      "name":"recipient_name",
      "value_type":"text",
      "bbox":[
        -282,
        1020,
        570,
        1050
      ],
      "page":0,
      "score":0.7615426582066985,
      "checks":{

      },
      "content":"Provision of Project Management Services",
      "title":"Recipient Name",
      "value":"Provision of Project Management Services"
    },
    {
      "name":"recipient_name",
      "value_type":"text",
      "bbox":[
        240,
        1044,
        570,
        1080
      ],
      "page":0,
      "score":0.762418990561947,
      "checks":{

      },
      "content":"Estates Strategy Planning & Busi",
      "title":"Recipient Name",
      "value":"Estates Strategy Planning & Busi"
    },
    {
      "name":"recipient_addrline",
      "value_type":"text",
      "bbox":[
        404,
        558,
        586,
        594
      ],
      "page":0,
      "score":0.9549529936833119,
      "checks":{

      },
      "content":"Pittsburgh Road",
      "title":"Recipient Address",
      "value":"Pittsburgh Road"
    },
    {
      "name":"recipient_addrline",
      "value_type":"text",
      "bbox":[
        406,
        588,
        546,
        624
      ],
      "page":0,
      "score":0.8954835443058989,
      "checks":{

      },
      "content":"Dunfermline",
      "title":"Recipient Address",
      "value":"Dunfermline"
    },
    {
      "name":"recipient_addrline",
      "value_type":"text",
      "bbox":[
        402,
        618,
        532,
        654
      ],
      "page":0,
      "score":0.9039893288574521,
      "checks":{

      },
      "content":"KY11 8DY",
      "title":"Recipient Address",
      "value":"KY11 8DY"
    },
    {
      "name":"tax_details",
      "bbox":[
        406,
        1170,
        438,
        1200
      ],
      "page":0,
      "score":0.8731676478204003,
      "content":[
        {
          "name":"tax_detail_rate",
          "value_type":"number",
          "bbox":[
            406,
            1170,
            438,
            1200
          ],
          "page":0,
          "score":0.9148564406702246,
          "checks":{

          },
          "content":"20",
          "title":"Tax Rate",
          "value":"20"
        },
        {
          "name":"tax_detail_tax",
          "value_type":"number",
          "bbox":[
            967,
            1170,
            1077,
            1206
          ],
          "page":0,
          "score":0.8731676478204003,
          "checks":{
            "amount_equations":"good"
          },
          "content":"5,094.80",
          "title":"Tax Amount",
          "value":"5094.80"
        }
      ],
      "title":"Tax Details"
    }
  ],
  "currency":"gbp",
  "previews":[
    "https://all.rir.rossum.ai/img/1b802c5898009911dd65ecfe_0.png"
  ],
  "full_text":{
    "content":[
      "ÓQrdlner Jheobold Gardiner & Theobald LLP\n",
      "Management Services\n",
      "The G1 Building\n",
      "5 George Square\n",
      "Glasgow G2 1DY\n",
      ". T 4440)141 568 7333\n",
      "r 568 7345\n",
      "e: gtmsglasgowQgardinercom\n",
      "www.gardiner.com\n",
      "Invoice\n",
      "J\n",
      "Date & Tax Point 1st May 2014                                                         ƟƟƟĚ                       |\n",
      "3                             q                          |\n",
      "To                    FÉFE COLLEGE                     \u201eFife COIEČC: : .\n",
      "7 Pittsburgh Road                                                         ř   \u2013Ú             ,|\n",
      "Dunfermline 1 & May 101t          I .\n",
      "4 KY11 8DY                                                                                                                    !\n",
      "F.A.O. Mr Davie Neilson                                                                      |\n",
      "RECEIVED s                          |\n",
      "\"                            |\n",
      "Invoice No MSG/5946 !\n",
      "Job Ref 88/31035/05                                                                                     Ě\n",
      "VAT Reg. No. 832 7762 12                                                                                           š\n",
      " .\n",
      "FIFE COLLEGE E            ;\n",
      "To:                                                                                                                                                                              z\n",
      "Provision of Project Management Services                                                                                       4\n",
      "relative to Estates Strategy Planning & Business Case 25,474.00                  :\n",
      "ž\n",
      ". Sub Total Exclusive of VAT 25,474.00                     ==\n",
      "]\n",
      "Value Added Tax Q 20% 5,094.80 /\n",
      "TOTAL AMOUNT DUE                L&M\u2026 E30,568.80            j\n",
      "3                                                                                                              j\n",
      "DI               |\n",
      ".\n",
      "j\n",
      "D                  |\n",
      "MXRWRŽLMƟZSG                                                                                                                                            :\n",
      "i\n",
      "i\n",
      ". Cheques to be made payable to Gardiner Theobald LLP alternatively payment may be made directly to our bank account:                         :\n",
      "HSBC Bank PLC Sort Code 40-02-02  Account No. 00375152                                                                  ]\n",
      "Gardiner & Theobald LLP s a iniedliablity partnerahip (Regulated by RICS) which is England and Wales with regitered No. 0C307124                                   |L\n",
      "A liet of membars' names j avalable for inspaction at 10 South Crescenl, London WC1E 78D,the frm'sprincipal place of business and registred office                               |\n",
      "                                                                                              ýl\n\n"
    ],
    "name":"full_text",
    "title":"Rough Content"
  },
  "original_pages":[
    "https://all.rir.rossum.ai/img/o_1b802c5898009911dd65ecfe_0.png"
  ]
}
[success] Total time: 61 s, completed 11.7.2018 15:45:08
```
