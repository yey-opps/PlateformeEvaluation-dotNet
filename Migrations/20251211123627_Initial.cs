using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PlateformeEvaluation.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Candidats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotDePasse = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DureeMinutes = table.Column<int>(type: "int", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Candidatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Statut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCandidature = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CandidatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidatures_Candidats_CandidatId",
                        column: x => x.CandidatId,
                        principalTable: "Candidats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Texte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    EvaluationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Evaluations_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "Evaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tentatives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatePassage = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Score = table.Column<float>(type: "real", nullable: false),
                    CandidatId = table.Column<int>(type: "int", nullable: false),
                    EvaluationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tentatives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tentatives_Candidats_CandidatId",
                        column: x => x.CandidatId,
                        principalTable: "Candidats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tentatives_Evaluations_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "Evaluations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OptionsReponse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstCorrecte = table.Column<bool>(type: "bit", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    Texte = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionsReponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OptionsReponse_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReponsesCandidats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReponseTexte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    TentativeId = table.Column<int>(type: "int", nullable: false),
                    OptionReponseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReponsesCandidats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReponsesCandidats_OptionsReponse_OptionReponseId",
                        column: x => x.OptionReponseId,
                        principalTable: "OptionsReponse",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReponsesCandidats_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReponsesCandidats_Tentatives_TentativeId",
                        column: x => x.TentativeId,
                        principalTable: "Tentatives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Evaluations",
                columns: new[] { "Id", "DateCreation", "Description", "DureeMinutes", "Titre" },
                values: new object[] { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test d'intelligence basé sur le raisonnement logique, la résolution de problèmes et les compétences relationnelles", 30, "Évaluation Intelligences Logiques et Relationnelles" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "EvaluationId", "Points", "Texte", "Type" },
                values: new object[,]
                {
                    { 1, 1, 1, "Si tous les vendredis soir je fais du sport, et aujourd'hui c'est samedi matin, combien de fois ai-je fait du sport cette semaine?", "logique_deduction" },
                    { 2, 1, 1, "Dans une suite numérique: 2, 4, 8, 16, ?, le prochain nombre est?", "reconnaissance_pattern" },
                    { 3, 1, 1, "Trois personnes entrent dans une salle. Deux en sortent. Combien de personnes restent dans la salle?", "logique_deduction" },
                    { 4, 1, 2, "Vous gérez une équipe de 5 personnes. Deux d'entre elles ne s'entendent pas. Elles refusent de travailler ensemble. Vous devez former une équipe de 3 personnes pour un projet. Quel est le nombre maximum d'équipes différentes que vous pouvez former?", "logique_combinatoire" },
                    { 5, 1, 2, "Un client demande une nouvelle fonctionnalité qui contredit le design actuel. Le deadline est dans 2 jours. Vous avez 3 options: (A) Refuser et expliquer pourquoi c'est mauvais, (B) Accepter sans discuter, (C) Proposer une alternative qui satisfait le besoin sans casser le design. Quelle est la meilleure approche managériale?", "soft_skills_decision" },
                    { 6, 1, 2, "Suite logique: J, F, M, A, M, J, J, A, S, O, N, D, ?", "reconnaissance_pattern" },
                    { 7, 1, 2, "Vous découvrez une erreur critique dans le code en production que vous avez écrit hier. L'équipe ne le sait pas encore. Que faites-vous?", "soft_skills_ethique" },
                    { 8, 1, 3, "Une entreprise mesure la performance des développeurs par le nombre de lignes de code écrites par jour. Qu'est-ce qui est problématique dans cette approche?", "thinking_critique" },
                    { 9, 1, 3, "Deux solutions techniques peuvent résoudre un problème: A (rapide à développer, coûteuse en maintenance) et B (plus lente à développer, peu coûteuse en maintenance). Le projet dure 5 ans. Quelle est la meilleure décision?", "strategic_thinking" },
                    { 10, 1, 3, "Un collègue junior fait une erreur qui cause un bug client. Comment gérez-vous cette situation pour favoriser l'apprentissage?", "leadership_soft_skills" },
                    { 11, 1, 3, "Pattern: 1, 1, 2, 3, 5, 8, 13, ?, ?", "reconnaissance_pattern_avancee" },
                    { 12, 1, 3, "Un client demande une feature que vous savez techniquement faisable mais nuisible pour l'UX. Vous l'expliquez mais il insiste. Quel est votre rôle?", "professional_advocacy" },
                    { 13, 1, 3, "Trois programmeurs codent le même module. Programmeur A finit en 2j (code complexe), Programmeur B finit en 4j (code lisible), Programmeur C finit en 5j (code brillant, maintenable). Quel est le meilleur pour l'entreprise à long terme?", "strategic_analysis" },
                    { 14, 1, 3, "Vous avez 10 ressources et 3 projets urgents. Le projet A rapporte 100€, B rapporte 150€, C rapporte 80€. A nécessite 5 ressources, B en 4, C en 3. Comment les allouez-vous?", "logique_optimisation" },
                    { 15, 1, 3, "Vous remarquez que votre équipe travaille constamment en overtime. Quel est le vrai problème selon vous?", "systemic_thinking" },
                    { 16, 1, 3, "Un bug critique est découvert juste avant le release. Il faut 3 jours pour le corriger. Quelle est la meilleure décision?", "strategic_decision_making" },
                    { 17, 1, 3, "Pattern comportemental: Un stagiaire pose toujours des questions basiques après avoir lu la doc. Que concluez-vous?", "pattern_recognition_behavior" },
                    { 18, 1, 3, "Deux approches: Agile (flexible, itérative) vs Waterfall (planning rigoureux). Pour un projet gouvernemental avec budget fixe et requirements clairs, quelle est la meilleure?", "contextual_methodology" }
                });

            migrationBuilder.InsertData(
                table: "OptionsReponse",
                columns: new[] { "Id", "EstCorrecte", "QuestionId", "Texte" },
                values: new object[,]
                {
                    { 1, false, 1, "0 fois" },
                    { 2, true, 1, "1 fois" },
                    { 3, false, 1, "2 fois" },
                    { 4, false, 1, "Impossible à déterminer" },
                    { 5, false, 2, "24" },
                    { 6, true, 2, "32" },
                    { 7, false, 2, "30" },
                    { 8, false, 2, "36" },
                    { 9, false, 3, "0" },
                    { 10, true, 3, "1" },
                    { 11, false, 3, "3" },
                    { 12, false, 3, "2" },
                    { 13, false, 4, "8 équipes" },
                    { 14, true, 4, "9 équipes" },
                    { 15, false, 4, "10 équipes" },
                    { 16, false, 4, "7 équipes" },
                    { 17, false, 5, "A - Refuser directement" },
                    { 18, false, 5, "B - Accepter sans question" },
                    { 19, true, 5, "C - Proposer une alternative" },
                    { 20, false, 5, "Repousser le deadline" },
                    { 21, false, 6, "E" },
                    { 22, true, 6, "J" },
                    { 23, false, 6, "A" },
                    { 24, false, 6, "F" },
                    { 25, false, 7, "L'ignorer et espérer que personne ne la trouve" },
                    { 26, true, 7, "En informer immédiatement le manager et proposer une solution" },
                    { 27, false, 7, "Chercher à blâmer quelqu'un d'autre" },
                    { 28, false, 7, "Attendre que quelqu'un d'autre la découvre" },
                    { 29, false, 8, "C'est une excellente métrique objective" },
                    { 30, false, 8, "Cela encourage la qualité plutôt que la quantité" },
                    { 31, true, 8, "Cela incite à écrire du code inutile et de mauvaise qualité" },
                    { 32, false, 8, "C'est la seule façon de mesurer la productivité" },
                    { 33, false, 9, "Toujours choisir A pour la rapidité" },
                    { 34, true, 9, "Analyser le coût total sur 5 ans (dev + maintenance) et choisir B si c'est inférieur" },
                    { 35, false, 9, "Choisir toujours la solution la plus complexe" },
                    { 36, false, 9, "C'est équivalent, le choix n'importe pas" },
                    { 37, false, 10, "Le blâmer publiquement pour l'humilier" },
                    { 38, true, 10, "En discuter en privé, comprendre son processus, lui proposer des solutions" },
                    { 39, false, 10, "Ignorer et laisser quelqu'un d'autre le corriger" },
                    { 40, false, 10, "Le reporter au manager immédiatement" },
                    { 41, true, 11, "21, 34" },
                    { 42, false, 11, "20, 33" },
                    { 43, false, 11, "15, 20" },
                    { 44, false, 11, "18, 31" },
                    { 45, false, 12, "Faire exactement ce qu'il demande sans question" },
                    { 46, false, 12, "Refuser catégoriquement" },
                    { 47, true, 12, "Documenter vos préoccupations, proposer des alternatives, puis laisser le client décider" },
                    { 48, false, 12, "Faire ce qu'il demande mais très lentement" },
                    { 49, false, 13, "A, car plus rapide" },
                    { 50, true, 13, "B ou C selon le contexte (durée du projet, maintenabilité future)" },
                    { 51, false, 13, "C toujours, peu importe le coût" },
                    { 52, false, 13, "Aucun, tous sont équivalents" },
                    { 53, false, 14, "A + B (9 ressources, 250€)" },
                    { 54, false, 14, "B + C (7 ressources, 230€)" },
                    { 55, true, 14, "A + C + allocations flexibles pour maximiser ROI" },
                    { 56, false, 14, "Tous les trois (impossible avec 10)" },
                    { 57, false, 15, "L'équipe n'est pas assez productive" },
                    { 58, true, 15, "Le projet est mal estimé, les attentes irréalistes, ou le processus est inefficace" },
                    { 59, false, 15, "Les développeurs sont paresseux" },
                    { 60, false, 15, "C'est normal dans l'industrie tech" },
                    { 61, false, 16, "Lancer le release avec le bug et prier" },
                    { 62, true, 16, "Évaluer l'impact, la probabilité d'occurrence, et décider si on retarde ou accepte le risque" },
                    { 63, false, 16, "Toujours corriger, peu importe le délai" },
                    { 64, false, 16, "Cacher le bug aux utilisateurs" },
                    { 65, false, 17, "Il est incompétent et doit être viré" },
                    { 66, true, 17, "Il ne lit pas la documentation ou ne la comprend pas" },
                    { 67, false, 17, "C'est normal pour tous les stagiaires" },
                    { 68, false, 17, "Il cherche de l'attention" },
                    { 69, false, 18, "Agile est toujours meilleur" },
                    { 70, true, 18, "Waterfall car requirements sont clairs et stables" },
                    { 71, false, 18, "Mélanger les deux" },
                    { 72, false, 18, "Waterfall est toujours meilleur" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Candidatures_CandidatId",
                table: "Candidatures",
                column: "CandidatId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionsReponse_QuestionId",
                table: "OptionsReponse",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_EvaluationId",
                table: "Questions",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_ReponsesCandidats_OptionReponseId",
                table: "ReponsesCandidats",
                column: "OptionReponseId");

            migrationBuilder.CreateIndex(
                name: "IX_ReponsesCandidats_QuestionId",
                table: "ReponsesCandidats",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ReponsesCandidats_TentativeId",
                table: "ReponsesCandidats",
                column: "TentativeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tentatives_CandidatId",
                table: "Tentatives",
                column: "CandidatId");

            migrationBuilder.CreateIndex(
                name: "IX_Tentatives_EvaluationId",
                table: "Tentatives",
                column: "EvaluationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Candidatures");

            migrationBuilder.DropTable(
                name: "ReponsesCandidats");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "OptionsReponse");

            migrationBuilder.DropTable(
                name: "Tentatives");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Candidats");

            migrationBuilder.DropTable(
                name: "Evaluations");
        }
    }
}
