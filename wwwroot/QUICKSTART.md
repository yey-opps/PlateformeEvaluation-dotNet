# ⚡ GUIDE DE DÉMARRAGE RAPIDE (5 minutes)

## 🎯 Vous êtes pressé? Commencez ici!

### Étape 1: Vérifier que tout est en place (30 secondes)

```powershell
# Vérifier que les fichiers existent
dir c:\Users\jrida\Desktop\WebApplication1\WebApplication1\wwwroot\css\home-modern.css
dir c:\Users\jrida\Desktop\WebApplication1\WebApplication1\wwwroot\js\home-animations.js
```

✅ Fichiers trouvés?

---

### Étape 2: Ouvrir la page dans le navigateur (1 minute)

1. **Ouvrir Visual Studio**
2. **Press F5** (ou Debug → Start Debugging)
3. **Page d'accueil devrait s'ouvrir** automatiquement

```
✅ Vous devriez voir:
   • Navbar sticky en haut
   • Hero section avec gradient
   • 4 cartes de statistiques
   • 6 cartes de fonctionnalités
   • 3 cartes d'évaluations
```

---

### Étape 3: Tester les animations (1 minute)

1. **Ouvrir DevTools:** F12
2. **Scroller vers le bas** → Voir animations
3. **Hover sur les cartes** → Voir effets
4. **Cliquer les boutons** → Voir ripple effect

```
✅ Animations fonctionnent?
   • Cards s'élèvent au hover
   • Texte anime au scroll
   • Boutons ont effet ripple
```

---

### Étape 4: Tester le mode sombre (1 minute)

```javascript
// Dans la console DevTools (F12), copier-coller:
window.toggleDarkMode();
```

✅ Fond devient foncé et texte clair?

---

### Étape 5: Tester le responsive (1 minute)

1. **Press Ctrl+Shift+M** (Device toolbar)
2. **Changer taille:**
   - 480px → Mobile
   - 768px → Tablette
   - 1024px → Desktop
3. **Vérifier affichage** à chaque taille

✅ Layout s'adapte correctement?

---

## 🎨 Personnalisation rapide

### Changer les couleurs (30 secondes)

Ouvrir `home-modern.css` et modifier :

```css
:root {
  --primary: #6366f1;      /* Changer ici */
  --secondary: #8b5cf6;    /* Et ici */
  --accent-cyan: #06b6d4;  /* Et ici */
}
```

Puis: **Ctrl+Shift+R** pour recharger

---

### Changer le titre (30 secondes)

Ouvrir `Index.cshtml` et modifier :

```html
<h1>Votre titre ici</h1>
```

Puis: **F5** pour recharger

---

### Intégrer vos données (5 minutes)

1. Ouvrir `HomeController.cs`
2. Ajouter les data depuis la DB
3. Passer à `HomeViewModel`
4. Utiliser `@Model.Property` dans `Index.cshtml`

→ Voir `INTEGRATION_GUIDE.md` pour plus

---

## 📚 Documentation

| Vous voulez... | Lisez |
|---|---|
| Vue rapide | **SUMMARY.txt** |
| Guide complet | **CSS_GUIDE.md** |
| Intégrer données | **INTEGRATION_GUIDE.md** |
| Snippets rapides | **CSS_SNIPPETS.md** |
| Avant production | **CHECKLIST.md** |
| Développer localement | **DEV_LOCAL_GUIDE.md** |

---

## ✅ Checklist 5 minutes

- [ ] CSS/JS chargés (F12 → Network)
- [ ] Animations visibles (scroller)
- [ ] Mode sombre fonctionne (console)
- [ ] Responsive OK (Ctrl+Shift+M)
- [ ] Pas d'erreurs (F12 → Console)

---

## 🚨 Problèmes courants

**CSS n'apparaît pas?**
→ Ctrl+Shift+R (hard refresh)

**JS erreurs?**
→ F12 → Console → lire l'erreur

**Page blanche?**
→ Vérifier le serveur est en cours (F5 affiche erreur)

---

## 🚀 Prêt à déployer?

Voir **CHECKLIST.md** pour la liste complète.

---

**Créé:** Décembre 2025  
**Temps de lecture:** 2 minutes  
**Temps de test:** 5 minutes

**Bienvenue dans le design moderne ! 🎉**
