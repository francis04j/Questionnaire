const grpc = require('grpc')
const protoLoader = require("@grpc/proto-loader");
const protoFiles = require('google-proto-files');

// lets user be able to type questions
const queston = process.argv[2];

const packageDef = protoLoader.loadSync("qstNairePackage.proto", 
{
    keepCase: true,
    longs: String,
    enums: String,
    defaults: true,
    oneofs: true,
    includeDirs: ['node_modules/google-proto-files', '.']
    },
);
const grpcObject = grpc.loadPackageDefinition(packageDef);
const qstNairePackage = grpcObject.qstNairePackage;

//client connects, server listens

const client = new qstNairePackage.Questionnaire("localhost:40000", grpc.credentials.createInsecure());
// error and response from server
client.createQuestion({"id": -1, "text": queston}, (err, response) => {
    console.log('createQuestion: Received from server: ' + JSON.stringify(response))
});

client.GetQuestions({}, (err,response) => {
    console.log('GetQuestions: Received from server', JSON.stringify(response))
})