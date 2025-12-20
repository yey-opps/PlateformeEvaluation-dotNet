// home.js - initialize particles, typing, counters, tilt, parallax and small UX effects
document.addEventListener('DOMContentLoaded', function () {
  // Particles (using tsparticles CDN if available)
  if (window.tsParticles && document.getElementById('tsparticles')) {
    tsParticles.load('tsparticles', {
      fpsLimit: 60,
      interactivity: { events: { onHover: { enable: true, mode: 'repulse' } } },
      particles: {
        number: { value: 60 },
        color: { value: ['#66a3ff', '#0b66d6', '#a3d2ff'] },
        shape: { type: 'circle' },
        opacity: { value: 0.7 },
        size: { value: { min: 1, max: 4 } },
        links: { enable: true, distance: 140, color: '#0b66d6', opacity: 0.15 },
        move: { enable: true, speed: 0.9, outModes: 'out' }
      }
    });
  }

  // Typing effect (simple)
  const typingEl = document.querySelector('.typing');
  if (typingEl) {
    const texts = ["Plateforme d'Évaluation", 'Gestion • Tests • Résultats'];
    let ti = 0, ci = 0;
    function type() {
      const str = texts[ti];
      typingEl.textContent = str.slice(0, ci);
      ci++;
      if (ci > str.length) { setTimeout(() => { ci = 0; ti = (ti + 1) % texts.length; }, 1100); }
      setTimeout(type, ci > str.length ? 2000 : 80);
    }
    type();
  }

  // Counters on scroll
  const counters = document.querySelectorAll('.counter');
  if ('IntersectionObserver' in window && counters.length) {
    const obs = new IntersectionObserver((entries, o)=>{
      entries.forEach(e=>{
        if(e.isIntersecting){
          const el = e.target; const to = parseInt(el.dataset.count||'0',10);
          let v = 0; const dur = 1200; const start = performance.now();
          function tick(now){
            const p = Math.min(1,(now-start)/dur);
            el.textContent = Math.floor(p*to);
            if(p<1) requestAnimationFrame(tick); else el.textContent = to;
          }
          requestAnimationFrame(tick);
          o.unobserve(el);
        }
      })
    }, {threshold:0.3});
    counters.forEach(c=>obs.observe(c));
  }

  // Vanilla tilt for cards
  if (window.VanillaTilt) {
    document.querySelectorAll('.tilt-card').forEach(el=>{
      VanillaTilt.init(el, { max: 12, speed: 400, glare: true, 'max-glare': 0.18 });
    });
  }

  // Simple parallax: layers move on scroll
  const layers = document.querySelectorAll('[data-parallax]');
  if (layers.length) {
    window.addEventListener('scroll', ()=>{
      const sc = window.scrollY;
      layers.forEach(l=>{
        const depth = parseFloat(l.dataset.parallax) || 0.2;
        l.style.transform = `translateY(${-(sc*depth)}px)`;
      });
    });
  }

  // Scroll reveal for timeline
  const reveals = document.querySelectorAll('.reveal-on-scroll');
  if ('IntersectionObserver' in window && reveals.length) {
    const ro = new IntersectionObserver((entries, o)=>{
      entries.forEach(en=>{ if(en.isIntersecting){ en.target.classList.add('revealed'); o.unobserve(en.target); }});
    }, {threshold:0.15});
    reveals.forEach(r=>ro.observe(r));
  }

  // Buttons ripple effect
  document.querySelectorAll('.ripple').forEach(btn=>{
    btn.addEventListener('click', function(e){
      const r = document.createElement('span'); r.className='ripple-ink';
      const rect = this.getBoundingClientRect();
      r.style.left = (e.clientX - rect.left)+'px'; r.style.top = (e.clientY - rect.top)+'px';
      this.appendChild(r);
      setTimeout(()=> r.remove(), 800);
    })
  });

  // Start radial animations if any
  document.querySelectorAll('.radial.animate').forEach(r=>{ /* CSS handles animation */ });
});

// small helper to set progress bar widths when called externally
function setProgress(selector, value){
  const el = document.querySelector(selector);
  if(el){ const fill = el.querySelector('.fill'); if(fill){ fill.style.width = value + '%'; }}
}

// export small API
window.HomeUI = { setProgress };
