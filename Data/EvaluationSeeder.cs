using WebApplication1.Models; 
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Question = WebApplication1.Models.Question;
using OptionReponse = WebApplication1.Models.OptionReponse;
using Evaluation = WebApplication1.Models.Evaluation;

namespace WebApplication1.Data
{
    public static class EvaluationSeeder
    {
        public static void SeedIntelligenceEvaluation(ModelBuilder modelBuilder)
        {
            // 1. Create the Evaluation
            var evaluationId = 1;
            
            modelBuilder.Entity<Evaluation>().HasData(new Evaluation
            {
                Id = evaluationId,
                Titre = "Évaluation Intelligences Logiques et Relationnelles",
                Description = "Test d'intelligence basé sur le raisonnement logique, la résolution de problèmes et les compétences relationnelles",
                DureeMinutes = 30,
DateCreation = new DateTime(2024, 01, 01)
            },
            new Evaluation
    {
        Id = 2,
        Titre = "Évaluation Français",
        Description = "Test de compréhension française",
        DureeMinutes = 20,
DateCreation = new DateTime(2024, 6, 1)
    });
    var evaluationId3 = 3;
modelBuilder.Entity<Evaluation>().HasData(new Evaluation
{
    Id = evaluationId3,
    Titre = "English - Corporate Communication Test",
    Description = "Business communication vocabulary and situational understanding",
    DureeMinutes = 20,
    DateCreation = new DateTime(2024, 1, 1)
});

            // 2. Create Questions with their Options
var questions = new List<Question>();
            var options = new List<OptionReponse>();
            int questionId = 1;
            int optionId = 1;

            // ========== JUNIOR LEVEL ==========

            // Question 1
            questions.Add(new Question
            {
                Id = questionId,
                Texte = "Si tous les vendredis soir je fais du sport, et aujourd'hui c'est samedi matin, combien de fois ai-je fait du sport cette semaine?",
                Type = "logique_deduction",
                Points = 1
            });
            
            options.AddRange(new[]
            {
                new OptionReponse { Id = optionId++, Texte = "0 fois", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "1 fois", EstCorrecte = true, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "2 fois", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "Impossible à déterminer", EstCorrecte = false, QuestionId = questionId }
            });
            questionId++;

            // Question 2
            questions.Add(new Question
            {
                Id = questionId,
                Texte = "Dans une suite numérique: 2, 4, 8, 16, ?, le prochain nombre est?",
                Type = "reconnaissance_pattern",
                Points = 1
            });
            
            options.AddRange(new[]
            {
                new OptionReponse { Id = optionId++, Texte = "24", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "32", EstCorrecte = true, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "30", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "36", EstCorrecte = false, QuestionId = questionId }
            });
            questionId++;

            // Question 3
            questions.Add(new Question
            {
                Id = questionId,
                Texte = "Trois personnes entrent dans une salle. Deux en sortent. Combien de personnes restent dans la salle?",
                Type = "logique_deduction",
                Points = 1
            });
            
            options.AddRange(new[]
            {
                new OptionReponse { Id = optionId++, Texte = "0", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "1", EstCorrecte = true, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "3", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "2", EstCorrecte = false, QuestionId = questionId }
            });
            questionId++;

            // ========== MID-LEVEL ==========

            // Question 4
            questions.Add(new Question
            {
                Id = questionId,
                Texte = "Vous gérez une équipe de 5 personnes. Deux d'entre elles ne s'entendent pas. Elles refusent de travailler ensemble. Vous devez former une équipe de 3 personnes pour un projet. Quel est le nombre maximum d'équipes différentes que vous pouvez former?",
                Type = "logique_combinatoire",
                Points = 2
            });
            
            options.AddRange(new[]
            {
                new OptionReponse { Id = optionId++, Texte = "8 équipes", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "9 équipes", EstCorrecte = true, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "10 équipes", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "7 équipes", EstCorrecte = false, QuestionId = questionId }
            });
            questionId++;

            // Question 5
            questions.Add(new Question
            {
                Id = questionId,
                Texte = "Un client demande une nouvelle fonctionnalité qui contredit le design actuel. Le deadline est dans 2 jours. Vous avez 3 options: (A) Refuser et expliquer pourquoi c'est mauvais, (B) Accepter sans discuter, (C) Proposer une alternative qui satisfait le besoin sans casser le design. Quelle est la meilleure approche managériale?",
                Type = "soft_skills_decision",
                Points = 2
            });
            
            options.AddRange(new[]
            {
                new OptionReponse { Id = optionId++, Texte = "A - Refuser directement", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "B - Accepter sans question", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "C - Proposer une alternative", EstCorrecte = true, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "Repousser le deadline", EstCorrecte = false, QuestionId = questionId }
            });
            questionId++;

            // Question 6
            questions.Add(new Question
            {
                Id = questionId,
                Texte = "Suite logique: J, F, M, A, M, J, J, A, S, O, N, D, ?",
                Type = "reconnaissance_pattern",
                Points = 2
            });
            
            options.AddRange(new[]
            {
                new OptionReponse { Id = optionId++, Texte = "E", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "J", EstCorrecte = true, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "A", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "F", EstCorrecte = false, QuestionId = questionId }
            });
            questionId++;

            // Question 7
            questions.Add(new Question
            {
                Id = questionId,
                Texte = "Vous découvrez une erreur critique dans le code en production que vous avez écrit hier. L'équipe ne le sait pas encore. Que faites-vous?",
                Type = "soft_skills_ethique",
                Points = 2
            });
            
            options.AddRange(new[]
            {
                new OptionReponse { Id = optionId++, Texte = "L'ignorer et espérer que personne ne la trouve", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "En informer immédiatement le manager et proposer une solution", EstCorrecte = true, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "Chercher à blâmer quelqu'un d'autre", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "Attendre que quelqu'un d'autre la découvre", EstCorrecte = false, QuestionId = questionId }
            });
            questionId++;

            // ========== SENIOR LEVEL ==========

            // Question 8
            questions.Add(new Question
            {
                Id = questionId,
                Texte = "Une entreprise mesure la performance des développeurs par le nombre de lignes de code écrites par jour. Qu'est-ce qui est problématique dans cette approche?",
                Type = "thinking_critique",
                Points = 3
            });
            
            options.AddRange(new[]
            {
                new OptionReponse { Id = optionId++, Texte = "C'est une excellente métrique objective", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "Cela encourage la qualité plutôt que la quantité", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "Cela incite à écrire du code inutile et de mauvaise qualité", EstCorrecte = true, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "C'est la seule façon de mesurer la productivité", EstCorrecte = false, QuestionId = questionId }
            });
            questionId++;

            // Question 9
            questions.Add(new Question
            {
                Id = questionId,
                Texte = "Deux solutions techniques peuvent résoudre un problème: A (rapide à développer, coûteuse en maintenance) et B (plus lente à développer, peu coûteuse en maintenance). Le projet dure 5 ans. Quelle est la meilleure décision?",
                Type = "strategic_thinking",
                Points = 3
            });
            
            options.AddRange(new[]
            {
                new OptionReponse { Id = optionId++, Texte = "Toujours choisir A pour la rapidité", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "Analyser le coût total sur 5 ans (dev + maintenance) et choisir B si c'est inférieur", EstCorrecte = true, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "Choisir toujours la solution la plus complexe", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "C'est équivalent, le choix n'importe pas", EstCorrecte = false, QuestionId = questionId }
            });
            questionId++;

            // Question 10
            questions.Add(new Question
            {
                Id = questionId,
                Texte = "Un collègue junior fait une erreur qui cause un bug client. Comment gérez-vous cette situation pour favoriser l'apprentissage?",
                Type = "leadership_soft_skills",
                Points = 3
            });
            
            options.AddRange(new[]
            {
                new OptionReponse { Id = optionId++, Texte = "Le blâmer publiquement pour l'humilier", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "En discuter en privé, comprendre son processus, lui proposer des solutions", EstCorrecte = true, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "Ignorer et laisser quelqu'un d'autre le corriger", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "Le reporter au manager immédiatement", EstCorrecte = false, QuestionId = questionId }
            });
            questionId++;

            // Question 11
            questions.Add(new Question
            {
                Id = questionId,
                Texte = "Pattern: 1, 1, 2, 3, 5, 8, 13, ?, ?",
                Type = "reconnaissance_pattern_avancee",
                Points = 3
            });
            
            options.AddRange(new[]
            {
                new OptionReponse { Id = optionId++, Texte = "21, 34", EstCorrecte = true, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "20, 33", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "15, 20", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "18, 31", EstCorrecte = false, QuestionId = questionId }
            });
            questionId++;

            // Question 12
            questions.Add(new Question
            {
                Id = questionId,
                Texte = "Un client demande une feature que vous savez techniquement faisable mais nuisible pour l'UX. Vous l'expliquez mais il insiste. Quel est votre rôle?",
                Type = "professional_advocacy",
                Points = 3
            });
            
            options.AddRange(new[]
            {
                new OptionReponse { Id = optionId++, Texte = "Faire exactement ce qu'il demande sans question", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "Refuser catégoriquement", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "Documenter vos préoccupations, proposer des alternatives, puis laisser le client décider", EstCorrecte = true, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "Faire ce qu'il demande mais très lentement", EstCorrecte = false, QuestionId = questionId }
            });
            questionId++;

            // Question 13
            questions.Add(new Question
            {
                Id = questionId,
                Texte = "Trois programmeurs codent le même module. Programmeur A finit en 2j (code complexe), Programmeur B finit en 4j (code lisible), Programmeur C finit en 5j (code brillant, maintenable). Quel est le meilleur pour l'entreprise à long terme?",
                Type = "strategic_analysis",
                Points = 3
            });
            
            options.AddRange(new[]
            {
                new OptionReponse { Id = optionId++, Texte = "A, car plus rapide", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "B ou C selon le contexte (durée du projet, maintenabilité future)", EstCorrecte = true, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "C toujours, peu importe le coût", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "Aucun, tous sont équivalents", EstCorrecte = false, QuestionId = questionId }
            });
            questionId++;

            // Question 14
            questions.Add(new Question
            {
                Id = questionId,
                Texte = "Vous avez 10 ressources et 3 projets urgents. Le projet A rapporte 100€, B rapporte 150€, C rapporte 80€. A nécessite 5 ressources, B en 4, C en 3. Comment les allouez-vous?",
                Type = "logique_optimisation",
                Points = 3
            });
            
            options.AddRange(new[]
            {
                new OptionReponse { Id = optionId++, Texte = "A + B (9 ressources, 250€)", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "B + C (7 ressources, 230€)", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "A + C + allocations flexibles pour maximiser ROI", EstCorrecte = true, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "Tous les trois (impossible avec 10)", EstCorrecte = false, QuestionId = questionId }
            });
            questionId++;

            // Question 15
            questions.Add(new Question
            {
                Id = questionId,
                Texte = "Vous remarquez que votre équipe travaille constamment en overtime. Quel est le vrai problème selon vous?",
                Type = "systemic_thinking",
                Points = 3
            });
            
            options.AddRange(new[]
            {
                new OptionReponse { Id = optionId++, Texte = "L'équipe n'est pas assez productive", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "Le projet est mal estimé, les attentes irréalistes, ou le processus est inefficace", EstCorrecte = true, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "Les développeurs sont paresseux", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "C'est normal dans l'industrie tech", EstCorrecte = false, QuestionId = questionId }
            });
            questionId++;

            // Question 16
            questions.Add(new Question
            {
                Id = questionId,
                Texte = "Un bug critique est découvert juste avant le release. Il faut 3 jours pour le corriger. Quelle est la meilleure décision?",
                Type = "strategic_decision_making",
                Points = 3
            });
            
            options.AddRange(new[]
            {
                new OptionReponse { Id = optionId++, Texte = "Lancer le release avec le bug et prier", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "Évaluer l'impact, la probabilité d'occurrence, et décider si on retarde ou accepte le risque", EstCorrecte = true, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "Toujours corriger, peu importe le délai", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "Cacher le bug aux utilisateurs", EstCorrecte = false, QuestionId = questionId }
            });
            questionId++;

            // Question 17
            questions.Add(new Question
            {
                Id = questionId,
                Texte = "Pattern comportemental: Un stagiaire pose toujours des questions basiques après avoir lu la doc. Que concluez-vous?",
                Type = "pattern_recognition_behavior",
                Points = 3
            });
            
            options.AddRange(new[]
            {
                new OptionReponse { Id = optionId++, Texte = "Il est incompétent et doit être viré", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "Il ne lit pas la documentation ou ne la comprend pas", EstCorrecte = true, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "C'est normal pour tous les stagiaires", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "Il cherche de l'attention", EstCorrecte = false, QuestionId = questionId }
            });
            questionId++;

            // Question 18
            questions.Add(new Question
            {
                Id = questionId,
                Texte = "Deux approches: Agile (flexible, itérative) vs Waterfall (planning rigoureux). Pour un projet gouvernemental avec budget fixe et requirements clairs, quelle est la meilleure?",
                Type = "contextual_methodology",
                Points = 3
            });
            
            options.AddRange(new[]
            {
                new OptionReponse { Id = optionId++, Texte = "Agile est toujours meilleur", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "Waterfall car requirements sont clairs et stables", EstCorrecte = true, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "Mélanger les deux", EstCorrecte = false, QuestionId = questionId },
                new OptionReponse { Id = optionId++, Texte = "Waterfall est toujours meilleur", EstCorrecte = false, QuestionId = questionId }
            });

            // 🔥 EFFICIENT: Set EvaluationId for all questions at once
            questions.ForEach(q => q.EvaluationId = evaluationId);

            // Seed all questions
            modelBuilder.Entity<Question>().HasData(questions);
            
            // Seed all options
            modelBuilder.Entity<OptionReponse>().HasData(options);
        }
    }
}