/* ================================
   SNIPPETS CSS RAPIDES
   Copies collées prêtes à utiliser
   ================================ */

/* ================================
   SNIPPETS DE COULEURS
   ================================ */

/* Snippet 1: Changer la couleur primaire en bleu */
/*
:root {
  --primary: #0891b2 !important;
  --primary-light: #06b6d4 !important;
  --primary-dark: #0369a1 !important;
  --gradient-main: linear-gradient(135deg, #0891b2 0%, #0369a1 50%, #06b6d4 100%) !important;
}
*/

/* Snippet 2: Changer la couleur primaire en vert */
/*
:root {
  --primary: #10b981 !important;
  --primary-light: #34d399 !important;
  --primary-dark: #059669 !important;
  --gradient-main: linear-gradient(135deg, #10b981 0%, #34d399 50%, #059669 100%) !important;
}
*/

/* Snippet 3: Changer la couleur primaire en rouge */
/*
:root {
  --primary: #ef4444 !important;
  --primary-light: #f87171 !important;
  --primary-dark: #dc2626 !important;
  --gradient-main: linear-gradient(135deg, #ef4444 0%, #dc2626 50%, #f87171 100%) !important;
}
*/

/* Snippet 4: Thème monochrome (gris) */
/*
:root {
  --primary: #6b7280 !important;
  --primary-light: #9ca3af !important;
  --primary-dark: #4b5563 !important;
  --gradient-main: linear-gradient(135deg, #6b7280 0%, #9ca3af 50%, #4b5563 100%) !important;
}
*/

/* ================================
   SNIPPETS D'ANIMATIONS
   ================================ */

/* Snippet 5: Désactiver toutes les animations */
/*
* {
  animation: none !important;
  transition: none !important;
}
*/

/* Snippet 6: Ralentir les animations (x2) */
/*
:root {
  --transition-fast: 0.4s !important;
  --transition-base: 0.6s !important;
  --transition-slow: 1s !important;
}
*/

/* Snippet 7: Accélérer les animations (x2) */
/*
:root {
  --transition-fast: 0.1s !important;
  --transition-base: 0.15s !important;
  --transition-slow: 0.25s !important;
}
*/

/* Snippet 8: Augmenter l'intensité des hover effects */
/*
.stat-card:hover,
.feature-card:hover,
.eval-card:hover {
  transform: translateY(-15px) scale(1.02) !important;
  box-shadow: 0 25px 50px rgba(99, 102, 241, 0.3) !important;
}
*/

/* ================================
   SNIPPETS D'ESPACEMENTS
   ================================ */

/* Snippet 9: Augmenter l'espacement entre les sections */
/*
.stats-section,
.features-section,
.recent-section {
  margin: 8rem 0 !important;
}
*/

/* Snippet 10: Réduire l'espacement pour mobile */
/*
@media (max-width: 480px) {
  .stats-section,
  .features-section,
  .recent-section {
    margin: 3rem 0 !important;
  }
}
*/

/* Snippet 11: Augmenter le padding des cartes */
/*
.stat-card,
.feature-card,
.eval-card {
  padding: 3rem !important;
}
*/

/* Snippet 12: Réduire le padding des cartes */
/*
.stat-card,
.feature-card,
.eval-card {
  padding: 1rem !important;
}
*/

/* ================================
   SNIPPETS DE TYPOGRAPHIE
   ================================ */

/* Snippet 13: Augmenter les tailles de police */
/*
body {
  font-size: 18px !important;
  line-height: 1.8 !important;
}

.section-title {
  font-size: 3rem !important;
}

.feature-card h3 {
  font-size: 1.5rem !important;
}
*/

/* Snippet 14: Polices plus épaisses */
/*
body {
  font-weight: 500 !important;
}

.section-title,
.stat-card h3,
.feature-card h3 {
  font-weight: 800 !important;
}
*/

/* Snippet 15: Utiliser Comic Sans (pour fun) */
/*
body {
  font-family: 'Comic Sans MS', cursive !important;
}
*/

/* ================================
   SNIPPETS D'OMBRES ET PROFONDEUR
   ================================ */

/* Snippet 16: Augmenter les ombres */
/*
:root {
  --shadow-sm: 0 4px 8px rgba(0, 0, 0, 0.15) !important;
  --shadow-md: 0 8px 16px rgba(0, 0, 0, 0.2) !important;
  --shadow-lg: 0 16px 32px rgba(0, 0, 0, 0.3) !important;
  --shadow-xl: 0 32px 64px rgba(0, 0, 0, 0.4) !important;
}
*/

/* Snippet 17: Enlever les ombres */
/*
.stat-card,
.feature-card,
.eval-card,
.hero-inner {
  box-shadow: none !important;
}
*/

