# 📱 Guide CSS Moderne - Plateforme d'Évaluation

## 📋 Table des matières

1. [Vue d'ensemble](#vue-densemble)
2. [Structure des fichiers](#structure-des-fichiers)
3. [Variables CSS](#variables-css)
4. [Composants](#composants)
5. [Animations](#animations)
6. [Mode Sombre](#mode-sombre)
7. [Responsivité](#responsivité)
8. [Performance](#performance)
9. [Personnalisation](#personnalisation)

---

## Vue d'ensemble

Le design moderne de la page d'accueil combine plusieurs tendances actuelles :

✨ **Glassmorphism** - Effet de verre translucide
🎨 **Dégradés modernes** - Indigo → Violet → Rose
📐 **Layout Flexbox/Grid** - Disposition responsive
🎬 **Animations subtiles** - Transitions fluides et micro-interactions
🌙 **Mode sombre** - Thème clair/foncé automatique
♿ **Accessibilité** - WCAG compliant

---

## Structure des fichiers

```
wwwroot/
├── css/
│   ├── home-modern.css          ← CSS moderne principal
│   └── site.css                  ← CSS existant (conservé)
├── js/
│   └── home-animations.js        ← Animations & interactivité
└── Views/
    └── Home/
        └── Index.cshtml          ← HTML page d'accueil
```

---

## Variables CSS

Les variables sont définies dans le sélecteur `:root` pour faciliter la personnalisation :

### Couleurs Primaires
```css
--primary: #6366f1;              /* Indigo vibrant */
--primary-light: #818cf8;        /* Indigo clair */
--primary-dark: #4f46e5;         /* Indigo foncé */
```

### Couleurs Secondaires
```css
--secondary: #8b5cf6;            /* Violet pourpre */
--accent-cyan: #06b6d4;          /* Cyan moderne */
--accent-pink: #ec4899;          /* Rose vif */
```

### Arrière-plans
```css
--bg-primary: #ffffff;           /* Blanc */
--bg-secondary: #f8fafc;         /* Gris très clair */
--dark-bg: #0f172a;              /* Mode sombre */
```

### Ombres
```css
--shadow-sm: 0 2px 4px rgba(0, 0, 0, 0.05);
--shadow-md: 0 4px 12px rgba(0, 0, 0, 0.1);
--shadow-lg: 0 12px 24px rgba(0, 0, 0, 0.15);
--shadow-glow: 0 0 30px rgba(99, 102, 241, 0.15);
```

### Transitions
```css
--transition-fast: 0.2s cubic-bezier(0.4, 0, 0.2, 1);
--transition-base: 0.3s cubic-bezier(0.4, 0, 0.2, 1);
--transition-slow: 0.5s cubic-bezier(0.4, 0, 0.2, 1);
```

---

## Composants

### 1. Navigation (Navbar)

**Classe:** `.navbar`

**Caractéristiques:**
- Sticky (reste en haut au scroll)
- Blur background (effet glassmorphism)
- Lien actif avec underline animée
- Responsive sur mobile

**Utilisation:**
```html
<nav class="navbar">
  <a class="navbar-brand">Logo</a>
  <a class="nav-link">Lien</a>
</nav>
```

### 2. Boutons

**Classes:**
- `.btn .btn-primary` - Bouton principal (dégradé)
- `.btn .btn-secondary` - Bouton secondaire (outline)

**Caractéristiques:**
- Hover effect avec élévation
- Ripple effect au clic
- Animations smooth

**Utilisation:**
```html
<a href="#" class="btn btn-primary">Commencer →</a>
<a href="#" class="btn btn-secondary">En savoir plus</a>
```

### 3. Cartes (Cards)

**Classes disponibles:**
- `.stat-card` - Cartes statistiques
- `.feature-card` - Cartes de fonctionnalités
- `.eval-card` - Cartes d'évaluations

**Caractéristiques:**
- Glassmorphism avec backdrop-filter
- Hover effect lift
- Border gradient au hover
- Animations au scroll

**Utilisation:**
```html
<div class="stat-card">
  <div class="stat-icon">👥</div>
  <h3>1,240</h3>
  <p>Candidats</p>
</div>
```

### 4. Sections

**Classes:**
- `.hero-inner` - Section héro avec glassmorphism
- `.stats-section` - Grille de statistiques
- `.features-section` - Grille de fonctionnalités
- `.recent-section` - Section d'évaluations récentes

**Utilisation:**
```html
<section class="stats-section fade-in-on-scroll">
  <!-- Contenu -->
</section>
```

---

## Animations

### Animations CSS intégrées

**Animation d'entrée (Page Load):**
```css
@keyframes slideInDown {  /* Hero titre */
@keyframes slideInUp {    /* Contenu vers le haut */
@keyframes fadeIn {       /* Fondu */
@keyframes scaleIn {      /* Zoom entrée */
```

**Animations de mouvement:**
```css
@keyframes float {        /* Mouvement vertical subtil */
@keyframes bounce {       /* Rebond des icônes */
@keyframes glow {         /* Effet lumineux */
```

### Animations JavaScript

**1. Sticky Navbar au scroll**
```javascript
window.addEventListener('scroll', function() {
  if (window.scrollY > 50) {
    navbar.classList.add('scrolled');
  }
});
```

**2. Intersection Observer (Animation au scroll)**
```javascript
const observer = new IntersectionObserver(entries => {
  entries.forEach(entry => {
    if (entry.isIntersecting) {
      entry.target.classList.add('visible');
    }
  });
});
```

**3. Compteurs animés (Stats)**
```javascript
// Les chiffres des stats s'animent au scroll
animateCounter(element, targetValue, duration);
```

**4. Ripple Effect (Boutons)**
```javascript
// Au clic sur un bouton, effet de ripple
// (déjà implémenté automatiquement)
```

### Utiliser les animations

**Classe pour animations au scroll:**
```html
<section class="fade-in-on-scroll">
  <!-- Sera animée au scroll -->
</section>
```

**Fonction pour animer manuellement:**
```javascript
animateElement(element, 'slideInDown', 1000);
```

---

## Mode Sombre

### Activation automatique

Le mode sombre s'active selon :
1. Préférence système `prefers-color-scheme: dark`
2. Sauvegarde localStorage

### CSS Mode Sombre

Toutes les variables changent dans le mode sombre :
```css
body.dark-mode {
  background-color: var(--dark-bg);
  color: var(--dark-text);
}

body.dark-mode .navbar {
  background: rgba(30, 41, 59, 0.95);
}
```

### Forcer le mode sombre

```javascript
window.toggleDarkMode();  // Toggle clair/foncé
```

### Ajouter un bouton toggle

```html
<button onclick="toggleDarkMode()" class="btn-dark-mode">
  🌙 Mode Sombre
</button>
```

---

## Responsivité

Le design s'adapte automatiquement à 3 breakpoints :

### Desktop (> 1024px)
- Layout complet
- Toutes les animations
- Full padding

### Tablette (768px - 1024px)
- Grid 2 colonnes
- Animations réduites
- Padding modéré

### Mobile (< 480px)
- Grid 1 colonne
- Animations simplifiées
- Padding minimal
- Navbar collapsible

**Media queries utilisées:**
```css
@media (max-width: 768px) { /* Tablette */ }
@media (max-width: 480px) { /* Mobile */ }
```

---

## Performance

### Optimisations implémentées

1. **Hardware Acceleration**
   ```css
   will-change: transform;
   transform: translateZ(0);
   backface-visibility: hidden;
   ```

2. **Lazy Loading des images**
   ```javascript
   // Intersection Observer pour images
   // Images chargées seulement au scroll
   ```

3. **Debounce Scroll Events**
   ```javascript
   // Pas d'appels excessifs au scroll
   // requestAnimationFrame utilisé
   ```

4. **CSS Passive Event Listeners**
   ```javascript
   addEventListener('scroll', handler, { passive: true });
   ```

5. **Reduced Motion Support**
   ```css
   @media (prefers-reduced-motion: reduce) {
     * { animation-duration: 0.01ms !important; }
   }
   ```

---

## Personnalisation

### Changer les couleurs

**Modifier les variables CSS:**
```css
:root {
  --primary: #YOUR_COLOR;
  --secondary: #YOUR_COLOR;
  --accent-cyan: #YOUR_COLOR;
  --accent-pink: #YOUR_COLOR;
}
```

### Changer les polices

Les Google Fonts utilisées:
- **Inter** - Texte général
- **Poppins** - Titres
- **Playfair Display** - Grands titres

Pour changer :
```css
@import url('https://fonts.googleapis.com/css2?family=YOUR_FONT:wght@400;700&display=swap');

body {
  font-family: 'YOUR_FONT', sans-serif;
}
```

### Ajuster les animations

**Durée des transitions:**
```css
:root {
  --transition-base: 0.5s; /* au lieu de 0.3s */
}
```

**Désactiver certaines animations:**
```css
.stat-card {
  animation: none; /* Désactiver animation */
}
```

### Modifier les rayons de bordure

```css
:root {
  --radius-sm: 12px;   /* Au lieu de 8px */
  --radius-md: 16px;
  --radius-lg: 20px;
}
```

---

## Dépannage

### Les animations ne fonctionnent pas
✓ Vérifier que `home-animations.js` est chargé
✓ Vérifier la console pour les erreurs
✓ Vérifier que `home-modern.css` est lié

### Le mode sombre ne fonctionne pas
✓ Vérifier localStorage : `localStorage.getItem('darkMode')`
✓ Appeler : `window.toggleDarkMode()`
✓ Vérifier les variables CSS dans `body.dark-mode`

### Performance lente
✓ Vérifier les images optimisées
✓ Désactiver les animations complexes
✓ Utiliser DevTools Performance tab

---

## Ressources

- 📖 [MDN - CSS Variables](https://developer.mozilla.org/en-US/docs/Web/CSS/--*)
- 🎨 [Glassmorphism.com](https://glassmorphism.com)
- ✨ [Animate.css](https://animate.style/)
- 📱 [Google Fonts](https://fonts.google.com)

---

**Version:** 1.0
**Dernière mise à jour:** Décembre 2025
**Compatibilité:** Chrome, Firefox, Safari, Edge (dernières versions)
