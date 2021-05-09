const express = require('express');
const client = require('./client');

const app = express();
app.use(express.json());
app.use(express.urlencoded({
    extended: true
  }));

app.post('/create', (req,res) => {
   let i, resp;
    for(i= 0; i < 5; i ++)
    {
        client.createQuestion({"id": i, "text": req.body.question}, (err, response) => {
            if(err) throw err;

            console.log('createQuestion: Received from server: ' + JSON.stringify(response));
            resp = response;
        });
    }
    res.status(201).send(JSON.stringify({"message": `created ${i} questions`}));
});

app.get("/", (req, res) => {

client.GetQuestions({}, (err,response) => {
    console.log('GetQuestions: Received from server', JSON.stringify(response));
    res.send(JSON.stringify(response));
        // if(!response.questions)
        //     response.questions.forEach(qs => console.log(qs.text));
})
});

const PORT = process.env.PORT || 3000;
app.listen(PORT, () => {
	console.log("Server running at port %d", PORT);
});