/* Snippet 18: Augmenter les rayons de bordure */
/*
:root {
  --radius-sm: 16px !important;
  --radius-md: 20px !important;
  --radius-lg: 32px !important;
  --radius-xl: 48px !important;
}
*/

/* Snippet 19: Réduire les rayons de bordure (carrés) */
/*
:root {
  --radius-sm: 0 !important;
  --radius-md: 0 !important;
  --radius-lg: 0 !important;
  --radius-xl: 0 !important;
}
*/

/* ================================
   SNIPPETS DE GLASSMORPHISM
   ================================ */

/* Snippet 20: Augmenter le blur (plus transparent) */
/*
.hero-inner,
.stat-card,
.feature-card,
.eval-card {
  backdrop-filter: blur(20px) !important;
  background: rgba(255, 255, 255, 0.5) !important;
}
*/

/* Snippet 21: Réduire le blur (plus opaque) */
/*
.hero-inner,
.stat-card,
.feature-card,
.eval-card {
  backdrop-filter: blur(5px) !important;
  background: rgba(255, 255, 255, 0.95) !important;
}
*/

/* Snippet 22: Enlever le glassmorphism (arrière-plans solides) */
/*
.hero-inner,
.stat-card,
.feature-card,
.eval-card {
  backdrop-filter: none !important;
  background: #ffffff !important;
}
*/

/* ================================
   SNIPPETS DE DISPOSITION
   ================================ */

/* Snippet 23: Afficher les cartes en ligne (2 par ligne) */
/*
.stats-grid,
.features-grid,
.recent-grid {
  grid-template-columns: repeat(2, 1fr) !important;
}

@media (max-width: 768px) {
  .stats-grid,
  .features-grid,
  .recent-grid {
    grid-template-columns: 1fr !important;
  }
}
*/

/* Snippet 24: Afficher les cartes en ligne (4 par ligne) */
/*
.stats-grid,
.features-grid,
.recent-grid {
  grid-template-columns: repeat(4, 1fr) !important;
}
*/

/* Snippet 25: Centrer le contenu verticalement */
/*
.hero-inner,
.stat-card,
.feature-card,
.eval-card {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  min-height: 300px !important;
}
*/

/* ================================
   SNIPPETS DE VISIBILITÉ
   ================================ */

/* Snippet 26: Masquer les sections spécifiques */
/*
.features-section {
  display: none !important;
}

/* ou */

.recent-section {
  visibility: hidden !important;
}
*/

/* Snippet 27: Rendre les sections semi-transparentes */
/*
.stats-section {
  opacity: 0.7 !important;
}
*/

/* Snippet 28: Grayscale (noir et blanc) */
/*
body {
  filter: grayscale(100%) !important;
}
*/

/* ================================
   SNIPPETS DE NAVBAR
   ================================ */

/* Snippet 29: Navbar avec fond solide (pas de blur) */
/*
.navbar {
  background: #ffffff !important;
  backdrop-filter: none !important;
}
*/

/* Snippet 30: Navbar transparente */
/*
.navbar {
  background: transparent !important;
  border-bottom: none !important;
  box-shadow: none !important;
}
*/

/* Snippet 31: Navbar colorée avec dégradé */
/*
.navbar {
  background: linear-gradient(135deg, #6366f1 0%, #8b5cf6 100%) !important;
}

.nav-link {
  color: white !important;
}

.navbar-brand {
  color: white !important;
  -webkit-text-fill-color: white !important;
}
*/

/* ================================
   SNIPPETS DE BOUTONS
   ================================ */

/* Snippet 32: Boutons plus grands */
/*
.btn {
  padding: 1.25rem 3rem !important;
  font-size: 1.25rem !important;
}
*/

/* Snippet 33: Boutons plus petits */
/*
.btn {
  padding: 0.5rem 1rem !important;
  font-size: 0.85rem !important;
}
*/

/* Snippet 34: Boutons arrondis (pill-shape) */
/*
.btn {
  border-radius: 999px !important;
}
*/

/* Snippet 35: Désactiver les animations des boutons */
/*
.btn {
  transition: none !important;
}

.btn:hover {
  transform: none !important;
}
*/

/* ================================
   SNIPPETS DE MODE SOMBRE
   ================================ */

/* Snippet 36: Forcer le mode sombre globalement */
/*
body {
  background: #0f172a !important;
  color: #e2e8f0 !important;
}

.navbar,
.stat-card,
.feature-card,
.eval-card,
.hero-inner {
  background: rgba(30, 41, 59, 0.8) !important;
  border-color: rgba(99, 102, 241, 0.2) !important;
}
*/

