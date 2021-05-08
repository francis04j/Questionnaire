const grpc = require('grpc')
const protoLoader = require("@grpc/proto-loader");
const protoFiles = require('google-proto-files');

// lets user be able to type questions
const queston = process.argv[2] || 'test';

const packageDef = protoLoader.loadSync("client.proto", 
{
    keepCase: true,
    longs: String,
    enums: String,
    defaults: true,
    oneofs: true,
    includeDirs: [__dirname + 'node_modules/google-proto-files', '.']
    },
);
const grpcObject = grpc.loadPackageDefinition(packageDef);

const qstNairePackage = grpcObject.qstNairePackage;

//client connects, server listens

const client = new qstNairePackage.Questionnaire("localhost:40000", grpc.credentials.createInsecure());

// let i;
// for(i= 0; i < 5; i ++)
// {
//     client.createQuestion({"id": i, "text": queston}, (err, response) => {
//         console.log('createQuestion: Received from server: ' + JSON.stringify(response))
//     });
// }


// client.GetQuestions({}, (err,response) => {
//     console.log('GetQuestions: Received from server', JSON.stringify(response))
//     if(!response.questions)
//             response.questions.forEach(qs => console.log(qs.text));
// })

// client.GetQuestion({"id": 5}, (err,response) => {
//     console.log('GetQuestion: Received from server', JSON.stringify(response))
// });

const call = client.GetQuestionsStream();
call.on("data", item => {
    console.log('recived item from server', JSON.stringify(item))
});


call.on('end', e => console.log('server done'));