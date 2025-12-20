/* ================================
   CONFIGURATION DE DÉVELOPPEMENT LOCAL
   Pour tester le design localement
   ================================ */

/*
   Ce fichier contient des conseils pour tester et développer
   le design moderne en local avant production.
*/

/* ================================
   SETUP LOCAL - Checklist
   ================================ */

/*
   1. Cloner/Ouvrir le projet dans VS Code
   2. Ouvrir la solution dans Visual Studio
   3. Rebuild la solution (Ctrl+Shift+B)
   4. Lancer le projet (F5 ou Ctrl+F5)
   5. Accéder à https://localhost:XXXX/
   6. Ouvrir DevTools (F12)
   7. Vérifier la console pour erreurs
   8. Tester les animations et responsive
*/

/* ================================
   VÉRIFICATIONS NAVIGATEUR (F12)
   ================================ */

/*
   Console Tab:
   ✅ Pas d'erreurs rouges
   ✅ Pas d'avertissements graves
   ✅ Messages "✅ Animations et interactivité initialisées"

   Network Tab:
   ✅ home-modern.css chargé (200)
   ✅ home-animations.js chargé (200)
   ✅ Polices Google Fonts chargées (200)
   ✅ Pas de 404 errors

   Performance Tab:
   ✅ LCP < 2.5s
   ✅ FID < 100ms
   ✅ CLS < 0.1
   ✅ Pas de jank (lag)

   Accessibility Tab:
   ✅ Pas d'erreurs majeurs
   ✅ Contraste suffisant
   ✅ Éléments interactifs accessibles
*/

/* ================================
   COMMANDS UTILES DANS LA CONSOLE
   ================================ */

/*
   // Toggle mode sombre
   window.toggleDarkMode();

   // Vérifier les variables CSS
   getComputedStyle(document.documentElement).getPropertyValue('--primary');

   // Animer un élément manuellement
   window.animateElement(document.querySelector('.stat-card'), 'slideInDown', 1000);

   // Scroller vers un élément
   window.scrollToElement('.features-section');

   // Vérifier si élément visible
   window.isElementVisible(document.querySelector('.stat-card'));

   // Forcer le rechargement des animations
   location.reload();

   // Vérifier localStorage dark mode
   localStorage.getItem('darkMode');

   // Effacer localStorage
   localStorage.clear();
*/

/* ================================
   SHORTCUTS CLAVIER
   ================================ */

/*
   DevTools:
   F12 / Ctrl+Shift+I        → Ouvrir DevTools
   Ctrl+Shift+C              → Element inspector
   Ctrl+Shift+J              → Console
   Ctrl+Shift+E              → Network
   Ctrl+Shift+M              → Toggle responsive mode

   Navigation:
   Ctrl+L                    → Focus address bar
   Ctrl+R / F5               → Refresh page
   Ctrl+Shift+R / Ctrl+F5    → Hard refresh (vider cache)
   Ctrl+Tab                  → Next tab
   Ctrl+Shift+Tab            → Previous tab

   Page:
   Home                      → Haut page
   End                       → Bas page
   Space / Page Down         → Scroll page down
   Shift+Space / Page Up     → Scroll page up
   Ctrl+F                    → Find in page
*/

/* ================================
   RÉSOLUTION DES PROBLÈMES LOCAUX
   ================================ */

/*
   ❌ CSS n'est pas appliqué?
   ✅ Solution:
      1. Vérifier que home-modern.css est lié dans _Layout.cshtml
      2. Ctrl+Shift+R pour hard refresh
      3. F12 → Network → chercher home-modern.css
      4. Si 404, vérifier le chemin: ~/css/home-modern.css

   ❌ JavaScript erreurs en console?
   ✅ Solution:
      1. Vérifier que home-animations.js est lié
      2. F12 → Console → Chercher les messages d'erreur
      3. Ctrl+Shift+R pour hard refresh
      4. Recharger la page

   ❌ Animations ne fonctionnent pas?
   ✅ Solution:
      1. F12 → Console: window.toggleDarkMode() (test)
      2. Vérifier si animation définie en CSS
      3. Vérifier les keyframes en CSS
      4. Chercher --transition-base en CSS

   ❌ Mode sombre ne s'active pas?
   ✅ Solution:
      1. F12 → Console: window.toggleDarkMode()
      2. Vérifier localStorage: localStorage.getItem('darkMode')
      3. Vérifier prefers-color-scheme système
      4. CSS doit avoir body.dark-mode selectors

   ❌ Page est lente?
   ✅ Solution:
      1. F12 → Performance → Record
      2. Scroller la page
      3. Vérifier les long tasks
      4. Regarder DevTools Network waterfall
      5. Peut être des images non optimisées

   ❌ Affichage bug sur mobile?
   ✅ Solution:
      1. F12 → Toggle device mode (Ctrl+Shift+M)
      2. Changer taille viewport
      3. Vérifier media queries
      4. Tester sur appareils réels
*/

