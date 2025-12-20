/* ================================
   CONSEILS D'INTÉGRATION AVEC LES DONNÉES
   ================================ */

/*
   Ce fichier explique comment intégrer vos données réelles
   dans le template HTML de la page d'accueil.
*/

/* ================================
   1. STATISTIQUES DYNAMIQUES
   ================================ */

/*
   AVANT (Données statiques):
   ─────────────────────────
   <div class="stat-card">
     <h3>1,240</h3>
     <p>Candidats Inscrits</p>
   </div>

   APRÈS (Données du serveur):
   ──────────────────────────
   <div class="stat-card">
     <h3>@Model.TotalCandidats</h3>
     <p>Candidats Inscrits</p>
   </div>

   Note: Votre HomeViewModel doit contenir:
   public int TotalCandidats { get; set; }
   public int EvaluationsActives { get; set; }
   public int TentativesCompletes { get; set; }
   public int TauxReussite { get; set; }
*/

/* ================================
   2. AFFICHER LES ÉVALUATIONS RÉCENTES
   ================================ */

/*
   Remplacer les cartes statiques par une boucle:

   @foreach(var eval in Model.EvaluationsRecentes)
   {
     <div class="eval-card">
       <h4>@eval.Titre</h4>
       <p class="eval-meta">⏱️ @eval.Duree minutes • 📋 @eval.NombreQuestions questions</p>
       <div class="eval-stats">
         <div class="eval-stat-item">
           <span>Candidats</span>
           <span class="eval-stat-value">@eval.NombreCandidats</span>
         </div>
         <div class="eval-stat-item">
           <span>Complétés</span>
           <span class="eval-stat-value">@eval.NombreCompletes</span>
         </div>
         <div class="eval-stat-item">
           <span>Note Moy.</span>
           <span class="eval-stat-value">@eval.NoteMoyenne%</span>
         </div>
       </div>
     </div>
   }

   Votre HomeViewModel doit contenir:
   public List<EvaluationDto> EvaluationsRecentes { get; set; }
*/

/* ================================
   3. AJOUTER VOTRE BRANDING
   ================================ */

/*
   Remplacer le logo texte:
   
   AVANT:
   <a class="navbar-brand">WebApplication1</a>

   APRÈS:
   <a class="navbar-brand" asp-area="" asp-controller="Home" asp-action="Index">
     @Model.ApplicationName
   </a>

   Ou directement:
   <a class="navbar-brand" asp-area="" asp-controller="Home" asp-action="Index">
     Plateforme d'Évaluation
   </a>
*/

/* ================================
   4. LIENS CTA PERSONNALISÉS
   ================================ */

/*
   Les boutons doivent pointer vers vos contrôleurs:

   AVANT:
   <a href="#" class="btn btn-primary">Commencer</a>

   APRÈS:
   <a href="@Url.Action("Create", "Evaluations")" class="btn btn-primary">
     Commencer
   </a>

   <a href="@Url.Action("Index", "Evaluations")" class="btn btn-secondary">
     En savoir plus
   </a>
*/

/* ================================
   5. AFFICHER LES FEATURES DYNAMIQUEMENT
   ================================ */

/*
   Pour afficher les features depuis la base de données:

   @foreach(var feature in Model.Features)
   {
     <div class="feature-card">
       <div class="feature-icon">@feature.Icon</div>
       <h3>@feature.Titre</h3>
       <p>@feature.Description</p>
     </div>
   }

   Ou les garder statiques si ce sont les features de votre app.
*/

/* ================================
   6. EXEMPLE COMPLET HomeViewModel.cs
   ================================ */

/*
public class HomeViewModel
{
    public string ApplicationName { get; set; } = "Plateforme d'Évaluation";
    
    // Statistiques
    public int TotalCandidats { get; set; }
    public int EvaluationsActives { get; set; }
    public int TentativesCompletes { get; set; }
    public int TauxReussite { get; set; }
    
    // Évaluations récentes
    public List<EvaluationDto> EvaluationsRecentes { get; set; }
    
    // Features (optionnel)
    public List<FeatureDto> Features { get; set; }
}

public class EvaluationDto
{
    public int Id { get; set; }
    public string Titre { get; set; }
    public int Duree { get; set; }
    public int NombreQuestions { get; set; }
    public int NombreCandidats { get; set; }
    public int NombreCompletes { get; set; }
    public double NoteMoyenne { get; set; }
}

public class FeatureDto
{
    public string Icon { get; set; }
    public string Titre { get; set; }
    public string Description { get; set; }
}
*/

/* ================================
   7. EXEMPLE HomeController.cs
   ================================ */

/*
public class HomeController : Controller
{
    private readonly IEvaluationService _evaluationService;
    private readonly ICandidatService _candidatService;
    
    public HomeController(IEvaluationService evaluationService, ICandidatService candidatService)
    {
        _evaluationService = evaluationService;
        _candidatService = candidatService;
    }
    
    public async Task<IActionResult> Index()
    {
        var model = new HomeViewModel
        {
            ApplicationName = "Plateforme d'Évaluation",
            
            // Récupérer les stats
            TotalCandidats = await _candidatService.GetTotalCount(),
            EvaluationsActives = await _evaluationService.GetActiveCount(),
            TentativesCompletes = await _evaluationService.GetCompletedAttempts(),
            TauxReussite = await _evaluationService.GetSuccessRate(),
            
            // Récupérer les 3 dernières évaluations
            EvaluationsRecentes = await _evaluationService.GetLatestThree(),
            
            // Features (statiques)
            Features = new List<FeatureDto>
            {
                new FeatureDto { Icon = "⚙️", Titre = "Correction Automatique", Description = "..." },
                new FeatureDto { Icon = "📊", Titre = "Analyses Avancées", Description = "..." },
                new FeatureDto { Icon = "🔒", Titre = "Sécurisé & Fiable", Description = "..." },
                // ...
            }
        };
        
        return View(model);
    }
}
*/

