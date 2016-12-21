(function() {
    var questionaireApp = angular.module('questionaireApp', []);

    questionaireApp.controller('questionaireCtrl',
        function ($scope, $http, $rootScope) {
            $scope.questionaires1 = {};
            $http({
                method: 'GET',
                url: 'http://localhost:49852/Questionnaire/Questionnaires'
            }).then(function successCallback(response) {
                $scope.questionaires1 = response.data;
                $rootScope.title = $scope.questionaires1.QuestionnaireTitle;
                // this callback will be called asynchronously
                // when the response is available
            }, function errorCallback(response) {
                // called asynchronously if an error occurs
                // or server returns response with an error status.
            });
            
            $scope.questionaires = {
                "questions": [
                    {
                        "QuestionnaireTitle": "Geography Questions",
                        "QuestionsText": [
                            "What is the capital of Cuba?",
                            "What is the capital of France?",
                            "What is the capital of Poland?",
                            "What is the capital of Germany?"
                        ]
                    }
                ],
                "answers": [
                    {
                        "QuestionsText": "What is the capital of Cuba?",
                        "AnswersText": [
                            "Havana",
                            "Paris",
                            "Warsaw",
                            "Berlin"
                        ]
                    },
                    {
                        "QuestionsText": "What is the capital of France?",
                        "AnswersText": [
                            "Warsaw",
                            "Havana",
                            "Paris",
                            "Berlin"
                        ]
                    },
                     {
                         "QuestionsText": "What is the capital of Poland?",
                         "AnswersText": [
                             "Berlin",
                             "Havana",
                             "Paris",
                             "Warsaw"
                         ]
                     },
                     {
                         "QuestionsText": "What is the capital of Germany?",
                         "AnswersText": [
                             "Paris",
                             "Havana",
                             "Berlin",
                             "Warsaw"
                         ]
                     }
                ]
            };

            $scope.QAfilter = function (questionText) {
                return ($scope.answers.indexOf(questionText) !== -1);
            };
        });

    
    angular.module('myFilters', []).
      filter('byanswer', function (questionText) {
          return function (question, answers) {
              var out = [];
              // Filter logic here, adding matches to the out var.
              return out;
          }
      });
})();