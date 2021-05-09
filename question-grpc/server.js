const grpc = require('@grpc/grpc-js')
const protoLoader = require("@grpc/proto-loader");
const protoFiles = require('google-proto-files');

const packageDef = protoLoader.loadSync("qstNairePackage.proto", 
{
    keepCase: true,
    longs: String,
    enums: String,
    defaults: true,
    oneofs: true,
    includeDirs: [__dirname + protoFiles, '.']
    },
);
const grpcObject = grpc.loadPackageDefinition(packageDef);

const qstNairePackage = grpcObject.qstNairePackage;

//server listens
const server = new grpc.Server();
       //can listen on any tcp ip and port
server.bindAsync("0.0.0.0:40000", grpc.ServerCredentials.createInsecure(), (error, port) => {
    server.start(); 
    console.log(`Server bind successfully on localhost and port: ${port}`);
    if(error){
        console.log(`Server bind error on port: ${port} with error: ${error}`);
        server.tryShutdown(done);
    }
       
 }); //http2 requires you to secure by default
server.addService(qstNairePackage.Questionnaire.service, { //let your server know about service
    "createQuestion": createQuestion,
    "GetQuestions": GetQuestions,
    "GetQuestion": GetQuestion,
    "GetQuestionsStream": GetQuestionsStream
});
const questions = []
// call: client
// callback: you sending information back
function createQuestion(call, callback) {
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

function GetQuestion(call, callback) {
    const qs = questions.find( x => x.id == call.request.id);
    if(qs) {
        callback(null, qs);
    }else{
        callback(null, {"id": 1, 'question': 'undefinedN'}); //added this because 
    }
}

function GetQuestionsStream(call, callback) {
    questions.forEach(q => call.write(q));
    call.end();
}