/* ================================
   8. CUSTOMISATION CSS PAR PAGE
   ================================ */

/*
   Vous pouvez créer des classes personnalisées pour des pages spécifiques.
   
   Exemple: Couleur différente pour chaque type d'évaluation
   
   .eval-card.evaluation-math {
     border-color: #3b82f6;  /* Bleu pour Math */
   }
   
   .eval-card.evaluation-english {
     border-color: #ef4444;  /* Rouge pour Anglais */
   }
   
   .eval-card.evaluation-science {
     border-color: #10b981;  /* Vert pour Science */
   }
   
   Utilisation:
   <div class="eval-card evaluation-math">...</div>
   <div class="eval-card evaluation-english">...</div>
*/

/* ================================
   9. AJOUTER UN MESSAGE DE BIENVENUE
   ================================ */

/*
   Dans _Layout.cshtml, après le navbar:
   
   @if (User.Identity.IsAuthenticated)
   {
     <div class="welcome-banner">
       <p>Bienvenue, @User.Identity.Name</p>
     </div>
   }
   
   CSS pour la banner:
   
   .welcome-banner {
     background: linear-gradient(135deg, rgba(99, 102, 241, 0.1), rgba(139, 92, 246, 0.05));
     padding: 1rem 2rem;
     margin-bottom: 2rem;
     border-radius: var(--radius-md);
     border-left: 4px solid var(--primary);
   }
*/

/* ================================
   10. ANIMATION DES COMPTEURS DYNAMIQUES
   ================================ */

/*
   Si vous chargez les stats en AJAX, utilisez:
   
   <script>
   async function loadStats() {
     const response = await fetch('/api/stats');
     const data = await response.json();
     
     document.querySelector('[data-stat="candidats"]').textContent = data.totalCandidats;
     document.querySelector('[data-stat="evaluations"]').textContent = data.evaluationsActives;
     
     // Animer les compteurs
     animateCounter(
       document.querySelector('.stat-card:nth-child(1) h3'),
       data.totalCandidats
     );
   }
   
   loadStats();
   </script>
   
   Utilisation:
   <h3 data-stat="candidats">0</h3>
*/

/* ================================
   11. INTÉGRATION AVEC BOOTSTRAP
   ================================ */

/*
   Le CSS moderne est compatible avec Bootstrap.
   Vous pouvez mélanger les classes:
   
   <div class="container">
     <div class="row">
       <div class="col-md-6">
         <div class="feature-card">
           ...
         </div>
       </div>
     </div>
   </div>
   
   Les variables CSS bootstrap sont respectées.
*/

/* ================================
   12. PERMISSION UTILISATEUR
   ================================ */

/*
   Afficher/Masquer des sections selon les permissions:
   
   <section class="features-section">
     @if (User.IsInRole("Admin"))
     {
       <div class="feature-card">
         <div class="feature-icon">🔧</div>
         <h3>Administration</h3>
         <p>Gérez l'application entière</p>
       </div>
     }
   </section>
*/

/* ================================
   13. CHARGEMENT DE CONTENU DYNAMIQUE
   ================================ */

/*
   Pour charger les évaluations de façon asynchrone:
   
   // En bas de la page Index.cshtml
   <script>
   document.addEventListener('DOMContentLoaded', async function() {
     try {
       const response = await fetch('/api/evaluations/recent?count=3');
       const evaluations = await response.json();
       
       const container = document.querySelector('.recent-grid');
       container.innerHTML = evaluations.map(eval => `
         <div class="eval-card">
           <h4>${eval.titre}</h4>
           <p class="eval-meta">⏱️ ${eval.duree} minutes</p>
           <div class="eval-stats">
             <span>${eval.candidats} candidats</span>
           </div>
         </div>
       `).join('');
     } catch (error) {
       console.error('Erreur au chargement:', error);
     }
   });
   </script>
*/

/* ================================
   14. NOTIFICATIONS ET ALERTES
   ================================ */

/*
   Ajouter des notifications TempData:
   
   @if (TempData["Succes"] != null)
   {
     <div class="alert alert-success alert-dismissible fade show">
       @TempData["Succes"]
       <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
     </div>
   }
   
   CSS personnalisé:
   
   .alert {
     padding: 1rem;
     border-radius: var(--radius-md);
     border-left: 4px solid;
     animation: slideInDown var(--transition-base);
   }
   
   .alert-success {
     background: linear-gradient(135deg, rgba(16, 185, 129, 0.1), rgba(16, 185, 129, 0.05));
     border-left-color: #10b981;
     color: #047857;
   }
*/

/* ================================
   15. TESTING & DÉVELOPPEMENT
   ================================ */

/*
   Pour tester rapidement sans données réelles:
   
   Utilisez les données statiques actuellement présentes dans Index.cshtml.
   
   Quand vous êtes prêt pour les données réelles:
   1. Créez les services (IEvaluationService, ICandidatService)
   2. Injectez dans HomeController
   3. Remplissez le HomeViewModel
   4. Remplacez les valeurs statiques par @Model.Property
   5. Testez dans le navigateur
   
   N'oubliez pas de vider le cache du navigateur (Ctrl+Shift+R)!
*/
