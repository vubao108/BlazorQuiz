﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorVNPTQuiz.Models
***REMOVED***
    public class QuestionUserExam
    ***REMOVED***
        public int UserExamId ***REMOVED*** get; set; ***REMOVED***
        public int ExamID ***REMOVED*** get; set; ***REMOVED***

        public int UserId ***REMOVED*** get; set; ***REMOVED***
        
        public int TryNum ***REMOVED*** get; set; ***REMOVED***
        public int RemainSeCond ***REMOVED*** get; set; ***REMOVED***


        public List<QuestionDAO> Questions ***REMOVED*** get; set; ***REMOVED***


        public bool IsContainQuestion(QuestionDAO questionDAO)
        ***REMOVED***
            if (Questions == null || Questions.Count() == 0)
                return false;
            else
                return Questions.Any(question => question.QuestionId == questionDAO.QuestionId);
    ***REMOVED***

        public void AddQuestion(QuestionDAO questionDAO)
        ***REMOVED***
            this.Questions.Add(questionDAO);
    ***REMOVED***

        public QuestionDAO GetQuestion(int question_id)
        ***REMOVED***
            return this.Questions.FirstOrDefault(item => item.QuestionId == question_id);
    ***REMOVED***
***REMOVED***


    public class QuestionDAO
    ***REMOVED***
        public int ExamQuestionId ***REMOVED*** get; set; ***REMOVED***
        public int QuestionId ***REMOVED*** get; set; ***REMOVED***
        public string QuestionText ***REMOVED*** get; set; ***REMOVED***
        public List<AnswerDAO> Answers ***REMOVED*** get; set; ***REMOVED***
        public int UserAnswerId ***REMOVED*** get; set; ***REMOVED***

        public void AddAnswer(AnswerDAO answerDAO)
        ***REMOVED***
            if (Answers == null)
                Answers = new List<AnswerDAO>();
            Answers.Add(answerDAO);
    ***REMOVED***


***REMOVED***

    public class AnswerDAO
    ***REMOVED***
        public int AnswerId ***REMOVED*** get; set; ***REMOVED***
        public String AnswerText ***REMOVED*** get; set; ***REMOVED***
        public bool IsCorrect ***REMOVED*** get; set; ***REMOVED***
***REMOVED***
***REMOVED***