/* ================================
   WORKFLOW DE DÉVELOPPEMENT
   ================================ */

/*
   Workflow recommandé:

   1. Éditer le CSS:
      • Ouvrir home-modern.css
      • Faire les changements
      • Sauvegarder (Ctrl+S)
      • Refresh navigateur (F5)
      • Vérifier les changements

   2. Éditer le JavaScript:
      • Ouvrir home-animations.js
      • Faire les changements
      • Sauvegarder (Ctrl+S)
      • Hard refresh (Ctrl+Shift+R)
      • Vérifier console et fonctionnalité

   3. Éditer le HTML:
      • Ouvrir Index.cshtml ou _Layout.cshtml
      • Faire les changements
      • Sauvegarder (Ctrl+S)
      • Refresh navigateur
      • Vérifier affichage

   4. Tester:
      • Desktop (full screen)
      • Tablette (768px)
      • Mobile (480px)
      • Portrait & paysage
      • Mode sombre & clair

   5. Vérifier Performance:
      • F12 → Lighthouse
      • Run audit
      • Vérifier scores
      • Fix issues si nécessaire
*/

/* ================================
   POINTS DE BREAKPOINT (DevTools)
   ================================ */

/*
   Résolutions de test recommandées:

   Mobile:
   • 375px (iPhone SE, iPhone 12/13 mini)
   • 390px (iPhone 12/13)
   • 414px (iPhone 12 Pro Max)
   • 480px (Android standard)

   Tablette:
   • 768px (iPad Mini)
   • 810px (iPad)
   • 1024px (iPad Pro)

   Desktop:
   • 1280px (standard)
   • 1366px (common)
   • 1440px (high res)
   • 1920px (full HD)
   • 2560px (4K)

   Étapes:
   1. F12 → Toggle device mode (Ctrl+Shift+M)
   2. Cliquer "Edit" → Ajouter custom device
   3. Entrer dimensions et DPR (Device Pixel Ratio)
   4. Tester design à chaque résolution
*/

/* ================================
   GIT WORKFLOW
   ================================ */

/*
   Si vous utilisez Git:

   1. Créer une branche:
      git checkout -b feature/modern-design

   2. Faire les changements et commits:
      git add .
      git commit -m "feat: add modern CSS design"

   3. Push et créer pull request:
      git push origin feature/modern-design

   4. Merge après review:
      git checkout main
      git merge feature/modern-design

   5. Clean up:
      git branch -d feature/modern-design
*/

/* ================================
   PERFORMANCE TESTING
   ================================ */

/*
   Google Lighthouse:
   1. F12 → Lighthouse tab
   2. Cliquer "Analyze page load"
   3. Attendre les résultats
   4. Vérifier scores:
      • Performance > 85
      • Accessibility > 90
      • Best Practices > 90
      • SEO > 90

   PageSpeed Insights (en ligne):
   1. Aller sur https://pagespeed.web.dev/
   2. Entrer URL de votre site
   3. Analyser
   4. Vérifier les suggestions

   WebPageTest:
   1. Aller sur https://www.webpagetest.org/
   2. Entrer URL
   3. Sélectionner location et browser
   4. Run test
   5. Analyser waterfall

   DevTools Performance:
   1. F12 → Performance tab
   2. Cliquer "Record"
   3. Interagir avec la page
   4. Cliquer "Stop"
   5. Analyser la timeline
*/

/* ================================
   DARK MODE TESTING
   ================================ */

/*
   Pour tester le mode sombre:

   Méthode 1 - Préférence système:
   Windows: Settings → Personalization → Colors → Dark
   macOS: System Preferences → General → Appearance → Dark
   Linux: Varies by desktop environment

   Méthode 2 - DevTools:
   F12 → Rendering → Emulate CSS media feature prefers-color-scheme
   Choisir "dark" ou "light"

   Méthode 3 - Console:
   window.toggleDarkMode();

   Vérifier:
   ✅ Fond devient foncé
   ✅ Texte devient clair
   ✅ Cards deviennent grises
   ✅ Ombres visibles en mode sombre
   ✅ Contraste toujours bon (≥4.5:1)
*/

/* ================================
   ACCESSIBILITY TESTING
   ================================ */