/* Snippet 37: Forcer le mode clair globalement */
/*
body {
  background: #ffffff !important;
  color: #1e293b !important;
}

body.dark-mode {
  background: #ffffff !important;
  color: #1e293b !important;
}

.navbar,
.stat-card,
.feature-card,
.eval-card,
.hero-inner {
  background: rgba(255, 255, 255, 0.9) !important;
  border-color: rgba(99, 102, 241, 0.15) !important;
}
*/

/* ================================
   SNIPPETS DE DÉBOGAGE
   ================================ */

/* Snippet 38: Montrer les grilles de débogage */
/*
* {
  outline: 1px solid red !important;
}
*/

/* Snippet 39: Augmenter la visibilité des éléments */
/*
.fade-in-on-scroll {
  opacity: 1 !important;
  transform: none !important;
}
*/

/* Snippet 40: Vérifier les espacements */
/*
body {
  background-image: repeating-linear-gradient(
    0deg,
    rgba(0, 0, 0, 0.1) 0px,
    rgba(0, 0, 0, 0.1) 1px,
    transparent 1px,
    transparent 10px
  );
}
*/

/* ================================
   SNIPPETS DE RESPONSIVE
   ================================ */

/* Snippet 41: Mobile first - forcer mobile */
/*
html {
  font-size: 14px !important;
}

.container {
  max-width: 100% !important;
  padding: 0 1rem !important;
}

.stats-grid,
.features-grid,
.recent-grid {
  grid-template-columns: 1fr !important;
  gap: 1rem !important;
}
*/

/* Snippet 42: Desktop only - masquer sur mobile */
/*
@media (max-width: 768px) {
  .hero-inner {
    display: none !important;
  }
}
*/

/* Snippet 43: Augmenter les breakpoints */
/*
@media (max-width: 1200px) {
  /* Nouveau breakpoint */
}
*/

/* ================================
   SNIPPETS DE PERFORMANCE
   ================================ */

/* Snippet 44: Désactiver la hardware acceleration */
/*
* {
  will-change: auto !important;
  transform: none !important;
  backface-visibility: visible !important;
}
*/

/* Snippet 45: Forcer la hardware acceleration partout */
/*
* {
  will-change: transform !important;
  transform: translateZ(0) !important;
  backface-visibility: hidden !important;
}
*/

/* ================================
   SNIPPETS SPÉCIAUX
   ================================ */

/* Snippet 46: Faire tourner le logo */
/*
.navbar-brand {
  animation: rotation 20s linear infinite !important;
}

@keyframes rotation {
  from {
    transform: rotate(0deg);
  }
  to {
    transform: rotate(360deg);
  }
}
*/

/* Snippet 47: Pulse effect (battement) */
/*
.stat-card,
.feature-card {
  animation: pulse 2s cubic-bezier(0.4, 0, 0.6, 1) infinite !important;
}

@keyframes pulse {
  0%, 100% {
    opacity: 1;
  }
  50% {
    opacity: 0.5;
  }
}
*/

/* Snippet 48: Rainbow gradient animated */
/*
@keyframes rainbow {
  0% {
    background: linear-gradient(90deg, red, orange, yellow, green);
  }
  25% {
    background: linear-gradient(90deg, orange, yellow, green, blue);
  }
  50% {
    background: linear-gradient(90deg, yellow, green, blue, indigo);
  }
  75% {
    background: linear-gradient(90deg, green, blue, indigo, violet);
  }
  100% {
    background: linear-gradient(90deg, blue, indigo, violet, red);
  }
}

.hero-inner {
  animation: rainbow 8s ease infinite !important;
}
*/

/* Snippet 49: Texte qui change de couleur au hover */
/*
.section-title:hover {
  animation: colorShift 0.5s ease !important;
}

@keyframes colorShift {
  0% { color: #6366f1; }
  50% { color: #8b5cf6; }
  100% { color: #ec4899; }
}
*/

/* Snippet 50: Contenu en bas de page se révèle au scroll */
/*
.page-bottom-content {
  opacity: 0;
  animation: slideInUp 1s ease-out forwards;
}

@keyframes slideInUp {
  from {
    opacity: 0;
    transform: translateY(50px);
  }
  to {
    opacity: 1;
    transform: translateY(0);
  }
}
*/

/* ================================
   FIN DES SNIPPETS
   ================================ */

/*
   💡 Astuces:
   
   1. Copiez le snippet entre /* et */
   2. Décommentez-le
   3. Ajustez les valeurs selon vos besoins
   4. Testez dans votre navigateur
   5. Utilisez Ctrl+Shift+R pour forcer le rechargement du cache
   
   6. N'oubliez pas les !important si les styles ne s'appliquent pas
   7. Soyez prudent avec les !important en production
   8. Testez sur mobile aussi !
   
   Questions? Consultez:
   - CSS_GUIDE.md pour la documentation complète
   - components-examples.css pour plus d'exemples
   - DevTools (F12) pour inspecter et tester
*/
