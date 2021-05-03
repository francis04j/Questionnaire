const grpc = require('grpc')
const protoLoader = require("@grpc/proto-loader");
const protoFiles = require('google-proto-files');

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

//server listens
const server = new grpc.Server();
       //can listen on any tcp ip and port
server.bind("0.0.0.0:40000", grpc.ServerCredentials.createInsecure()) //http2 requires you to secure by default
server.addService(qstNairePackage.Questionnaire.service, { //let your server know about service
    "createQuestion": createQuestion,
    "GetQuestions": GetQuestions
});
const questions = []
// call: client
// callback: you sending information back
function createQuestion(call, callback) {
    // console.log(call);
    const qs = {
        "id": questions.length + 1,
        "text": call.request.text
    };
    questions.push(qs);
    //null - how buig is your payload
    callback(null, qs); //send back the new created object
}

// stream questions to client
function GetQuestions(call, callback) { 
   // callback(null, {"items": questions}); //old code: where schema have to be exacy match
   callback(null, {"questions": questions}); 
}

server.start();