/*
   Clavier:
   1. Tab → Naviguer entre éléments
   2. Shift+Tab → Naviguer en arrière
   3. Enter → Activer boutons/links
   4. Space → Checker/unchekar checkboxes

   Vérifier:
   ✅ Tous les boutons atteignables
   ✅ Focus visible (outline)
   ✅ Order logique (haut→bas, gauche→droite)
   ✅ Pas de piège clavier

   Lecteur d'écran:
   Windows: Narrator (Win+Ctrl+Enter)
   macOS: VoiceOver (Cmd+F5)
   Linux: Orca

   Contraste:
   F12 → Elements → Computed → Color
   Vérifier ratio: Contrast (AAA/AA)
   Utiliser: https://webaim.org/resources/contrastchecker/

   WAVE (WebAIM):
   1. Installer extension WAVE
   2. Lancer sur la page
   3. Vérifier errors (rouges)
   4. Vérifier alerts (jaunes)
   5. Fix issues
*/

/* ================================
   TESTS CROSS-BROWSER
   ================================ */

/*
   Navigateurs à tester:

   Chrome/Chromium:
   • Chrome (Windows, macOS, Linux)
   • Chromium (open source)
   • Edge (Windows, macOS)

   Firefox:
   • Firefox (Windows, macOS, Linux)

   Safari:
   • Safari (macOS)
   • Safari (iOS - iPhone/iPad)

   Autres:
   • Opera
   • Vivaldi

   Services de test:
   • BrowserStack: https://www.browserstack.com/
   • Sauce Labs: https://saucelabs.com/
   • LambdaTest: https://www.lambdatest.com/
*/

/* ================================
   DEBUGGING TIPS
   ================================ */

/*
   1. Utiliser console.log():
      console.log('Variable:', myVariable);
      console.table(arrayData);
      console.error('Error message');

   2. Utiliser debugger statement:
      function myFunction() {
        debugger; // Page pause ici si DevTools ouvert
      }

   3. Breakpoints en DevTools:
      F12 → Sources → Cliquer ligne gauche pour breakpoint
      Puis interagir avec la page

   4. Watch expressions:
      F12 → Sources → Watch
      Ajouter variables à surveiller

   5. Conditional breakpoints:
      Clic droit sur ligne → Add conditional breakpoint
      Entrer condition (ex: x > 10)

   6. DOM mutations:
      F12 → Elements → Clic droit → Break on...
      Choisir: subtree modifications, attribute changes, node removal
*/

/* ================================
   OPTIMISATION LOCALE
   ================================ */

/*
   Avant de pusher le code:

   1. Minifier CSS:
      • Utiliser: https://cssminifier.com/
      • Ou: npm install cssnano
      • Puis: npx cssnano input.css output.min.css

   2. Minifier JavaScript:
      • Utiliser: https://www.minifycode.com/javascript/
      • Ou: npm install terser
      • Puis: npx terser input.js -o output.min.js

   3. Optimiser images:
      • Utiliser: TinyPNG, Squoosh, ImageOptim
      • Format: WebP pour navigateurs modernes
      • Taille: Pas plus de 100KB par image

   4. Supprimer code non utilisé:
      • Utiliser Coverage en DevTools (Ctrl+Shift+P)
      • Chercher "coverage"
      • Identifier code non utilisé
      • Supprimer ou refactoriser

   5. Vérifier cache:
      • DevTools → Network → Disable cache
      • Tester avec cache désactivé
      • Vérifier après réactivation
*/

/* ================================
   BUILD ET DÉPLOIEMENT
   ================================ */

/*
   Local development:
   1. dotnet build
   2. dotnet run

   Staging deployment:
   1. dotnet publish -c Release
   2. Copier les fichiers
   3. Configurer le serveur web
   4. Tester complètement

   Production deployment:
   1. Backup base de données
   2. Backup fichiers anciens
   3. Copier new files
   4. Vérifier fonctionnalité
   5. Monitorer les erreurs
   6. Garder backup pour rollback
*/

/* ================================
   DOCUMENTATION PERSONNELLE
   ================================ */

/*
   Créer un fichier local: NOTES_DEV.md

   Contenu:
   - Bugs trouvés et solutions
   - Customisations faites
   - Futures améliorations
   - Contacts équipe
   - Procédures locales
*/

/* ================================
   FIN DE LA CONFIGURATION
   ================================ */

/*
   Avec ces tips, vous êtes prêt à:
   ✅ Développer le design en local
   ✅ Tester sur tous appareils
   ✅ Vérifier performance
   ✅ Déboguer efficacement
   ✅ Déployer sans soucis

   Bon développement ! 🚀
*/
