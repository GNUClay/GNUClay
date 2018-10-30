using MyNPCLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TmpSandBox.VarOfSentences
{
    public class SentencesGenerator
    {
        public List<TstSentence> Run()
        {
            LogInstance.Log("Begin");

            var result = new List<TstSentence>();

            result.AddRange(DefineIndefiniteActive());
            result.AddRange(DefineContinuousActive());
            result.AddRange(DefinePerfectActive());
            result.AddRange(DefinePerfectContinuousActive());

            result.AddRange(DefineIndefinitePassive());
            result.AddRange(DefineContinuousPassive());
            result.AddRange(DefinePerfectPassive());
            result.AddRange(DefineModal());
            result.AddRange(DefineImperative());
            LogInstance.Log("End");

            return result;
        }

        public List<TstSentence> DefineIndefiniteActive()
        {
            var sentence = new TstSentence();
            sentence.WordsList.Add(TstItemOfSentence.CreateSubject());

            sentence.WordsList.Add(TstItemOfSentence.CreateVerb());

            var dbgStr = sentence.ToDisplayStr();
            LogInstance.Log($"dbgStr = {dbgStr}");

            return ProcessMainSentence(sentence);
        }

        private List<TstSentence> DefineContinuousActive()
        {
            var sentence = new TstSentence();
            sentence.WordsList.Add(TstItemOfSentence.CreateSubject());

            sentence.WordsList.Add(TstItemOfSentence.CreateFToBe());

            sentence.WordsList.Add(TstItemOfSentence.CreateVIng());

            var dbgStr = sentence.ToDisplayStr();
            LogInstance.Log($"dbgStr = {dbgStr}");

            return ProcessMainSentence(sentence);
        }

        private List<TstSentence> DefinePerfectActive()
        {
            var sentence = new TstSentence();
            sentence.WordsList.Add(TstItemOfSentence.CreateSubject());

            sentence.WordsList.Add(TstItemOfSentence.CreateFToHave());

            sentence.WordsList.Add(TstItemOfSentence.CreateV3());

            var dbgStr = sentence.ToDisplayStr();
            LogInstance.Log($"dbgStr = {dbgStr}");

            return ProcessMainSentence(sentence);
        }

        private List<TstSentence> DefinePerfectContinuousActive()
        {
            var sentence = new TstSentence();
            sentence.WordsList.Add(TstItemOfSentence.CreateSubject());

            sentence.WordsList.Add(TstItemOfSentence.CreateFToHave());

            sentence.WordsList.Add(TstItemOfSentence.CreateBeen());

            sentence.WordsList.Add(TstItemOfSentence.CreateVIng());

            var dbgStr = sentence.ToDisplayStr();
            LogInstance.Log($"dbgStr = {dbgStr}");

            return ProcessMainSentence(sentence);
        }

        private List<TstSentence> DefineIndefinitePassive()
        {
            var sentence = new TstSentence();
            sentence.WordsList.Add(TstItemOfSentence.CreateSubject());

            sentence.WordsList.Add(TstItemOfSentence.CreateFToBe());

            sentence.WordsList.Add(TstItemOfSentence.CreateV3());

            var dbgStr = sentence.ToDisplayStr();
            LogInstance.Log($"dbgStr = {dbgStr}");

            return ProcessMainSentence(sentence);
        }

        private List<TstSentence> DefineContinuousPassive()
        {
            var sentence = new TstSentence();
            sentence.WordsList.Add(TstItemOfSentence.CreateSubject());

            sentence.WordsList.Add(TstItemOfSentence.CreateFToBe());
            sentence.WordsList.Add(TstItemOfSentence.CreateBeing());
            sentence.WordsList.Add(TstItemOfSentence.CreateV3());

            var dbgStr = sentence.ToDisplayStr();
            LogInstance.Log($"dbgStr = {dbgStr}");

            return ProcessMainSentence(sentence, false);
        }

        private List<TstSentence> DefinePerfectPassive()
        {
            var sentence = new TstSentence();
            sentence.WordsList.Add(TstItemOfSentence.CreateSubject());

            sentence.WordsList.Add(TstItemOfSentence.CreateFToHave());

            sentence.WordsList.Add(TstItemOfSentence.CreateBeen());

            sentence.WordsList.Add(TstItemOfSentence.CreateV3());

            var dbgStr = sentence.ToDisplayStr();
            LogInstance.Log($"dbgStr = {dbgStr}");

            return ProcessMainSentence(sentence);
        }

        private List<TstSentence> DefineModal()
        {
            var sentence = new TstSentence();
            sentence.WordsList.Add(TstItemOfSentence.CreateSubject());

            sentence.WordsList.Add(new TstItemOfSentence() {
                Kind = TstKindOfItemOfSentence.ModalVerb,
                IsVerb = true,
                IsMainAdditional = true
            });

            sentence.WordsList.Add(TstItemOfSentence.CreateVerb());

            return ProcessMainSentence(sentence, false);
        }

        private List<TstSentence> DefineImperative()
        {
            var sentence = new TstSentence();

            sentence.WordsList.Add(TstItemOfSentence.CreateVerb());

            return ProcessMainSentence(sentence, false, false);
        }

        private List<TstSentence> ProcessMainSentence(TstSentence sentence, bool enableFuture = true, bool enableQuestions = true)
        {
            LogInstance.Log($"sentence = {sentence.ToDisplayStr()}");

            var result = new List<TstSentence>();
            result.Add(sentence);

            result.AddRange(CreateDerivativeSentences(sentence, enableQuestions));

            if(enableFuture)
            {
                var willSentence = CreateWillSentence(sentence);

                result.Add(willSentence);

                result.AddRange(CreateDerivativeSentences(willSentence, enableQuestions));
            }

            return result;
        }

        private TstSentence CreateWillSentence(TstSentence sentence)
        {
            LogInstance.Log($"sentence = {sentence.ToDisplayStr()}");

            var newSentence = sentence.Fork();

            var indexOfMainAdditional = newSentence.IndexOfMainAdditional;

            //LogInstance.Log($"indexOfMainAdditional = {indexOfMainAdditional}");

            if(indexOfMainAdditional > -1)
            {
                var mainAdditionalVerb = newSentence.WordsList[indexOfMainAdditional];

                if(mainAdditionalVerb.Kind == TstKindOfItemOfSentence.FToBe)
                {
                    mainAdditionalVerb.Kind = TstKindOfItemOfSentence.Be;
                }

                mainAdditionalVerb.IsMutable = false;
                mainAdditionalVerb.IsMainAdditional = false;
                mainAdditionalVerb.IsSecondAdditional = true;
            }

            var indexOfSubject = newSentence.IndexOfSubject;

            //LogInstance.Log($"indexOfSubject = {indexOfSubject}");

            if (indexOfSubject == -1)
            {
                throw new ArgumentOutOfRangeException(nameof(indexOfSubject), indexOfSubject, null);
            }

            newSentence.WordsList.Insert(indexOfSubject + 1, TstItemOfSentence.CreateWill());

            LogInstance.Log($"after sentence = {newSentence.ToDisplayStr()}");

            return newSentence;
        }

        private List<TstSentence> CreateDerivativeSentences(TstSentence sentence, bool enableQuestions = true)
        {
            LogInstance.Log($"sentence = {sentence.ToDisplayStr()}");

            var result = new List<TstSentence>();

            var item = CreateNegation(sentence);

            if(item != null)
            {
                result.Add(item);
            }

            if(enableQuestions)
            {
                item = CreateSimpleQuestion(sentence);
                if (item != null)
                {
                    result.Add(item);
                }
                //result.Add(CreateSimpleQuestionWithNegation(sentence));

                item = CreateSubjectQuestionVar1(sentence);
                if (item != null)
                {
                    result.Add(item);
                }

                item = CreateSubjectQuestionVar2(sentence);

                if (item != null)
                {
                    result.Add(item);
                }
                //result.Add(CreateSubjectQuestionWithNegation(sentence));
                item = CreateObjectQuestion(sentence);
                if (item != null)
                {
                    result.Add(item);
                }
                //result.Add(CreateObjectQuestionWithNegation(sentence));
            }

            return result;
        }

        private TstSentence CreateNegation(TstSentence sentence)
        {
            LogInstance.Log($"sentence = {sentence.ToDisplayStr()}");

            var newSentence = sentence.Fork();

            //LogInstance.Log($"newSentence = {newSentence.ToDisplayStr()}");

            if(newSentence.HasMainAdditional)
            {
                return CreateNegationWithAdditionalVerb(newSentence);
            }

            return CreateNegationWithoutAdditionalVerb(newSentence);
        }

        private TstSentence CreateNegationWithAdditionalVerb(TstSentence sentence)
        {
            LogInstance.Log($"sentence = {sentence.ToDisplayStr()}");

            var indexOfMainAdditional = sentence.IndexOfMainAdditional;

            //LogInstance.Log($"indexOfMainAdditional = {indexOfMainAdditional}");

            if (indexOfMainAdditional == -1)
            {
                throw new ArgumentOutOfRangeException(nameof(indexOfMainAdditional), indexOfMainAdditional, null);
            }

            sentence.WordsList.Insert(indexOfMainAdditional + 1, TstItemOfSentence.CreateNot());

            LogInstance.Log($"after sentence = {sentence.ToDisplayStr()}");

            return sentence;
        }

        private TstSentence CreateNegationWithoutAdditionalVerb(TstSentence sentence)
        {
            LogInstance.Log($"sentence = {sentence.ToDisplayStr()}");

            var indexOfSubject = sentence.IndexOfSubject;

            //LogInstance.Log($"indexOfSubject = {indexOfSubject}");

            if(indexOfSubject == -1)
            {
                //throw new ArgumentOutOfRangeException(nameof(indexOfSubject), indexOfSubject, null);
            }

            sentence.WordsList.Insert(indexOfSubject + 1, TstItemOfSentence.CreateFToDo());
            sentence.WordsList.Insert(indexOfSubject + 2, TstItemOfSentence.CreateNot());

            LogInstance.Log($"after sentence = {sentence.ToDisplayStr()}");

            return sentence;
        }

        private TstSentence CreateSimpleQuestion(TstSentence sentence)
        {
            LogInstance.Log($"sentence = {sentence.ToDisplayStr()}");

            var newSentence = sentence.Fork();

            if(newSentence.HasMainAdditional)
            {
                return CreateSimpleQuestionWithAdditionalVerb(newSentence);
            }

            return CreateSimpleQuestionWithoutAdditionalVerb(newSentence);
        }

        private TstSentence CreateSimpleQuestionWithAdditionalVerb(TstSentence sentence)
        {
            LogInstance.Log($"sentence = {sentence.ToDisplayStr()}");

            var indexOfMainAdditional = sentence.IndexOfMainAdditional;

            //LogInstance.Log($"indexOfMainAdditional = {indexOfMainAdditional}");

            if (indexOfMainAdditional == -1)
            {
                throw new ArgumentOutOfRangeException(nameof(indexOfMainAdditional), indexOfMainAdditional, null);
            }

            var indexOfSubject = sentence.IndexOfSubject;

            //LogInstance.Log($"indexOfSubject = {indexOfSubject}");

            if (indexOfSubject == -1)
            {
                throw new ArgumentOutOfRangeException(nameof(indexOfSubject), indexOfSubject, null);
            }

            var mainAdditionalVerb = sentence.WordsList[indexOfMainAdditional];

            sentence.WordsList.Remove(mainAdditionalVerb);

            sentence.WordsList.Insert(indexOfSubject, mainAdditionalVerb);

            LogInstance.Log($"after sentence = {sentence.ToDisplayStr()}");

            return sentence;
        }

        private TstSentence CreateSimpleQuestionWithoutAdditionalVerb(TstSentence sentence)
        {
            LogInstance.Log($"sentence = {sentence.ToDisplayStr()}");

            var indexOfSubject = sentence.IndexOfSubject;

            //LogInstance.Log($"indexOfSubject = {indexOfSubject}");

            if (indexOfSubject == -1)
            {
                throw new ArgumentOutOfRangeException(nameof(indexOfSubject), indexOfSubject, null);
            }

            sentence.WordsList.Insert(indexOfSubject, TstItemOfSentence.CreateFToDo());

            LogInstance.Log($"after sentence = {sentence.ToDisplayStr()}");

            return sentence;
        }

        private TstSentence CreateSimpleQuestionWithNegation(TstSentence sentence)
        {
            LogInstance.Log($"sentence = {sentence.ToDisplayStr()}");

            var newSentence = sentence.Fork();

            if (newSentence.HasMainAdditional)
            {
                return CreateSimpleQuestionWithNegationWithAdditionalVerb(newSentence);
            }

            return CreateSimpleQuestionWithNegationWithoutAdditionalVerb(newSentence);
        }

        private TstSentence CreateSimpleQuestionWithNegationWithAdditionalVerb(TstSentence sentence)
        {
            LogInstance.Log($"sentence = {sentence.ToDisplayStr()}");

            var indexOfMainAdditional = sentence.IndexOfMainAdditional;

            //LogInstance.Log($"indexOfMainAdditional = {indexOfMainAdditional}");

            if (indexOfMainAdditional == -1)
            {
                throw new ArgumentOutOfRangeException(nameof(indexOfMainAdditional), indexOfMainAdditional, null);
            }

            var indexOfSubject = sentence.IndexOfSubject;

            //LogInstance.Log($"indexOfSubject = {indexOfSubject}");

            if (indexOfSubject == -1)
            {
                throw new ArgumentOutOfRangeException(nameof(indexOfSubject), indexOfSubject, null);
            }

            var mainAdditionalVerb = sentence.WordsList[indexOfMainAdditional];

            sentence.WordsList.Remove(mainAdditionalVerb);

            sentence.WordsList.Insert(indexOfSubject, mainAdditionalVerb);
            sentence.WordsList.Insert(indexOfSubject + 1, TstItemOfSentence.CreateNot());

            LogInstance.Log($"after sentence = {sentence.ToDisplayStr()}");

            return sentence;
        }

        private TstSentence CreateSimpleQuestionWithNegationWithoutAdditionalVerb(TstSentence sentence)
        {
            LogInstance.Log($"sentence = {sentence.ToDisplayStr()}");

            var indexOfSubject = sentence.IndexOfSubject;

            //LogInstance.Log($"indexOfSubject = {indexOfSubject}");

            if (indexOfSubject == -1)
            {
                throw new ArgumentOutOfRangeException(nameof(indexOfSubject), indexOfSubject, null);
            }

            sentence.WordsList.Insert(indexOfSubject, TstItemOfSentence.CreateFToDo());
            sentence.WordsList.Insert(indexOfSubject + 1, TstItemOfSentence.CreateNot());

            LogInstance.Log($"after sentence = {sentence.ToDisplayStr()}");

            return sentence;
        }

        private TstSentence CreateSubjectQuestionVar1(TstSentence sentence)
        {
            LogInstance.Log($"sentence = {sentence.ToDisplayStr()}");

            var newSentence = sentence.Fork();

            var indexOfSubject = newSentence.IndexOfSubject;

            //LogInstance.Log($"indexOfSubject = {indexOfSubject}");

            if (indexOfSubject == -1)
            {
                throw new ArgumentOutOfRangeException(nameof(indexOfSubject), indexOfSubject, null);
            }

            var subject = newSentence.WordsList[indexOfSubject];

            subject.Kind = TstKindOfItemOfSentence.QWSubj;

            LogInstance.Log($"after newSentence = {newSentence.ToDisplayStr()}");

            return newSentence;
        }

        private TstSentence CreateSubjectQuestionVar2(TstSentence sentence)
        {
            LogInstance.Log($"sentence = {sentence.ToDisplayStr()}");

            if (sentence.HasMainAdditional)
            {
                return null;
            }

            var newSentence = sentence.Fork();

            var indexOfSubject = newSentence.IndexOfSubject;

            //LogInstance.Log($"indexOfSubject = {indexOfSubject}");

            if (indexOfSubject == -1)
            {
                throw new ArgumentOutOfRangeException(nameof(indexOfSubject), indexOfSubject, null);
            }

            var subject = newSentence.WordsList[indexOfSubject];

            subject.Kind = TstKindOfItemOfSentence.QWSubj;

            newSentence.WordsList.Insert(indexOfSubject + 1, TstItemOfSentence.CreateFToDo());

            LogInstance.Log($"after newSentence = {newSentence.ToDisplayStr()}");

            return newSentence;
        }

        private TstSentence CreateSubjectQuestionWithNegation(TstSentence sentence)
        {
            LogInstance.Log($"sentence = {sentence.ToDisplayStr()}");

            var newSentence = sentence.Fork();

            if(newSentence.HasMainAdditional)
            {
                return CreateSubjectQuestionWithNegationWithAdditionalVerb(newSentence);
            }

            return CreateSubjectQuestionWithNegationWithoutAdditionalVerb(newSentence);
        }

        private TstSentence CreateSubjectQuestionWithNegationWithAdditionalVerb(TstSentence sentence)
        {
            LogInstance.Log($"sentence = {sentence.ToDisplayStr()}");

            var indexOfMainAdditional = sentence.IndexOfMainAdditional;

            //LogInstance.Log($"indexOfMainAdditional = {indexOfMainAdditional}");

            if (indexOfMainAdditional == -1)
            {
                throw new ArgumentOutOfRangeException(nameof(indexOfMainAdditional), indexOfMainAdditional, null);
            }

            sentence.WordsList.Insert(indexOfMainAdditional + 1, TstItemOfSentence.CreateNot());

            var indexOfSubject = sentence.IndexOfSubject;

            //LogInstance.Log($"indexOfSubject = {indexOfSubject}");

            if (indexOfSubject == -1)
            {
                throw new ArgumentOutOfRangeException(nameof(indexOfSubject), indexOfSubject, null);
            }

            var subject = sentence.WordsList[indexOfSubject];

            subject.Kind = TstKindOfItemOfSentence.QWSubj;

            LogInstance.Log($"after sentence = {sentence.ToDisplayStr()}");

            return sentence;
        }

        private TstSentence CreateSubjectQuestionWithNegationWithoutAdditionalVerb(TstSentence sentence)
        {
            LogInstance.Log($"sentence = {sentence.ToDisplayStr()}");

            var indexOfSubject = sentence.IndexOfSubject;

            //LogInstance.Log($"indexOfSubject = {indexOfSubject}");

            if (indexOfSubject == -1)
            {
                throw new ArgumentOutOfRangeException(nameof(indexOfSubject), indexOfSubject, null);
            }

            var subject = sentence.WordsList[indexOfSubject];

            subject.Kind = TstKindOfItemOfSentence.QWSubj;

            sentence.WordsList.Insert(indexOfSubject + 1, TstItemOfSentence.CreateFToDo());
            sentence.WordsList.Insert(indexOfSubject + 2, TstItemOfSentence.CreateNot());

            LogInstance.Log($"after sentence = {sentence.ToDisplayStr()}");

            return sentence;
        }

        private TstSentence CreateObjectQuestion(TstSentence sentence)
        {
            LogInstance.Log($"sentence = {sentence.ToDisplayStr()}");

            var newSentence = sentence.Fork();

            if(newSentence.HasMainAdditional)
            {
                return CreateObjectQuestionWithAdditionalVerb(newSentence);
            }

            return CreateObjectQuestionWithoutAdditionalVerb(newSentence);
        }

        private TstSentence CreateObjectQuestionWithAdditionalVerb(TstSentence sentence)
        {
            LogInstance.Log($"sentence = {sentence.ToDisplayStr()}");

            var indexOfMainAdditional = sentence.IndexOfMainAdditional;

            //LogInstance.Log($"indexOfMainAdditional = {indexOfMainAdditional}");

            if (indexOfMainAdditional == -1)
            {
                throw new ArgumentOutOfRangeException(nameof(indexOfMainAdditional), indexOfMainAdditional, null);
            }

            var indexOfSubject = sentence.IndexOfSubject;

            //LogInstance.Log($"indexOfSubject = {indexOfSubject}");

            if (indexOfSubject == -1)
            {
                throw new ArgumentOutOfRangeException(nameof(indexOfSubject), indexOfSubject, null);
            }

            var mainAdditionalVerb = sentence.WordsList[indexOfMainAdditional];

            sentence.WordsList.Remove(mainAdditionalVerb);

            sentence.WordsList.Insert(indexOfSubject, mainAdditionalVerb);

            sentence.WordsList.Insert(0, TstItemOfSentence.CreateQWObj());

            LogInstance.Log($"after sentence = {sentence.ToDisplayStr()}");

            return sentence;
        }

        private TstSentence CreateObjectQuestionWithoutAdditionalVerb(TstSentence sentence)
        {
            LogInstance.Log($"sentence = {sentence.ToDisplayStr()}");

            var indexOfSubject = sentence.IndexOfSubject;

            //LogInstance.Log($"indexOfSubject = {indexOfSubject}");

            if (indexOfSubject == -1)
            {
                throw new ArgumentOutOfRangeException(nameof(indexOfSubject), indexOfSubject, null);
            }

            sentence.WordsList.Insert(indexOfSubject, TstItemOfSentence.CreateFToDo());

            sentence.WordsList.Insert(0, TstItemOfSentence.CreateQWObj());

            LogInstance.Log($"after sentence = {sentence.ToDisplayStr()}");

            return sentence;
        }

        private TstSentence CreateObjectQuestionWithNegation(TstSentence sentence)
        {
            LogInstance.Log($"sentence = {sentence.ToDisplayStr()}");

            var newSentence = sentence.Fork();

            if(newSentence.HasMainAdditional)
            {
                return CreateObjectQuestionWithNegationWithAdditionalVerb(newSentence);
            }

            return CreateObjectQuestionWithNegationWithoutAdditionalVerb(newSentence);
        }

        private TstSentence CreateObjectQuestionWithNegationWithAdditionalVerb(TstSentence sentence)
        {
            LogInstance.Log($"sentence = {sentence.ToDisplayStr()}");

            var indexOfMainAdditional = sentence.IndexOfMainAdditional;

            //LogInstance.Log($"indexOfMainAdditional = {indexOfMainAdditional}");

            if (indexOfMainAdditional == -1)
            {
                throw new ArgumentOutOfRangeException(nameof(indexOfMainAdditional), indexOfMainAdditional, null);
            }

            var indexOfSubject = sentence.IndexOfSubject;

            //LogInstance.Log($"indexOfSubject = {indexOfSubject}");

            if (indexOfSubject == -1)
            {
                throw new ArgumentOutOfRangeException(nameof(indexOfSubject), indexOfSubject, null);
            }

            var mainAdditionalVerb = sentence.WordsList[indexOfMainAdditional];

            sentence.WordsList.Remove(mainAdditionalVerb);

            sentence.WordsList.Insert(indexOfSubject, mainAdditionalVerb);
            sentence.WordsList.Insert(indexOfSubject + 1, TstItemOfSentence.CreateNot());

            sentence.WordsList.Insert(0, TstItemOfSentence.CreateQWObj());

            LogInstance.Log($"after sentence = {sentence.ToDisplayStr()}");

            return sentence;
        }

        private TstSentence CreateObjectQuestionWithNegationWithoutAdditionalVerb(TstSentence sentence)
        {
            LogInstance.Log($"sentence = {sentence.ToDisplayStr()}");

            var indexOfSubject = sentence.IndexOfSubject;

            //LogInstance.Log($"indexOfSubject = {indexOfSubject}");

            if (indexOfSubject == -1)
            {
                throw new ArgumentOutOfRangeException(nameof(indexOfSubject), indexOfSubject, null);
            }

            sentence.WordsList.Insert(indexOfSubject, TstItemOfSentence.CreateFToDo());
            sentence.WordsList.Insert(indexOfSubject + 1, TstItemOfSentence.CreateNot());

            sentence.WordsList.Insert(0, TstItemOfSentence.CreateQWObj());

            LogInstance.Log($"after sentence = {sentence.ToDisplayStr()}");

            return sentence;
        }
    }
}
