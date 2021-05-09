const grpc = require('@grpc/grpc-js')
const protoLoader = require("@grpc/proto-loader");
const protoFiles = require('google-proto-files');
const PROTO_PATH = 'client.proto';

// lets user be able to type questions from command line
const queston = process.argv[2] || 'test';

const packageDefinition = protoLoader.loadSync(PROTO_PATH, 
{
    keepCase: true,
    longs: String,
    enums: String,
    defaults: true,
    oneofs: true,
    includeDirs: [__dirname + protoFiles, '.']
    },
);
const qstNairePackage = grpc.loadPackageDefinition(packageDefinition).qstNairePackage;


const questionService = new qstNairePackage.Questionnaire("localhost:40000", grpc.credentials.createInsecure());

module.exports = questionService;

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

// const call = client.GetQuestionsStream();
// call.on("data", item => {
//     console.log('recived item from server', JSON.stringify(item))
// });


// call.on('end', e => console.log('server done'));